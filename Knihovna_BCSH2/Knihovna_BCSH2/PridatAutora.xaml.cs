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
    /// Interaction logic for PridatAutora.xaml
    /// </summary>
    public partial class PridatAutora : Window
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private Autor currentAuthor;
        public PridatAutora(Autor author = null)
        {
            InitializeComponent();
            if (author != null)
            {
                // Pokud je předán existující autor, nastavíme hodnoty pro úpravu
                currentAuthor = author;
                JmenoTextBox.Text = currentAuthor.Jmeno;
                PrijmeniTextBox.Text = currentAuthor.Prijmeni;
                DatumNarozeniTextBox.Text = currentAuthor.DatumNarozeni.ToString("yyyy-MM-dd");
                ZemeTextBox.Text = currentAuthor.Zeme;
                this.Title = "Upravit autora";  // Změníme název okna na "Upravit autora"
            }
            else
            {
                this.Title = "Přidat autora";  // Název okna pro přidání autora
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Získání údajů z textových polí
            string jmeno = JmenoTextBox.Text;
            string prijmeni = PrijmeniTextBox.Text;
            string datumNarozeniStr = DatumNarozeniTextBox.Text;
            string zeme = ZemeTextBox.Text;

            // Kontrola, že všechny povinné údaje byly zadány
            if (string.IsNullOrEmpty(jmeno) || string.IsNullOrEmpty(prijmeni) || string.IsNullOrEmpty(datumNarozeniStr) || string.IsNullOrEmpty(zeme))
            {
                MessageBox.Show("Prosím, vyplňte všechny povinné údaje.");
                return;
            }

            DateTime datumNarozeni;
            if (!DateTime.TryParse(datumNarozeniStr, out datumNarozeni))
            {
                MessageBox.Show("Neplatný formát data narození.");
                return;
            }

            try
            {
                if (currentAuthor == null) // Přidání nového autora
                {
                    // Vytvoření nového autora a přidání do databáze
                    var newAuthor = new Autor
                    {
                        Jmeno = jmeno,
                        Prijmeni = prijmeni,
                        DatumNarozeni = datumNarozeni,
                        Zeme = zeme
                    };

                    dbHelper.AddAuthor(newAuthor);
                    MessageBox.Show("Autor byl úspěšně přidán.");
                }
                else // Úprava existujícího autora
                {
                    // Úprava existujícího autora
                    currentAuthor.Jmeno = jmeno;
                    currentAuthor.Prijmeni = prijmeni;
                    currentAuthor.DatumNarozeni = datumNarozeni;
                    currentAuthor.Zeme = zeme;

                    dbHelper.UpdateAuthor(currentAuthor);
                    MessageBox.Show("Autor byl úspěšně upraven.");
                }

                this.DialogResult = true;  // Okno bude zavřeno, protože změny byly úspěšné
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo k chybě při přidávání nebo úpravě autora: {ex.Message}");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
