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
    /// Interaction logic for Zapujcky.xaml
    /// </summary>
    public partial class Zapujcky : Window
    {
        public string datumZapujcky { get; set; }
        public string datumVraceni { get; set; }
        public string kniha { get; set; }
        public string zakaznik { get; set; }
        public Zapujcky()
        {
            InitializeComponent();
        }

        public Zapujcky(string datumZapujcky, string datumVraceni, string kniha, string zakaznik)
        {
            InitializeComponent();
            this.datumZapujcky = datumZapujcky;
            this.datumVraceni = datumVraceni;
            this.kniha = kniha;
            this.zakaznik = zakaznik;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void AddLoan_Click(object sender, RoutedEventArgs e)
        {

        }
        private void EditLoan_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteLoan_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
