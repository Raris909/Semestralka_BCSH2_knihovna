using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Knihovna_BCSH2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            string connectionString = "Data Source=MyDatabase.db;Version=3;";

            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Autori (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Jmeno TEXT NOT NULL,
                Prijmeni TEXT NOT NULL,
                DatumNarozeni DATE NOT NULL,
                Zeme TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Knihy (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nazev TEXT NOT NULL,
                Zanr TEXT NOT NULL,
                Vydavatel TEXT NOT NULL,
                RokVydani INTEGER NOT NULL,
                PocetStran INTEGER NOT NULL,
                Jazyk TEXT NOT NULL,
                AutorId INTEGER NOT NULL,
                FOREIGN KEY (AutorId) REFERENCES Autori(Id)
            );

            CREATE TABLE IF NOT EXISTS Zakaznici (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Jmeno TEXT NOT NULL,
                Prijmeni TEXT NOT NULL,
                Adresa TEXT NOT NULL,
                Telefon TEXT NOT NULL,
                Email TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Zapujcky (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                DatumZapujcky DATE NOT NULL, 
                DatumVraceni DATE,
                KnihaId INTEGER NOT NULL,
                ZakaznikId INTEGER NOT NULL,
                FOREIGN KEY (KnihaId) REFERENCES Knihy(Id),
                FOREIGN KEY (ZakaznikId) REFERENCES Zakaznici(Id)
            );

            ";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Knihy newWindow = new Knihy();
            newWindow.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Autori newWindow = new Autori();
            newWindow.Show();
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Zapujcky newWindow = new Zapujcky();
            newWindow.Show();
            Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Zakaznici newWindow = new Zakaznici();
            newWindow.Show();
            Close();
        }
    }
}
