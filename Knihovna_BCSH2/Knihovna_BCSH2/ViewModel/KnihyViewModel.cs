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
    public class KnihyViewModel
    {
        private readonly DatabaseHelper dbHelper = new DatabaseHelper();

        public ObservableCollection<Kniha> Books { get; set; } = new ObservableCollection<Kniha>();

        private Kniha _selectedBook;
        public Kniha SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                EditCommand.NotifyCanExecuteChanged();
                DeleteCommand.NotifyCanExecuteChanged();
            }
        }

        // Commandy pro operace
        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand BackToMenuCommand { get; }

        public KnihyViewModel()
        {
            LoadBooks();

            AddCommand = new RelayCommand(AddBook);
            EditCommand = new RelayCommand(EditBook, CanModifyBook);
            DeleteCommand = new RelayCommand(DeleteBook, CanModifyBook);
            BackToMenuCommand = new RelayCommand(BackToMenu);
        }

        private void LoadBooks()
        {
            Books.Clear();
            foreach (var book in dbHelper.GetBooks())
            {
                Books.Add(book);
            }
        }

        private void AddBook()
        {
            var addWindow = new PridatKnihu();
            addWindow.ShowDialog();
            LoadBooks();
        }

        private void EditBook()
        {
            if (SelectedBook != null)
            {
                var editWindow = new PridatKnihu(SelectedBook);
                editWindow.ShowDialog();
                LoadBooks();
            }
        }

        private void DeleteBook()
        {
            if (SelectedBook != null)
            {
                var result = MessageBox.Show($"Opravdu chcete smazat knihu {SelectedBook.Nazev}?",
                    "Potvrzení", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    dbHelper.DeleteBook(SelectedBook);
                    Books.Remove(SelectedBook);
                    SelectedBook = null;
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

        private bool CanModifyBook()
        {
            return SelectedBook != null;
        }
    }
}
