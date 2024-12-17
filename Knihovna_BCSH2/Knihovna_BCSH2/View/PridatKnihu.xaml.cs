﻿using System;
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
    /// Interaction logic for PridatKnihu.xaml
    /// </summary>
    public partial class PridatKnihu : Window
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private Kniha currentBook;
        private List<Autor> availableAuthors;

        public PridatKnihu(Kniha book = null)
        {
            InitializeComponent();

            try
            {
                availableAuthors = dbHelper.GetAllAuthors();
                foreach (var author in availableAuthors)
                {
                    author.FullName = $"{author.Jmeno} {author.Prijmeni}";
                }
                AutorComboBox.ItemsSource = availableAuthors;

                if (book != null)
                {
                    currentBook = book;
                    NazevTextBox.Text = currentBook.Nazev;
                    ZanrTextBox.Text = currentBook.Zanr;
                    VydavatelTextBox.Text = currentBook.Vydavatel;
                    RokVydaniTextBox.Text = currentBook.RokVydani.ToString();
                    PocetStranTextBox.Text = currentBook.PocetStran.ToString();
                    JazykTextBox.Text = currentBook.Jazyk;
                    AutorComboBox.SelectedValue = currentBook.AutorId;

                    Title = "Upravit knihu";
                }
                else
                {
                    Title = "Přidat knihu";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo k chybě při načítání autorů: {ex.Message}");
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string nazev = NazevTextBox.Text;
            string zanr = ZanrTextBox.Text;
            string vydavatel = VydavatelTextBox.Text;
            string rokVydaniStr = RokVydaniTextBox.Text;
            string pocetStranStr = PocetStranTextBox.Text;
            string jazyk = JazykTextBox.Text;

            if (AutorComboBox.SelectedValue == null)
            {
                MessageBox.Show("Vyberte autora z nabídky.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int autorId = (int)AutorComboBox.SelectedValue;

            if (!int.TryParse(rokVydaniStr, out int rokVydani) || !int.TryParse(pocetStranStr, out int pocetStran))
            {
                MessageBox.Show("Rok vydání a počet stran musí být platná čísla.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (currentBook == null)
                {
                    var newBook = new Kniha
                    {
                        Nazev = nazev,
                        Zanr = zanr,
                        Vydavatel = vydavatel,
                        RokVydani = rokVydani,
                        PocetStran = pocetStran,
                        Jazyk = jazyk,
                        AutorId = autorId
                    };

                    dbHelper.AddBook(newBook);
                    MessageBox.Show("Kniha byla úspěšně přidána.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    currentBook.Nazev = nazev;
                    currentBook.Zanr = zanr;
                    currentBook.Vydavatel = vydavatel;
                    currentBook.RokVydani = rokVydani;
                    currentBook.PocetStran = pocetStran;
                    currentBook.Jazyk = jazyk;
                    currentBook.AutorId = autorId;

                    dbHelper.UpdateBook(currentBook);
                    MessageBox.Show("Kniha byla úspěšně upravena.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo k chybě při přidávání nebo úpravě knihy: {ex.Message}");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}