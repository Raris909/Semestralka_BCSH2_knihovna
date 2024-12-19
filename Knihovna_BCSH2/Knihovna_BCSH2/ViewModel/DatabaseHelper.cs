using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public List<Kniha> GetBooks()
        {
            string query = "SELECT k.Id, k.Nazev, k.Zanr, k.Vydavatel, k.RokVydani, k.PocetStran, k.Jazyk, k.AutorId, " +
                    "a.Jmeno, a.Prijmeni " +
                    "FROM Knihy k " +
                    "JOIN Autori a ON k.AutorId = a.Id;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);

                var books = new List<Kniha>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Kniha
                        {
                            Id = reader.GetInt32(0),
                            Nazev = reader.GetString(1),
                            Zanr = reader.GetString(2),
                            Vydavatel = reader.GetString(3),
                            RokVydani = reader.GetInt32(4),
                            PocetStran = reader.GetInt32(5),
                            Jazyk = reader.GetString(6),
                            AutorId = reader.GetInt32(7),
                            Autor = new Autor
                            {
                                Id = reader.GetInt32(7),
                                Jmeno = reader.GetString(8),
                                Prijmeni = reader.GetString(9)
                            }
                        });
                    }
                }
                return books;
            }
        }


        public void AddBook(Kniha kniha)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "INSERT INTO Knihy (Nazev, Zanr, Vydavatel, RokVydani, PocetStran, Jazyk, AutorId) " +
                    "VALUES (@Nazev, @Zanr, @Vydavatel, @RokVydani, @PocetStran, @Jazyk, @AutorId)", connection);

                command.Parameters.AddWithValue("@Nazev", kniha.Nazev);
                command.Parameters.AddWithValue("@Zanr", kniha.Zanr);
                command.Parameters.AddWithValue("@Vydavatel", kniha.Vydavatel);
                command.Parameters.AddWithValue("@RokVydani", kniha.RokVydani);
                command.Parameters.AddWithValue("@PocetStran", kniha.PocetStran);
                command.Parameters.AddWithValue("@Jazyk", kniha.Jazyk);
                command.Parameters.AddWithValue("@AutorId", kniha.AutorId);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateBook(Kniha kniha)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "UPDATE Knihy SET Nazev = @Nazev, Zanr = @Zanr, Vydavatel = @Vydavatel, " +
                    "RokVydani = @RokVydani, PocetStran = @PocetStran, Jazyk = @Jazyk, AutorId = @AutorId " +
                    "WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("@Nazev", kniha.Nazev);
                command.Parameters.AddWithValue("@Zanr", kniha.Zanr);
                command.Parameters.AddWithValue("@Vydavatel", kniha.Vydavatel);
                command.Parameters.AddWithValue("@RokVydani", kniha.RokVydani);
                command.Parameters.AddWithValue("@PocetStran", kniha.PocetStran);
                command.Parameters.AddWithValue("@Jazyk", kniha.Jazyk);
                command.Parameters.AddWithValue("@AutorId", kniha.AutorId);
                command.Parameters.AddWithValue("@Id", kniha.Id);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteBook(Kniha book)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("DELETE FROM Knihy WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", book.Id);
                command.ExecuteNonQuery();
            }
        }

        public List<Zakaznik> GetZakaznici()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Zakaznici", connection);

                var zakaznici = new List<Zakaznik>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        zakaznici.Add(new Zakaznik
                        {
                            Id = reader.GetInt32(0),
                            Jmeno = reader.GetString(1),
                            Prijmeni = reader.GetString(2),
                            Adresa = reader.GetString(3),
                            Telefon = reader.GetString(4),
                            Email = reader.GetString(5)
                        });
                    }
                }
                return zakaznici;
            }
        }

        public void AddZakaznik(Zakaznik zakaznik)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "INSERT INTO Zakaznici (Jmeno, Prijmeni, Adresa, Telefon, Email) " +
                    "VALUES (@Jmeno, @Prijmeni, @Adresa, @Telefon, @Email)", connection);

                command.Parameters.AddWithValue("@Jmeno", zakaznik.Jmeno);
                command.Parameters.AddWithValue("@Prijmeni", zakaznik.Prijmeni);
                command.Parameters.AddWithValue("@Adresa", zakaznik.Adresa);
                command.Parameters.AddWithValue("@Telefon", zakaznik.Telefon);
                command.Parameters.AddWithValue("@Email", zakaznik.Email);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateZakaznik(Zakaznik zakaznik)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(
                    "UPDATE Zakaznici SET Jmeno = @Jmeno, Prijmeni = @Prijmeni, Adresa = @Adresa, " +
                    "Telefon = @Telefon, Email = @Email WHERE Id = @Id", connection);

                command.Parameters.AddWithValue("@Jmeno", zakaznik.Jmeno);
                command.Parameters.AddWithValue("@Prijmeni", zakaznik.Prijmeni);
                command.Parameters.AddWithValue("@Adresa", zakaznik.Adresa);
                command.Parameters.AddWithValue("@Telefon", zakaznik.Telefon);
                command.Parameters.AddWithValue("@Email", zakaznik.Email);
                command.Parameters.AddWithValue("@Id", zakaznik.Id);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteZakaznik(int id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("DELETE FROM Zakaznici WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

        public void AddZapujcka(Zapujcka zapujcka)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                var command = new SQLiteCommand(
                    "INSERT INTO Zapujcky (DatumZapujcky, DatumVraceni, KnihaId, ZakaznikId) VALUES (@DatumZapujcky, @DatumVraceni, @KnihaId, @ZakaznikId)",
                    connection);

                command.Parameters.AddWithValue("@DatumZapujcky", zapujcka.DatumZapujcky);

                if (zapujcka.DatumVraceni == null)
                {
                    command.Parameters.AddWithValue("@DatumVraceni", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DatumVraceni", zapujcka.DatumVraceni);
                }

                command.Parameters.AddWithValue("@KnihaId", zapujcka.KnihaId);
                command.Parameters.AddWithValue("@ZakaznikId", zapujcka.ZakaznikId);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateZapujcka(Zapujcka zapujcka)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("UPDATE Zapujcky SET DatumZapujcky = @DatumZapujcky, DatumVraceni = @DatumVraceni, KnihaId = @KnihaId, ZakaznikId = @ZakaznikId WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@DatumZapujcky", zapujcka.DatumZapujcky);
                command.Parameters.AddWithValue("@DatumVraceni", zapujcka.DatumVraceni);
                command.Parameters.AddWithValue("@KnihaId", zapujcka.KnihaId);
                command.Parameters.AddWithValue("@ZakaznikId", zapujcka.ZakaznikId);
                command.Parameters.AddWithValue("@Id", zapujcka.Id);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteZapujcka(Zapujcka zapujcka)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("DELETE FROM Zapujcky WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", zapujcka.Id);
                command.ExecuteNonQuery();
            }
        }

        public List<Zapujcka> GetAllZapujcky()
        {
            var zapujcky = new List<Zapujcka>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(
                    "SELECT z.Id, z.DatumZapujcky, z.DatumVraceni, k.Id AS KnihaId, k.Nazev AS KnihaNazev, " +
                    "zak.Id AS ZakaznikId, zak.Jmeno || ' ' || zak.Prijmeni AS ZakaznikFullName " +
                    "FROM Zapujcky z " +
                    "JOIN Knihy k ON z.KnihaId = k.Id " +
                    "JOIN Zakaznici zak ON z.ZakaznikId = zak.Id", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        zapujcky.Add(new Zapujcka
                        {
                            Id = reader.GetInt32(0), // z.Id
                            DatumZapujcky = reader.GetDateTime(1), // z.DatumZapujcky
                            DatumVraceni = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2), // z.DatumVraceni
                            Kniha = new Kniha
                            {
                                Id = reader.GetInt32(3), // k.Id (KnihaId)
                                Nazev = reader.GetString(4) // k.Nazev (KnihaNazev)
                            },
                            Zakaznik = new Zakaznik
                            {
                                Id = reader.GetInt32(5), // zak.Id (ZakaznikId)
                                FullName = reader.GetString(6) // zak.Jmeno || ' ' || zak.Prijmeni (ZakaznikFullName)
                            },
                            KnihaNazev = reader.GetString(4), // Alternativně: k.Nazev
                            FullName = reader.GetString(6) // Alternativně: zak.Jmeno || ' ' || zak.Prijmeni
                        });
                    }
                }
            }
            return zapujcky;
        }


        public List<Kniha> GetKnihy()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var knihy = new List<Kniha>();
                using (var command = new SQLiteCommand("SELECT * FROM Knihy", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        knihy.Add(new Kniha
                        {
                            Id = reader.GetInt32(0),
                            Nazev = reader.GetString(1)
                        });
                    }
                }
                return knihy;
            }
        }

        public List<Zapujcka> GetActiveZapujckyForZakaznik(int zakaznikId)
        {
            var zapujcky = new List<Zapujcka>();

            // SQLite připojení
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // SQL dotaz pro získání nevrácených zápůjček
                string query = @"
            SELECT Id, DatumZapujcky, DatumVraceni, KnihaId, ZakaznikId
            FROM Zapujcky
            WHERE ZakaznikId = @ZakaznikId AND DatumVraceni IS NULL";

                using (var command = new SQLiteCommand(query, connection))
                {
                    // Parametr SQL dotazu
                    command.Parameters.AddWithValue("@ZakaznikId", zakaznikId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Naplnění objektu Zapujcka
                            var zapujcka = new Zapujcka
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                DatumZapujcky = reader.GetDateTime(reader.GetOrdinal("DatumZapujcky")),
                                DatumVraceni = reader.IsDBNull(reader.GetOrdinal("DatumVraceni"))
                                               ? (DateTime?)null
                                               : reader.GetDateTime(reader.GetOrdinal("DatumVraceni")),
                                KnihaId = reader.GetInt32(reader.GetOrdinal("KnihaId")),
                                ZakaznikId = reader.GetInt32(reader.GetOrdinal("ZakaznikId"))
                            };

                            zapujcky.Add(zapujcka);
                        }
                    }
                }
            }

            return zapujcky;
        }


    }
}
