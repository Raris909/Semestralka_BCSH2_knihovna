using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Knihovna_BCSH2.ViewModel
{
    public class ZakazniciViewModel : ObservableObject
    {
        private readonly DatabaseHelper dbHelper = new DatabaseHelper();

        // ObservableCollection pro zákazníky
        public ObservableCollection<Zakaznik> Zakaznici { get; set; } = new ObservableCollection<Zakaznik>();

        private Zakaznik _selectedZakaznik;
        public Zakaznik SelectedZakaznik
        {
            get => _selectedZakaznik;
            set
            {
                _selectedZakaznik = value;
                OnPropertyChanged();
                EditCommand.NotifyCanExecuteChanged();
                DeleteCommand.NotifyCanExecuteChanged();
            }
        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand BackToMenuCommand { get; }


        public ZakazniciViewModel()
        {
            LoadZakaznici();
            AddCommand = new RelayCommand(AddZakaznik);
            EditCommand = new RelayCommand(EditZakaznik, CanEditOrDelete);
            DeleteCommand = new RelayCommand(DeleteZakaznik, CanEditOrDelete);
            BackToMenuCommand = new RelayCommand(BackToMenu);
        }

        private void LoadZakaznici()
        {
            var zakaznici = dbHelper.GetZakaznici();
            Zakaznici.Clear();
            foreach (var zakaznik in zakaznici)
            {
                Zakaznici.Add(zakaznik);
            }
        }

        private void AddZakaznik()
        {
            var addDialog = new PridatZakaznika();
            if (addDialog.ShowDialog() == true)
            {
                var zakaznik = new Zakaznik
                {
                    Jmeno = addDialog.JmenoTextBox.Text,
                    Prijmeni = addDialog.PrijmeniTextBox.Text,
                    Adresa = addDialog.AdresaTextBox.Text,
                    Telefon = addDialog.TelefonTextBox.Text,
                    Email = addDialog.EmailTextBox.Text
                };

                dbHelper.AddZakaznik(zakaznik);
                MessageBox.Show("Zákazník byl přidán.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadZakaznici(); // Obnovení seznamu zákazníků
            }
        }

        private void EditZakaznik()
        {
            if (SelectedZakaznik != null)
            {
                var editDialog = new PridatZakaznika
                {
                    JmenoTextBox = { Text = SelectedZakaznik.Jmeno },
                    PrijmeniTextBox = { Text = SelectedZakaznik.Prijmeni },
                    AdresaTextBox = { Text = SelectedZakaznik.Adresa },
                    TelefonTextBox = { Text = SelectedZakaznik.Telefon },
                    EmailTextBox = { Text = SelectedZakaznik.Email }
                };

                if (editDialog.ShowDialog() == true)
                {
                    SelectedZakaznik.Jmeno = editDialog.JmenoTextBox.Text;
                    SelectedZakaznik.Prijmeni = editDialog.PrijmeniTextBox.Text;
                    SelectedZakaznik.Adresa = editDialog.AdresaTextBox.Text;
                    SelectedZakaznik.Telefon = editDialog.TelefonTextBox.Text;
                    SelectedZakaznik.Email = editDialog.EmailTextBox.Text;

                    dbHelper.UpdateZakaznik(SelectedZakaznik);
                    MessageBox.Show("Zákazník byl úspěšně upraven.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadZakaznici(); // Obnovení seznamu
                }
            }
        }

        private void DeleteZakaznik()
        {
            if (SelectedZakaznik != null)
            {
                var result = MessageBox.Show($"Opravdu chcete odstranit zákazníka {SelectedZakaznik.Jmeno} {SelectedZakaznik.Prijmeni}?",
                    "Potvrdit smazání", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    dbHelper.DeleteZakaznik(SelectedZakaznik.Id);
                    MessageBox.Show("Zákazník byl odstraněn.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadZakaznici(); // Obnovení seznamu
                }
            }
        }

        private void BackToMenu()
        {
            MainWindow mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;

            var currentWindow = Application.Current.Windows.OfType<Window>()
                .SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();
            mainWindow.Show();
        }

        private bool CanEditOrDelete()
        {
            return SelectedZakaznik != null;
        }
    }
}
