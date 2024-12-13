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
            //var addAuthorDialog = new PridatAutora();
            //addAuthorDialog.ShowDialog();
            var newAuthor = new Autor
            {
                Jmeno = "Nové jméno",
                Prijmeni = "Nové příjmení",
                DatumNarozeni = DateTime.Now,
                Zeme = "Nová země"
            };

            dbHelper.AddAuthor(newAuthor);
            LoadAuthors(); // Obnoví DataGrid
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorsDataGrid.SelectedItem is Autor selectedAuthor)
            {
                selectedAuthor.Jmeno = "Upravené jméno";
                selectedAuthor.Prijmeni = "Upravené příjmení";
                selectedAuthor.DatumNarozeni = DateTime.Now;
                selectedAuthor.Zeme = "Upravená země";

                dbHelper.UpdateAuthor(selectedAuthor);
                LoadAuthors(); // Obnoví DataGrid
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
                LoadAuthors(); // Obnoví DataGrid
            }
            else
            {
                MessageBox.Show("Vyberte autora k odstranění.");
            }
        }

    }
}
