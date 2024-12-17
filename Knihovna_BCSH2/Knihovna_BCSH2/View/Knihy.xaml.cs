using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Knihovna_BCSH2
{
    /// <summary>
    /// Interaction logic for Knihy.xaml
    /// </summary>
    public partial class Knihy : Window
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        public Knihy()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var addBookWindow = new PridatKnihu();
            if (addBookWindow.ShowDialog() == true)
            {
                LoadBooks();
            }
        }
        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if (BooksDataGrid.SelectedItem is Kniha selectedBook)
            {
                var editBookWindow = new PridatKnihu(selectedBook);
                if (editBookWindow.ShowDialog() == true)
                {
                    LoadBooks();
                }
            }
            else
            {
                MessageBox.Show("Vyberte knihu, kterou chcete upravit.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (BooksDataGrid.SelectedItem is Kniha selectedBook)
            {
                if (MessageBox.Show("Opravdu chcete odstranit vybranou knihu?", "Potvrzení", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        dbHelper.DeleteBook(selectedBook);
                        MessageBox.Show("Kniha byla úspěšně odstraněna.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadBooks();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Došlo k chybě při odstraňování knihy: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vyberte knihu, kterou chcete odstranit.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LoadBooks()
        {
            try
            {
                var books = dbHelper.GetBooks();
                BooksDataGrid.ItemsSource = books;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo k chybě při načítání knih: {ex.Message}");
            }
        }

    }
}
