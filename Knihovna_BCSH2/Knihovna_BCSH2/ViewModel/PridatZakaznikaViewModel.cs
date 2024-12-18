using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Controls;
using System.Data.Common;

namespace Knihovna_BCSH2.ViewModel
{
    public partial class PridatZakaznikaViewModel : ObservableObject
    {
        private string jmeno;

        public string Jmeno
        {
            get => jmeno;
            set
            {
                if (jmeno != value)
                {
                    jmeno = value;
                    OnPropertyChanged(nameof(Jmeno));
                }
            }
        }

        private string prijmeni;
        public string Prijmeni
        {
            get => prijmeni;
            set
            {
                if (prijmeni != value)
                {
                    prijmeni = value;
                    OnPropertyChanged(nameof(Prijmeni));
                }
            }
        }

        private string adresa;
        public string Adresa
        {
            get => adresa;
            set
            {
                if (adresa != value)
                {
                    adresa = value;
                    OnPropertyChanged(nameof(Adresa));
                }
            }
        }

        private string telefon;
        public string Telefon
        {
            get => telefon;
            set
            {
                if (telefon != value)
                {
                    telefon = value;
                    OnPropertyChanged(nameof(Telefon));
                }
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public IRelayCommand OkCommand { get; }
        public IRelayCommand CancelCommand { get; }
        private readonly DatabaseHelper dbHelper;
        private readonly Zakaznik existingCustomer;
        public Action CloseWindow { get; set; }

        public PridatZakaznikaViewModel(Zakaznik zakaznik = null)
        {
            dbHelper = new DatabaseHelper();

            if (zakaznik != null)
            {
                existingCustomer = zakaznik;
                Jmeno = zakaznik.Jmeno;
                Prijmeni = zakaznik.Prijmeni;
                Adresa = zakaznik.Adresa;
                Telefon = zakaznik.Telefon;
                Email = zakaznik.Email;
                Title = "Upravit zákazníka";
            }
            else
            {
                existingCustomer = null;
                Title = "Přidat zákazníka";
            }

            OkCommand = new RelayCommand<Window>(Ok);
            CancelCommand = new RelayCommand<Window>(Cancel);
        }

        private void Ok(Window window)
        {
            if (string.IsNullOrEmpty(Jmeno) || string.IsNullOrEmpty(Prijmeni) ||
                string.IsNullOrEmpty(Adresa) || string.IsNullOrEmpty(Telefon) || string.IsNullOrEmpty(Email))
            {
                MessageBox.Show("Vyplňte všechny povinné údaje.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (existingCustomer == null)
                {
                    var newCustomer = new Zakaznik
                    {
                        Jmeno = Jmeno,
                        Prijmeni = Prijmeni,
                        Adresa = Adresa,
                        Telefon = Telefon,
                        Email = Email
                    };

                    dbHelper.AddZakaznik(newCustomer);

                    MessageBox.Show("Zákazník byl úspěšně přidán.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    existingCustomer.Jmeno = Jmeno;
                    existingCustomer.Prijmeni = Prijmeni;
                    existingCustomer.Adresa = Adresa;
                    existingCustomer.Telefon = Telefon;
                    existingCustomer.Email = Email;

                    dbHelper.UpdateZakaznik(existingCustomer);

                    MessageBox.Show("Zákazník byl úspěšně upraven.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                window?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo k chybě při ukládání zákazníka: {ex.Message}", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel(Window window)
        {
            window?.Close();
        }
    }
}
