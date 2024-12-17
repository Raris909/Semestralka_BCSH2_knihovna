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
    /// Interaction logic for Zakaznici.xaml
    /// </summary>
    public partial class Zakaznici : Window
    {
        public Zakaznici()
        {
            InitializeComponent();
            LoadZakaznici();
        }

        private void LoadZakaznici()
        {
            var dbHelper = new DatabaseHelper();
            var zakaznici = dbHelper.GetZakaznici();
            CustomersDataGrid.ItemsSource = zakaznici;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var pridatZakaznikaDialog = new PridatZakaznika();
            if (pridatZakaznikaDialog.ShowDialog() == true)
            {
                var zakaznik = new Zakaznik
                {
                    Jmeno = pridatZakaznikaDialog.JmenoTextBox.Text,
                    Prijmeni = pridatZakaznikaDialog.PrijmeniTextBox.Text,
                    Adresa = pridatZakaznikaDialog.AdresaTextBox.Text,
                    Telefon = pridatZakaznikaDialog.TelefonTextBox.Text,
                    Email = pridatZakaznikaDialog.EmailTextBox.Text
                };

                var dbHelper = new DatabaseHelper();
                dbHelper.AddZakaznik(zakaznik);

                MessageBox.Show("Zákazník byl přidán.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadZakaznici();
            }
        }
        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersDataGrid.SelectedItem is Zakaznik selectedZakaznik)
            {
                var editDialog = new PridatZakaznika
                {
                    JmenoTextBox = { Text = selectedZakaznik.Jmeno },
                    PrijmeniTextBox = { Text = selectedZakaznik.Prijmeni },
                    AdresaTextBox = { Text = selectedZakaznik.Adresa },
                    TelefonTextBox = { Text = selectedZakaznik.Telefon },
                    EmailTextBox = { Text = selectedZakaznik.Email }
                };

                if (editDialog.ShowDialog() == true)
                {
                    selectedZakaznik.Jmeno = editDialog.Jmeno;
                    selectedZakaznik.Prijmeni = editDialog.Prijmeni;
                    selectedZakaznik.Adresa = editDialog.Adresa;
                    selectedZakaznik.Telefon = editDialog.Telefon;
                    selectedZakaznik.Email = editDialog.Email;

                    var dbHelper = new DatabaseHelper();
                    dbHelper.UpdateZakaznik(selectedZakaznik);

                    MessageBox.Show("Zákazník byl úspěšně upraven.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadZakaznici();
                }
            }
            else
            {
                MessageBox.Show("Vyberte zákazníka k úpravě.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersDataGrid.SelectedItem is Zakaznik selectedZakaznik)
            {
                var result = MessageBox.Show($"Opravdu chcete odstranit zákazníka {selectedZakaznik.Jmeno} {selectedZakaznik.Prijmeni}?",
                    "Potvrdit smazání", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    var dbHelper = new DatabaseHelper();
                    dbHelper.DeleteZakaznik(selectedZakaznik.Id);

                    MessageBox.Show("Zákazník byl odstraněn.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadZakaznici();
                }
            }
            else
            {
                MessageBox.Show("Vyberte zákazníka k odstranění.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
