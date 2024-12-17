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
    public class PridatAutoraViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseHelper dbHelper = new DatabaseHelper();
        private Autor _currentAuthor;

        // Vlastnosti pro datovou vazbu
        private string _jmeno;
        public string Jmeno
        {
            get => _jmeno;
            set { _jmeno = value; OnPropertyChanged(); }
        }

        private string _prijmeni;
        public string Prijmeni
        {
            get => _prijmeni;
            set { _prijmeni = value; OnPropertyChanged(); }
        }

        private string _datumNarozeni;
        public string DatumNarozeni
        {
            get => _datumNarozeni;
            set { _datumNarozeni = value; OnPropertyChanged(); }
        }

        private string _zeme;
        public string Zeme
        {
            get => _zeme;
            set { _zeme = value; OnPropertyChanged(); }
        }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }


        // Příkazy
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public event Action<bool> CloseRequested;

        // Konstruktor
        public PridatAutoraViewModel(Autor author = null)
        {
            if (author != null)
            {
                _currentAuthor = author;
                Jmeno = author.Jmeno;
                Prijmeni = author.Prijmeni;
                DatumNarozeni = author.DatumNarozeni.ToString("yyyy-MM-dd");
                Zeme = author.Zeme;
                Title = "Upravit autora";
            }
            else
            {
                _currentAuthor = null;
                Title = "Přidat autora";
            }

            OkCommand = new RelayCommand<PridatAutora>(ExecuteOk);
            CancelCommand = new RelayCommand<PridatAutora>(ExecuteCancel);
        }

        private void ExecuteOk(object parameter)
        {
            if (string.IsNullOrEmpty(Jmeno) || string.IsNullOrEmpty(Prijmeni) ||
                string.IsNullOrEmpty(DatumNarozeni) || string.IsNullOrEmpty(Zeme))
            {
                MessageBox.Show("Vyplňte všechny povinné údaje.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!DateTime.TryParse(DatumNarozeni, out DateTime parsedDate))
            {
                MessageBox.Show("Neplatný formát data narození.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (_currentAuthor == null)
                {
                    var newAuthor = new Autor
                    {
                        Jmeno = Jmeno,
                        Prijmeni = Prijmeni,
                        DatumNarozeni = parsedDate,
                        Zeme = Zeme
                    };

                    dbHelper.AddAuthor(newAuthor);
                    MessageBox.Show("Autor byl úspěšně přidán.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    _currentAuthor.Jmeno = Jmeno;
                    _currentAuthor.Prijmeni = Prijmeni;
                    _currentAuthor.DatumNarozeni = parsedDate;
                    _currentAuthor.Zeme = Zeme;

                    dbHelper.UpdateAuthor(_currentAuthor);
                    MessageBox.Show("Autor byl úspěšně upraven.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                CloseRequested?.Invoke(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo k chybě při ukládání autora: {ex.Message}", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExecuteCancel(object parameter)
        {
            CloseRequested?.Invoke(false);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
