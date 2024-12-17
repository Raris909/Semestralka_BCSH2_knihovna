using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Knihovna_BCSH2.ViewModel
{
    public class PridatKnihuViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseHelper dbHelper = new DatabaseHelper();
        private List<Autor> _availableAuthors;

        public event PropertyChangedEventHandler PropertyChanged;

        private Kniha _currentBook;
        public Kniha CurrentBook
        {
            get => _currentBook;
            set
            {
                _currentBook = value;
                OnPropertyChanged();
            }
        }

        // Vlastnosti pro form inputs
        public string Nazev { get; set; }
        public string Zanr { get; set; }
        public string Vydavatel { get; set; }
        public string RokVydani { get; set; }
        public string PocetStran { get; set; }
        public string Jazyk { get; set; }
        public int? SelectedAutorId { get; set; }
        public string Title { get; set; }

        public List<Autor> AvailableAuthors
        {
            get => _availableAuthors;
            set
            {
                _availableAuthors = value;
                OnPropertyChanged();
            }
        }

        // RelayCommands
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public PridatKnihuViewModel(Kniha book = null)
        {
            try
            {
                // Načítání dostupných autorů
                AvailableAuthors = dbHelper.GetAllAuthors();
                foreach (var author in AvailableAuthors)
                {
                    author.FullName = $"{author.Jmeno} {author.Prijmeni}";
                }

                // Inicializace pro přidání nebo úpravu knihy
                if (book != null)
                {
                    CurrentBook = book;
                    Nazev = book.Nazev;
                    Zanr = book.Zanr;
                    Vydavatel = book.Vydavatel;
                    RokVydani = book.RokVydani.ToString();
                    PocetStran = book.PocetStran.ToString();
                    Jazyk = book.Jazyk;
                    SelectedAutorId = book.AutorId;

                    Title = "Upravit knihu";
                }
                else
                {
                    CurrentBook = new Kniha();
                    Title = "Přidat knihu";
                }

                OkCommand = new RelayCommand(ExecuteOk);
                CancelCommand = new RelayCommand(ExecuteCancel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo k chybě při načítání autorů: {ex.Message}");
            }
        }

        private void ExecuteOk()
        {
            if (string.IsNullOrEmpty(Nazev) || string.IsNullOrEmpty(Zanr) ||
                string.IsNullOrEmpty(Vydavatel) || string.IsNullOrEmpty(RokVydani) ||
                string.IsNullOrEmpty(PocetStran) || string.IsNullOrEmpty(Jazyk) ||
                SelectedAutorId == null)
            {
                MessageBox.Show("Vyplňte všechny povinné údaje a vyberte autora.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(RokVydani, out int rokVydani) || !int.TryParse(PocetStran, out int pocetStran))
            {
                MessageBox.Show("Rok vydání a počet stran musí být platná čísla.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (CurrentBook.Id == 0) // Přidání nové knihy
                {
                    var newBook = new Kniha
                    {
                        Nazev = Nazev,
                        Zanr = Zanr,
                        Vydavatel = Vydavatel,
                        RokVydani = rokVydani,
                        PocetStran = pocetStran,
                        Jazyk = Jazyk,
                        AutorId = SelectedAutorId.Value
                    };

                    dbHelper.AddBook(newBook);
                    MessageBox.Show("Kniha byla úspěšně přidána.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else // Úprava existující knihy
                {
                    CurrentBook.Nazev = Nazev;
                    CurrentBook.Zanr = Zanr;
                    CurrentBook.Vydavatel = Vydavatel;
                    CurrentBook.RokVydani = rokVydani;
                    CurrentBook.PocetStran = pocetStran;
                    CurrentBook.Jazyk = Jazyk;
                    CurrentBook.AutorId = SelectedAutorId.Value;

                    dbHelper.UpdateBook(CurrentBook);
                    MessageBox.Show("Kniha byla úspěšně upravena.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                CloseWindow?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo k chybě: {ex.Message}", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExecuteCancel()
        {
            CloseWindow?.Invoke();
        }

        public Action CloseWindow { get; set; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
