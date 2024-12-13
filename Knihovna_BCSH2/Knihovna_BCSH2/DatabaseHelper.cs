using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna_BCSH2
{
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=MyDatabase.db;Version=3;";

        // Načtení seznamu autorů
        public List<Autor> GetAllAuthors()
        {
            var authors = new List<Autor>();

            string query = "SELECT Id, Jmeno, Prijmeni, DatumNarozeni, Zeme FROM Autori;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            authors.Add(new Autor
                            {
                                Id = reader.GetInt32(0),
                                Jmeno = reader.GetString(1),
                                Prijmeni = reader.GetString(2),
                                DatumNarozeni = reader.GetDateTime(3),
                                Zeme = reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return authors;
        }

        // Přidání nového autora
        public void AddAuthor(Autor autor)
        {
            string query = "INSERT INTO Autori (Jmeno, Prijmeni, DatumNarozeni, Zeme) VALUES (@Jmeno, @Prijmeni, @DatumNarozeni, @Zeme);";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Jmeno", autor.Jmeno);
                    command.Parameters.AddWithValue("@Prijmeni", autor.Prijmeni);
                    command.Parameters.AddWithValue("@DatumNarozeni", autor.DatumNarozeni);
                    command.Parameters.AddWithValue("@Zeme", autor.Zeme);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Úprava existujícího autora
        public void UpdateAuthor(Autor autor)
        {
            string query = "UPDATE Autori SET Jmeno = @Jmeno, Prijmeni = @Prijmeni, DatumNarozeni = @DatumNarozeni, Zeme = @Zeme WHERE Id = @Id;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", autor.Id);
                    command.Parameters.AddWithValue("@Jmeno", autor.Jmeno);
                    command.Parameters.AddWithValue("@Prijmeni", autor.Prijmeni);
                    command.Parameters.AddWithValue("@DatumNarozeni", autor.DatumNarozeni);
                    command.Parameters.AddWithValue("@Zeme", autor.Zeme);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Odstranění autora
        public void DeleteAuthor(int id)
        {
            string query = "DELETE FROM Autori WHERE Id = @Id;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
