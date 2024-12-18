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
    public class ZapujckyViewModel : ObservableObject
    {
        private readonly DatabaseHelper dbHelper = new DatabaseHelper();

        // ObservableCollection pro zápůjčky
        public ObservableCollection<Zapujcka> Zapujcky { get; set; } = new ObservableCollection<Zapujcka>();

        private Zapujcka _selectedZapujcka;
        public Zapujcka SelectedZapujcka
        {
            get => _selectedZapujcka;
            set
            {
                _selectedZapujcka = value;
                OnPropertyChanged();
                EditCommand.NotifyCanExecuteChanged();
                DeleteCommand.NotifyCanExecuteChanged();
            }
        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand BackToMenuCommand { get; }

        public ZapujckyViewModel()
        {
            // Inicializace příkazů
            AddCommand = new RelayCommand(AddZapujcka);
            EditCommand = new RelayCommand(EditZapujcka, CanEditOrDelete);
            DeleteCommand = new RelayCommand(DeleteZapujcka, CanEditOrDelete);
            BackToMenuCommand = new RelayCommand(BackToMenu);

            // Načítání zápůjček
            LoadZapujcky();
        }

        // Načítání zápůjček
        private void LoadZapujcky()
        {
            var loans = dbHelper.GetAllZapujcky();
            Zapujcky.Clear();
            foreach (var loan in loans)
            {
                Zapujcky.Add(loan);
            }
        }

        // Přidání zápůjčky
        private void AddZapujcka()
        {
            var addLoanDialog = new PridatZapujcku();
            addLoanDialog.ShowDialog();
            LoadZapujcky();
        }

        // Úprava zápůjčky
        private void EditZapujcka()
        {
            if (SelectedZapujcka != null)
            {
                var editDialog = new PridatZapujcku(SelectedZapujcka);
                editDialog.ShowDialog();
                LoadZapujcky();
            }
        }


        // Smazání zápůjčky
        private void DeleteZapujcka()
        {
            if (SelectedZapujcka != null)
            {
                var result = MessageBox.Show("Opravdu chcete odstranit tuto zápůjčku?", "Potvrdit smazání", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    dbHelper.DeleteZapujcka(SelectedZapujcka);
                    MessageBox.Show("Zápůjčka byla úspěšně odstraněna.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadZapujcky(); // Obnovení seznamu
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

        // Určuje, zda lze zápůjčku upravit nebo smazat
        private bool CanEditOrDelete()
        {
            return SelectedZapujcka != null;
        }
    }

}
