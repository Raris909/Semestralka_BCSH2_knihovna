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
    /// Interaction logic for PridatZakaznika.xaml
    /// </summary>
    public partial class PridatZakaznika : Window
    {
        public string Jmeno { get; private set; }
        public string Prijmeni { get; private set; }
        public string Adresa { get; private set; }
        public string Telefon { get; private set; }
        public string Email { get; private set; }

        public PridatZakaznika()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(JmenoTextBox.Text) ||
                string.IsNullOrWhiteSpace(PrijmeniTextBox.Text) ||
                string.IsNullOrWhiteSpace(AdresaTextBox.Text) ||
                string.IsNullOrWhiteSpace(TelefonTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Prosím, vyplňte všechna pole.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Jmeno = JmenoTextBox.Text;
            Prijmeni = PrijmeniTextBox.Text;
            Adresa = AdresaTextBox.Text;
            Telefon = TelefonTextBox.Text;
            Email = EmailTextBox.Text;

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
