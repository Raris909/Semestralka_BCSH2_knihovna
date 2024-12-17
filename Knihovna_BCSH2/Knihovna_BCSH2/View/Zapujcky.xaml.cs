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
        private DatabaseHelper dbHelper = new DatabaseHelper();
        public Zapujcky()
        {
            InitializeComponent();
            LoadZapujcky();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void AddLoan_Click(object sender, RoutedEventArgs e)
        {
            var addLoanDialog = new PridatZapujcku();
            if (addLoanDialog.ShowDialog() == true)
            {
                LoadZapujcky();
            }
        }
        private void EditLoan_Click(object sender, RoutedEventArgs e)
        {
            if (LoansDataGrid.SelectedItem is Zapujcka selectedLoan)
            {
                var editLoanWindow = new PridatZapujcku(selectedLoan);
                if (editLoanWindow.ShowDialog() == true)
                {
                    LoadZapujcky();
                }
            }
            else
            {
                MessageBox.Show("Vyberte zápůjčku k úpravě.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteLoan_Click(object sender, RoutedEventArgs e)
        {
            if (LoansDataGrid.SelectedItem is Zapujcka selectedLoan)
            {
                if (MessageBox.Show("Opravdu chcete odstranit tuto zápůjčku?", "Potvrzení", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    dbHelper.DeleteZapujcka(selectedLoan);
                    MessageBox.Show("Zápůjčka byla úspěšně odstraněna.", "Úspěch", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadZapujcky();
                }
            }
            else
            {
                MessageBox.Show("Vyberte zápůjčku k odstranění.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LoadZapujcky()
        {
            var loans = dbHelper.GetAllZapujcky();
            LoansDataGrid.ItemsSource = loans;
        }
    }
}
