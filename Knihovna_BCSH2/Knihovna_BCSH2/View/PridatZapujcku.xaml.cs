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

        public int SelectedKnihaId { get; set; }
        public int SelectedZakaznikId { get; set; }
        public DateTime DatumZapujcky { get; set; }
        public DateTime? DatumVraceni { get; set; }

        public PridatZapujcku(Zapujcka zapujcka = null)
        {
            InitializeComponent();

            try
            {
                availableBooks = dbHelper.GetKnihy();
                availableCustomers = dbHelper.GetZakaznici();

                foreach (var customer in availableCustomers)
                {
                    customer.FullName = $"{customer.Jmeno} {customer.Prijmeni}";
                }

                ZakaznikComboBox.ItemsSource = availableCustomers;
                KnihaComboBox.ItemsSource = availableBooks;

                if (zapujcka != null)
                {
                    currentLoan = zapujcka; // Nastavení existující zápůjčky
                    DatumZapujckyPicker.SelectedDate = currentLoan.DatumZapujcky;
                    DatumVraceniPicker.SelectedDate = currentLoan.DatumVraceni;

                    ZakaznikComboBox.SelectedValue = currentLoan.ZakaznikId;
                    KnihaComboBox.SelectedValue = currentLoan.KnihaId;

                    Title = "Upravit zápůjčku";
                }
                else
                {
                    Title = "Přidat zápůjčku";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při načítání dat: {ex.Message}", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Kontrola povinných polí
            if (DatumZapujckyPicker.SelectedDate == null || KnihaComboBox.SelectedItem == null || ZakaznikComboBox.SelectedItem == null)
            {
                MessageBox.Show("Vyplňte všechna povinná pole!", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Výběr hodnot z UI
            SelectedKnihaId = (int)KnihaComboBox.SelectedValue;
            SelectedZakaznikId = (int)ZakaznikComboBox.SelectedValue;
            DatumZapujcky = DatumZapujckyPicker.SelectedDate ?? DateTime.Now;
            DatumVraceni = DatumVraceniPicker.SelectedDate;

            try
            {
                if (currentLoan == null)
                {
                    // Přidání nové zápůjčky
                    var zapujcka = new Zapujcka
                    {
                        DatumZapujcky = DatumZapujcky,
                        DatumVraceni = DatumVraceni,
                        KnihaId = SelectedKnihaId,
                        ZakaznikId = SelectedZakaznikId
                    };

                }
                else
                {
                    // Úprava existující zápůjčky
                    currentLoan.DatumZapujcky = DatumZapujcky;
                    currentLoan.DatumVraceni = DatumVraceni;
                    currentLoan.KnihaId = SelectedKnihaId;
                    currentLoan.ZakaznikId = SelectedZakaznikId;

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
            Close();
        }
    }
}
