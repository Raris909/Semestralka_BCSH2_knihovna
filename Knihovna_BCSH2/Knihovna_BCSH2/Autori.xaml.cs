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
    /// Interaction logic for Autori.xaml
    /// </summary>
    public partial class Autori : Window
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private List<Autor> authorsList = new List<Autor>();
        public Autori()
        {
            InitializeComponent();
            LoadAuthors();
        }

        private void LoadAuthors()
        {
            authorsList = dbHelper.GetAllAuthors();
            AuthorsDataGrid.ItemsSource = authorsList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            PridatAutora addAuthorWindow = new PridatAutora();
            addAuthorWindow.ShowDialog();
            LoadAuthors();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorsDataGrid.SelectedItem is Autor selectedAuthor)
            {
                PridatAutora editAuthorWindow = new PridatAutora(selectedAuthor);
                editAuthorWindow.ShowDialog();
                LoadAuthors();
            }
            else
            {
                MessageBox.Show("Vyberte autora k úpravě.");
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorsDataGrid.SelectedItem is Autor selectedAuthor)
            {
                dbHelper.DeleteAuthor(selectedAuthor.Id);
                LoadAuthors();
            }
            else
            {
                MessageBox.Show("Vyberte autora k odstranění.");
            }
        }

    }
}
