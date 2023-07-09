using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinJAASerial
{
    public class DatabaseConnector
    {
        private const string ConnectionString = "Server=sql7.freesqldatabase.com;Port=3306;Database=sql7631531;Uid=sql7631531;Pwd=SqDbdrvIsn;";

        public static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public static List<LicenceTable> RetrieveLicenceTables()
        {
            List<LicenceTable> licenceTables = new List<LicenceTable>();

            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "SELECT * FROM LicenceTable WHERE isdeleted = 0";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LicenceTable licenceTable = new LicenceTable();
                                licenceTable.id = reader.GetInt32("id");
                                licenceTable.email = reader.GetString("email");
                                licenceTable.serialkey = reader.GetString("serialkey");
                                licenceTable.isactive = reader.GetBoolean("isactive");
                                licenceTable.isdeleted = reader.GetBoolean("isdeleted");

                                licenceTables.Add(licenceTable);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving LicenceTables: " + ex.Message);
            }

            return licenceTables;
        }

        public static LicenceTable GetLicenceTableByEmail(string email)
        {
            LicenceTable licenceTable = null;

            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "SELECT * FROM LicenceTable WHERE email = @email AND isdeleted = 0";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                licenceTable = new LicenceTable();
                                licenceTable.id = reader.GetInt32("id");
                                licenceTable.email = reader.GetString("email");
                                licenceTable.serialkey = reader.GetString("serialkey");
                                licenceTable.isactive = reader.GetBoolean("isactive");
                                licenceTable.isdeleted = reader.GetBoolean("isdeleted");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving LicenceTable by email: " + ex.Message);
            }

            return licenceTable;
        }

        public static LicenceTable GetLicenceTableBySerialKey(string serialkey)
        {
            LicenceTable licenceTable = null;

            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "SELECT * FROM LicenceTable WHERE serialkey = @serialkey AND isdeleted = 0";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@serialkey", serialkey);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                licenceTable = new LicenceTable();
                                licenceTable.id = reader.GetInt32("id");
                                licenceTable.email = reader.GetString("email");
                                licenceTable.serialkey = reader.GetString("serialkey");
                                licenceTable.isactive = reader.GetBoolean("isactive");
                                licenceTable.isdeleted = reader.GetBoolean("isdeleted");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving LicenceTable by serial key: " + ex.Message);
            }

            return licenceTable;
        }

        public static void InsertLicenceTable(LicenceTable licenceTable)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "INSERT INTO LicenceTable (email, serialkey, isactive, isdeleted) VALUES (@email, @serialkey, @isactive, @isdeleted)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", licenceTable.email);
                        command.Parameters.AddWithValue("@serialkey", licenceTable.serialkey);
                        command.Parameters.AddWithValue("@isactive", licenceTable.isactive);
                        command.Parameters.AddWithValue("@isdeleted", licenceTable.isdeleted);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while inserting LicenceTable: " + ex.Message);
            }
        }

        public static void UpdateLicenceTable(LicenceTable licenceTable)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "UPDATE LicenceTable SET email = @email, serialkey = @serialkey, isactive = @isactive, isdeleted = @isdeleted WHERE id = @id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", licenceTable.id);
                        command.Parameters.AddWithValue("@email", licenceTable.email);
                        command.Parameters.AddWithValue("@serialkey", licenceTable.serialkey);
                        command.Parameters.AddWithValue("@isactive", licenceTable.isactive);
                        command.Parameters.AddWithValue("@isdeleted", licenceTable.isdeleted);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating LicenceTable: " + ex.Message);
            }
        }

        public static void DeleteLicenceTable(int id)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "UPDATE LicenceTable SET isdeleted = 1 WHERE id = @id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting LicenceTable: " + ex.Message);
            }
        }
    }
}
