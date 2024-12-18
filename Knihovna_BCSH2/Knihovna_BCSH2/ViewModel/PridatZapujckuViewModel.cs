using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Knihovna_BCSH2.ViewModel
{
    public class PridatZapujckuViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseHelper dbHelper = new DatabaseHelper();
        private readonly Zapujcka currentLoan;

        public ObservableCollection<Kniha> AvailableBooks { get; } = new ObservableCollection<Kniha>();
        public ObservableCollection<Zakaznik> AvailableCustomers { get; } = new ObservableCollection<Zakaznik>();

        private int selectedKnihaId;
        public int SelectedKnihaId
        {
            get => selectedKnihaId;
            set
            {
                if (selectedKnihaId != value)
                {
                    selectedKnihaId = value;
                    OnPropertyChanged(nameof(SelectedKnihaId));
                }
            }
        }

        private int selectedZakaznikId;
        public int SelectedZakaznikId
        {
            get => selectedZakaznikId;
            set
            {
                if (selectedZakaznikId != value)
                {
                    selectedZakaznikId = value;
                    OnPropertyChanged(nameof(SelectedZakaznikId));
                }
            }
        }

        private DateTime datumZapujcky = DateTime.Now;
        public DateTime DatumZapujcky
        {
            get => datumZapujcky;
            set
            {
                if (datumZapujcky != value)
                {
                    datumZapujcky = value;
                    OnPropertyChanged(nameof(DatumZapujcky));
                }
            }
        }

        private DateTime? datumVraceni;
        public DateTime? DatumVraceni
        {
            get => datumVraceni;
            set
            {
                if (datumVraceni != value)
                {
                    datumVraceni = value;
                    OnPropertyChanged(nameof(DatumVraceni));
                }
            }
        }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public PridatZapujckuViewModel(Zapujcka zapujcka = null)
        {
            try
            {
                Title = zapujcka == null ? "Přidat zápůjčku" : "Upravit zápůjčku";

                // Načtení knih a zákazníků z databáze
                var knihy = dbHelper.GetKnihy();
                var zakaznici = dbHelper.GetZakaznici();

                foreach (var zakaznik in zakaznici)
                {
                    zakaznik.FullName = $"{zakaznik.Jmeno} {zakaznik.Prijmeni}";
                }

                AvailableBooks = new ObservableCollection<Kniha>(knihy);
                AvailableCustomers = new ObservableCollection<Zakaznik>(zakaznici);

                if (zapujcka != null)
                {
                    currentLoan = zapujcka;

                    SelectedKnihaId = zapujcka.KnihaId;
                    SelectedZakaznikId = zapujcka.ZakaznikId;
                    DatumZapujcky = zapujcka.DatumZapujcky;
                    DatumVraceni = zapujcka.DatumVraceni;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při načítání dat: {ex.Message}", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ICommand OkCommand => new RelayCommand<Window>(Ok);
        public ICommand CancelCommand => new RelayCommand<Window>(window => window?.Close());

        private void Ok(Window window)
        {
            if (SelectedKnihaId == 0 || SelectedZakaznikId == 0 || DatumZapujcky == DateTime.MinValue)
            {
                MessageBox.Show("Vyplňte všechna povinná pole!", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (currentLoan == null)
                {
                    // Přidání nové zápůjčky
                    var zapujcka = new Zapujcka
                    {
                        DatumZapujcky = DatumZapujcky,
                        DatumVraceni = DatumVraceni,
                        KnihaId = SelectedKnihaId,
                        ZakaznikId = SelectedZakaznikId
                    };

                    dbHelper.AddZapujcka(zapujcka);
                    MessageBox.Show("Zápůjčka byla úspěšně přidána.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    // Úprava existující zápůjčky
                    currentLoan.DatumZapujcky = DatumZapujcky;
                    currentLoan.DatumVraceni = DatumVraceni;
                    currentLoan.KnihaId = SelectedKnihaId;
                    currentLoan.ZakaznikId = SelectedZakaznikId;

                    dbHelper.UpdateZapujcka(currentLoan);
                    MessageBox.Show("Zápůjčka byla úspěšně upravena.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                window.DialogResult = true;
                window.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo k chybě při ukládání zápůjčky: {ex.Message}", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
