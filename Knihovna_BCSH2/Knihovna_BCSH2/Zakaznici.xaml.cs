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
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string adresa { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
        public Zakaznici()
        {
            InitializeComponent();
        }

        public Zakaznici(string jmeno, string prijmeni, string adresa, string telefon, string email)
        {
            InitializeComponent();
            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
            this.adresa = adresa;
            this.telefon = telefon;
            this.email = email;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var addCustomerDialog = new PridatZakaznika();
            addCustomerDialog.ShowDialog();
        }
        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
