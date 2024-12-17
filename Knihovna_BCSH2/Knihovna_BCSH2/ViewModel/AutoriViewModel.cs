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
    public class AutoriViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseHelper dbHelper = new DatabaseHelper();
        public ObservableCollection<Autor> Authors { get; set; } = new ObservableCollection<Autor>();

        private Autor _selectedAuthor;
        public Autor SelectedAuthor
        {
            get => _selectedAuthor;
            set
            {
                _selectedAuthor = value;
                OnPropertyChanged(nameof(SelectedAuthor));
                EditCommand.NotifyCanExecuteChanged();
                DeleteCommand.NotifyCanExecuteChanged();
            }
        }

        // Příkazy
        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand BackToMenuCommand { get; }

        public AutoriViewModel()
        {
            LoadAuthors();

            AddCommand = new RelayCommand(AddAuthor);
            EditCommand = new RelayCommand(EditAuthor, CanEditOrDelete);
            DeleteCommand = new RelayCommand(DeleteAuthor, CanEditOrDelete);
            BackToMenuCommand = new RelayCommand(BackToMenu);
        }

        private void LoadAuthors()
        {
            var authors = dbHelper.GetAllAuthors();
            Authors.Clear();
            foreach (var author in authors)
            {
                Authors.Add(author);
            }
        }

        private void AddAuthor()
        {
            var addWindow = new PridatAutora();
            addWindow.ShowDialog();
            LoadAuthors();
        }

        private void EditAuthor()
        {
            if (SelectedAuthor != null)
            {
                var editWindow = new PridatAutora(SelectedAuthor);
                editWindow.ShowDialog();
                LoadAuthors();
            }
        }

        private void DeleteAuthor()
        {
            if (SelectedAuthor != null)
            {
                // Zobrazení potvrzovacího dialogu
                var result = MessageBox.Show($"Opravdu chcete smazat autora {SelectedAuthor.Jmeno} {SelectedAuthor.Prijmeni}?", "Potvrzení smazání", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    dbHelper.DeleteAuthor(SelectedAuthor.Id);
                    Authors.Remove(SelectedAuthor);
                    SelectedAuthor = null;
                }
            }
        }

        private void BackToMenu()
        {
            var mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;

            var currentWindow = Application.Current.Windows.OfType<Window>()
                .SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();
            mainWindow.Show();
        }

        private bool CanEditOrDelete()
        {
            return SelectedAuthor != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
