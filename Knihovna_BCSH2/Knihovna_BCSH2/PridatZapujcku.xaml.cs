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
    /// Interaction logic for PridatZapujcku.xaml
    /// </summary>
    public partial class PridatZapujcku : Window
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private Zapujcka currentLoan;
        private List<Kniha> availableBooks;
        private List<Zakaznik> availableCustomers;

        public PridatZapujcku(Zapujcka zapujcka = null)
        {
            InitializeComponent();

            try
            {
                // Předpokládáme, že GetKnihy a GetZakaznici jsou metody, které vrací seznamy objektů Kniha a Zakaznik
                availableBooks = dbHelper.GetKnihy(); // Seznam knih
                availableCustomers = dbHelper.GetZakaznici(); // Seznam zákazníků
                foreach (var customer in availableCustomers)
                {
                    customer.FullName = $"{customer.Jmeno} {customer.Prijmeni}"; // Vytvoření zobrazeného jména
                }
                ZakaznikComboBox.ItemsSource = availableCustomers;
                KnihaComboBox.ItemsSource = availableBooks;

                if (zapujcka != null)
                {
                    // Pokud je předána existující kniha, nastavíme hodnoty pro úpravu
                    currentLoan = zapujcka;
                    DatumZapujckyPicker.SelectedDate = currentLoan.DatumZapujcky;
                    DatumVraceniPicker.SelectedDate = currentLoan.DatumVraceni;

                    // Nastavení autora v ComboBox
                    ZakaznikComboBox.SelectedValue = currentLoan.ZakaznikId;
                    KnihaComboBox.SelectedValue = currentLoan.KnihaId;

                    this.Title = "Upravit zápůjčku";
                }
                else
                {
                    this.Title = "Přidat zápůjčku";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při načítání dat: {ex.Message}");
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime datumZapujcky = DatumZapujckyPicker.SelectedDate ?? DateTime.Now;
            DateTime? datumVraceni = DatumVraceniPicker.SelectedDate;
            // Kontrola, zda jsou všechna povinná pole vyplněna
            if (DatumZapujckyPicker.SelectedDate == null || KnihaComboBox.SelectedItem == null || ZakaznikComboBox.SelectedItem == null)
            {
                MessageBox.Show("Vyplňte všechna povinná pole!", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (KnihaComboBox.SelectedValue == null || ZakaznikComboBox.SelectedValue == null)
            {
                MessageBox.Show("Vyberte autora a zákazníka z nabídky.");
                return;
            }

            int knihaId = (int)KnihaComboBox.SelectedValue;
            int zakaznikId = (int)ZakaznikComboBox.SelectedValue;

            try
            {
                if (currentLoan == null)
                {
                    var zapujcka = new Zapujcka
                    {
                        DatumZapujcky = datumZapujcky, // Použití aktuálního data, pokud není vybráno
                        DatumVraceni = datumVraceni, // Datum vrácení může být null
                        KnihaId = knihaId, // Použití ID knihy
                        ZakaznikId = zakaznikId // Použití ID zákazníka
                    };

                    dbHelper.AddZapujcka(zapujcka);
                    MessageBox.Show("Zápůjčka byla úspěšně přidána.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    currentLoan.DatumZapujcky = datumZapujcky;
                    currentLoan.DatumVraceni = datumVraceni;
                    currentLoan.KnihaId = knihaId;
                    currentLoan.ZakaznikId = zakaznikId;

                    dbHelper.UpdateZapujcka(currentLoan);
                    MessageBox.Show("Zápůjčka byla úspěšně upravena.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo k chybě při přidávání zápůjčky: {ex.Message}", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Zavření okna bez uložení
        }
    }
}
