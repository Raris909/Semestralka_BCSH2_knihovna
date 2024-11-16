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
        public string Nazev { get; set; }
        public string Autor { get; set; }
        public string Zanr { get; set; }
        public string Vydavatel { get; set; }
        public string RokVydani { get; set; }
        public string PocetStran { get; set; }
        public string Jazyk { get; set; }
        public Knihy()
        {
            InitializeComponent();
        }

        public Knihy(string nazev, string autor, string zanr, string vydavatel, string rokVydani, string pocetStran, string jazyk)
        {
            InitializeComponent();
            Nazev = nazev;
            Autor = autor;
            Zanr = zanr;
            Vydavatel = vydavatel;
            RokVydani = rokVydani;
            PocetStran = pocetStran;
            Jazyk = jazyk;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var addBookDialog = new PridatKnihu();
            addBookDialog.ShowDialog();
        }
        private void EditBook_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
