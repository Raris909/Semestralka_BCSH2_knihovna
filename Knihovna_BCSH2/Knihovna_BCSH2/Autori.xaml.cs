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
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string DatumNarozeni { get; set; }
        public string Zeme { get; set; }
        public Autori()
        {
            InitializeComponent();
        }

        public Autori(string jmeno, string prijmeni, string datumNarozeni, string zeme)
        {
            InitializeComponent();
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            DatumNarozeni = datumNarozeni;
            Zeme = zeme;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
