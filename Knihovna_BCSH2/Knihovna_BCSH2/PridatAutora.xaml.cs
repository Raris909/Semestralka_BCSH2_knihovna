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
                currentAuthor = author;
                JmenoTextBox.Text = currentAuthor.Jmeno;
                PrijmeniTextBox.Text = currentAuthor.Prijmeni;
                DatumNarozeniTextBox.Text = currentAuthor.DatumNarozeni.ToString("yyyy-MM-dd");
                ZemeTextBox.Text = currentAuthor.Zeme;
                Title = "Upravit autora";
            }
            else
            {
                Title = "Přidat autora";
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string jmeno = JmenoTextBox.Text;
            string prijmeni = PrijmeniTextBox.Text;
            string datumNarozeniStr = DatumNarozeniTextBox.Text;
            string zeme = ZemeTextBox.Text;

            if (string.IsNullOrEmpty(jmeno) || string.IsNullOrEmpty(prijmeni) || string.IsNullOrEmpty(datumNarozeniStr) || string.IsNullOrEmpty(zeme))
            {
                MessageBox.Show("Vyplňte všechny povinné údaje.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime datumNarozeni;
            if (!DateTime.TryParse(datumNarozeniStr, out datumNarozeni))
            {
                MessageBox.Show("Neplatný formát data narození.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (currentAuthor == null)
                {
                    var newAuthor = new Autor
                    {
                        Jmeno = jmeno,
                        Prijmeni = prijmeni,
                        DatumNarozeni = datumNarozeni,
                        Zeme = zeme
                    };

                    dbHelper.AddAuthor(newAuthor);
                    MessageBox.Show("Autor byl úspěšně přidán.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    currentAuthor.Jmeno = jmeno;
                    currentAuthor.Prijmeni = prijmeni;
                    currentAuthor.DatumNarozeni = datumNarozeni;
                    currentAuthor.Zeme = zeme;

                    dbHelper.UpdateAuthor(currentAuthor);
                    MessageBox.Show("Autor byl úspěšně upraven.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo k chybě při přidávání nebo úpravě autora: {ex.Message}", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
