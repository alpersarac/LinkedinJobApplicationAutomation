using Helper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinJAASerial
{
    public static class DatabaseConnector
    {

        private static string ConnectionString = "";

        static DatabaseConnector()
        {

            //string decodedConnectionString = BasicEncryption.DecryptConnectionString(ConnectionString);
            //string connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"]?.ConnectionString;
            ConnectionString = "Server=77.245.159.27;Database=LinkedinApplier;Uid=alper;Pwd=Sarac.4242;";
            ConnectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
        }

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
                                licenceTable.isonline = reader.GetBoolean("isonline");
                                licenceTable.macAddress = reader.GetString("macAddress");
                                licenceTable.expirydate = reader.GetDateTime("expirydate");

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
                                licenceTable.isonline = reader.GetBoolean("isonline");
                                licenceTable.macAddress = reader.GetString("macAddress");
                                licenceTable.expirydate = reader.GetDateTime("expirydate");
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

        public static LicenceTable GetLicenceTableBySerialKey(string serialkey, ref bool isConnectionOK)
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
                                licenceTable.isonline = reader.GetBoolean("isonline");
                                licenceTable.macAddress = reader.GetString("macAddress");
                                licenceTable.expirydate = reader.GetDateTime("expirydate");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred while retrieving LicenceTable by serial key: " + ex.Message);
                isConnectionOK = false;
                return licenceTable;
            }
            isConnectionOK = true;
            return licenceTable;
        }

        public static List<LicenceTable> SearchLicenceTableByEmail(string email)
        {
            List<LicenceTable> licenceTables = new List<LicenceTable>();

            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "SELECT * FROM LicenceTable WHERE email LIKE @email";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", $"%{email}%");

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
                                licenceTable.isonline = reader.GetBoolean("isonline");
                                licenceTable.macAddress = reader.GetString("macAddress");
                                licenceTable.expirydate = reader.GetDateTime("expirydate");

                                licenceTables.Add(licenceTable);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while searching LicenceTable by email: " + ex.Message);
            }

            return licenceTables;
        }

        public static List<LicenceTable> SearchLicenceTableBySerialKey(string serialkey)
        {
            List<LicenceTable> licenceTables = new List<LicenceTable>();

            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "SELECT * FROM LicenceTable WHERE serialkey LIKE @serialkey";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@serialkey", $"%{serialkey}%");

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
                                licenceTable.isonline = reader.GetBoolean("isonline");
                                licenceTable.macAddress = reader.GetString("macAddress");
                                licenceTable.expirydate = reader.GetDateTime("expirydate");

                                licenceTables.Add(licenceTable);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while searching LicenceTable by serial key: " + ex.Message);
            }

            return licenceTables;
        }

        public static int GetTotalActiveLicences()
        {
            int totalActiveLicences = 0;

            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM LicenceTable WHERE isactive = 1 AND isdeleted = 0";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        totalActiveLicences = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while getting total active licences: " + ex.Message);
            }

            return totalActiveLicences;
        }

        public static int GetTotalDeletedLicences()
        {
            int totalDeletedLicences = 0;

            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM LicenceTable WHERE isdeleted = 1";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        totalDeletedLicences = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while getting total deleted licences: " + ex.Message);
            }

            return totalDeletedLicences;
        }

        public static bool InsertLicenceTable(LicenceTable licenceTable)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "INSERT INTO LicenceTable (email, serialkey, isactive, isdeleted, isonline, macAddress, expirydate) VALUES (@email, @serialkey, @isactive, @isdeleted, @isonline, @macAddress, @expirydate)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", licenceTable.email);
                        command.Parameters.AddWithValue("@serialkey", licenceTable.serialkey);
                        command.Parameters.AddWithValue("@isactive", licenceTable.isactive);
                        command.Parameters.AddWithValue("@isdeleted", licenceTable.isdeleted);
                        command.Parameters.AddWithValue("@isonline", licenceTable.isonline);
                        command.Parameters.AddWithValue("@macAddress", licenceTable.macAddress);
                        command.Parameters.AddWithValue("@expirydate", licenceTable.expirydate);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while inserting LicenceTable: " + ex.Message);
                return false;
            }
            return true;
        }

        public static void UpdateLicenceTable(LicenceTable licenceTable)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "UPDATE LicenceTable SET email = @email, serialkey = @serialkey, isactive = @isactive, isdeleted = @isdeleted, isonline = @isonline, macAddress = @macAddress, expirydate = @expirydate WHERE id = @id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", licenceTable.id);
                        command.Parameters.AddWithValue("@email", licenceTable.email);
                        command.Parameters.AddWithValue("@serialkey", licenceTable.serialkey);
                        command.Parameters.AddWithValue("@isactive", licenceTable.isactive);
                        command.Parameters.AddWithValue("@isdeleted", licenceTable.isdeleted);
                        command.Parameters.AddWithValue("@isonline", licenceTable.isonline);
                        command.Parameters.AddWithValue("@macAddress", licenceTable.macAddress);
                        command.Parameters.AddWithValue("@expirydate", licenceTable.expirydate);

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

        public static void UpdateLicenceTableOnlineStatus(int id, bool isOnline)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "UPDATE LicenceTable SET isonline = @isonline WHERE id = @id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@isonline", isOnline);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating LicenceTable online status: " + ex.Message);
            }
        }
        public static string GetMacAddressById(int id)
        {
            string macAddress = null;

            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "SELECT macAddress FROM LicenceTable WHERE id = @id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            macAddress = Convert.ToString(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while getting MacAddress by ID: " + ex.Message);
            }

            return macAddress;
        }

        public static void SetMacAddressById(int id, string macAddress)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    string query = "UPDATE LicenceTable SET macAddress = @macAddress WHERE id = @id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@macAddress", macAddress);
                        command.Parameters.AddWithValue("@isactive", true);
                        command.Parameters.AddWithValue("@isonline", true);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while setting MacAddress by ID: " + ex.Message);
            }
        }

    }


}
