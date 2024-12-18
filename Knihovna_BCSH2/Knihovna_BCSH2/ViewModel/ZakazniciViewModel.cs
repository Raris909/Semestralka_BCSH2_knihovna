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
            addDialog.ShowDialog();
            LoadZakaznici();
        }

        private void EditZakaznik()
        {
            if (SelectedZakaznik != null)
            {
                var editDialog = new PridatZakaznika(SelectedZakaznik);
                editDialog.ShowDialog();
                LoadZakaznici();
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
