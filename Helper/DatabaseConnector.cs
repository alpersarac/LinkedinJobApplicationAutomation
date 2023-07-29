using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;


namespace LinkedinJAASerial
{
    public static class DatabaseConnector
    {

        private static string ConnectionString = "Vhuyhu=10.571.480.64;Gdwdedvh=OlqnhglqDssolhu;Xvhu Lg=vd;Sdvvzrug=Vdudf.7575;";

        static DatabaseConnector()
        {
            ConnectionString = BasicEncryption.DecryptConnectionString(ConnectionString);
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public static List<LicenceTable> RetrieveLicenceTables()
        {
            List<LicenceTable> licenceTables = new List<LicenceTable>();

            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT * FROM LicenceTable WHERE isdeleted = 0";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LicenceTable licenceTable = new LicenceTable();
                                licenceTable.id = reader.GetInt32(reader.GetOrdinal("id"));
                                licenceTable.email = reader.GetString(reader.GetOrdinal("email"));
                                licenceTable.serialkey = reader.GetString(reader.GetOrdinal("serialkey"));
                                licenceTable.isactive = reader.GetBoolean(reader.GetOrdinal("isactive"));
                                licenceTable.isdeleted = reader.GetBoolean(reader.GetOrdinal("isdeleted"));
                                licenceTable.isonline = reader.GetBoolean(reader.GetOrdinal("isonline"));
                                licenceTable.macAddress = reader.GetString(reader.GetOrdinal("macAddress"));
                                licenceTable.expirydate = reader.GetDateTime(reader.GetOrdinal("expirydate"));
                                licenceTable.isinfoextrator = reader.GetBoolean(reader.GetOrdinal("isinfoextrator"));
                                licenceTable.lastonlinedate = reader.GetNullableDateTime("lastonlinedate"); 
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

        public static DateTime? GetNullableDateTime(this SqlDataReader reader, string columnName)
        {
            int columnIndex = reader.GetOrdinal(columnName);
            if (!reader.IsDBNull(columnIndex))
            {
                return reader.GetDateTime(columnIndex);
            }

            return null;
        }

        public static LicenceTable GetLicenceTableByEmail(string email)
        {
            LicenceTable licenceTable = null;

            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT * FROM LicenceTable WHERE email = @email AND isdeleted = 0";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                licenceTable = new LicenceTable();
                                licenceTable.id = reader.GetInt32(reader.GetOrdinal("id"));
                                licenceTable.email = reader.GetString(reader.GetOrdinal("email"));
                                licenceTable.serialkey = reader.GetString(reader.GetOrdinal("serialkey"));
                                licenceTable.isactive = reader.GetBoolean(reader.GetOrdinal("isactive"));
                                licenceTable.isdeleted = reader.GetBoolean(reader.GetOrdinal("isdeleted"));
                                licenceTable.isonline = reader.GetBoolean(reader.GetOrdinal("isonline"));
                                licenceTable.macAddress = reader.GetString(reader.GetOrdinal("macAddress"));
                                licenceTable.expirydate = reader.GetDateTime(reader.GetOrdinal("expirydate"));
                                licenceTable.isinfoextrator = reader.GetBoolean(reader.GetOrdinal("isinfoextrator"));
                                licenceTable.lastonlinedate = reader.GetNullableDateTime("lastonlinedate"); 
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
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT * FROM LicenceTable WHERE serialkey = @serialkey AND isdeleted = 0";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@serialkey", serialkey);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                licenceTable = new LicenceTable();
                                licenceTable.id = reader.GetInt32(reader.GetOrdinal("id"));
                                licenceTable.email = reader.GetString(reader.GetOrdinal("email"));
                                licenceTable.serialkey = reader.GetString(reader.GetOrdinal("serialkey"));
                                licenceTable.isactive = reader.GetBoolean(reader.GetOrdinal("isactive"));
                                licenceTable.isdeleted = reader.GetBoolean(reader.GetOrdinal("isdeleted"));
                                licenceTable.isonline = reader.GetBoolean(reader.GetOrdinal("isonline"));
                                licenceTable.macAddress = reader.GetString(reader.GetOrdinal("macAddress"));
                                licenceTable.expirydate = reader.GetDateTime(reader.GetOrdinal("expirydate"));
                                licenceTable.isinfoextrator = reader.GetBoolean(reader.GetOrdinal("isinfoextrator"));
                                licenceTable.lastonlinedate = reader.GetNullableDateTime("lastonlinedate");

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
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT * FROM LicenceTable WHERE email LIKE @email";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", $"%{email}%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LicenceTable licenceTable = new LicenceTable();
                                licenceTable.id = reader.GetInt32(reader.GetOrdinal("id"));
                                licenceTable.email = reader.GetString(reader.GetOrdinal("email"));
                                licenceTable.serialkey = reader.GetString(reader.GetOrdinal("serialkey"));
                                licenceTable.isactive = reader.GetBoolean(reader.GetOrdinal("isactive"));
                                licenceTable.isdeleted = reader.GetBoolean(reader.GetOrdinal("isdeleted"));
                                licenceTable.isonline = reader.GetBoolean(reader.GetOrdinal("isonline"));
                                licenceTable.macAddress = reader.GetString(reader.GetOrdinal("macAddress"));
                                licenceTable.expirydate = reader.GetDateTime(reader.GetOrdinal("expirydate"));
                                licenceTable.isinfoextrator = reader.GetBoolean(reader.GetOrdinal("isinfoextrator"));
                                licenceTable.lastonlinedate = reader.GetNullableDateTime("lastonlinedate");


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
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT * FROM LicenceTable WHERE serialkey LIKE @serialkey";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@serialkey", $"%{serialkey}%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                LicenceTable licenceTable = new LicenceTable();
                                licenceTable.id = reader.GetInt32(reader.GetOrdinal("id"));
                                licenceTable.email = reader.GetString(reader.GetOrdinal("email"));
                                licenceTable.serialkey = reader.GetString(reader.GetOrdinal("serialkey"));
                                licenceTable.isactive = reader.GetBoolean(reader.GetOrdinal("isactive"));
                                licenceTable.isdeleted = reader.GetBoolean(reader.GetOrdinal("isdeleted"));
                                licenceTable.isonline = reader.GetBoolean(reader.GetOrdinal("isonline"));
                                licenceTable.macAddress = reader.GetString(reader.GetOrdinal("macAddress"));
                                licenceTable.expirydate = reader.GetDateTime(reader.GetOrdinal("expirydate"));
                                licenceTable.isinfoextrator = reader.GetBoolean(reader.GetOrdinal("isinfoextrator"));
                                licenceTable.lastonlinedate = reader.GetNullableDateTime("lastonlinedate");

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
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM LicenceTable WHERE isactive = 1 AND isdeleted = 0";
                    using (SqlCommand command = new SqlCommand(query, connection))
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
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM LicenceTable WHERE isdeleted = 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
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
                using (SqlConnection connection = GetConnection())
                {
                    string query = "INSERT INTO LicenceTable (email, serialkey, isactive, isdeleted, isonline, macAddress, expirydate, isinfoextrator) VALUES (@email, @serialkey, @isactive, @isdeleted, @isonline, @macAddress, @expirydate, @isinfoextrator)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", licenceTable.email);
                        command.Parameters.AddWithValue("@serialkey", licenceTable.serialkey);
                        command.Parameters.AddWithValue("@isactive", licenceTable.isactive);
                        command.Parameters.AddWithValue("@isdeleted", licenceTable.isdeleted);
                        command.Parameters.AddWithValue("@isonline", licenceTable.isonline);
                        command.Parameters.AddWithValue("@macAddress", licenceTable.macAddress);
                        command.Parameters.AddWithValue("@expirydate", licenceTable.expirydate);
                        command.Parameters.AddWithValue("@isinfoextrator", licenceTable.isinfoextrator); // Add the new parameter

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
        public static bool UpdateMacAddressAttemptById(int id, string macAddressAttempt)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    string query = "UPDATE LicenceTable SET macAddressAttempt = @macAddressAttempt WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@macAddressAttempt", macAddressAttempt);

                        
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Update successful
                            return true;
                        }
                        else
                        {
                            // No rows were updated (id not found)
                            Console.WriteLine("No rows were updated. The specified id was not found.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating macAddressAttempt: " + ex.Message);
                return false;
            }
        }
        public static void UpdateLicenceTable(LicenceTable licenceTable)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    string query = "UPDATE LicenceTable SET email = @email, serialkey = @serialkey, isactive = @isactive, isdeleted = @isdeleted, isonline = @isonline, macAddress = @macAddress, expirydate = @expirydate, isinfoextrator = @isinfoextrator WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", licenceTable.id);
                        command.Parameters.AddWithValue("@email", licenceTable.email);
                        command.Parameters.AddWithValue("@serialkey", licenceTable.serialkey);
                        command.Parameters.AddWithValue("@isactive", licenceTable.isactive);
                        command.Parameters.AddWithValue("@isdeleted", licenceTable.isdeleted);
                        command.Parameters.AddWithValue("@isonline", licenceTable.isonline);
                        command.Parameters.AddWithValue("@macAddress", licenceTable.macAddress);
                        command.Parameters.AddWithValue("@expirydate", licenceTable.expirydate);
                        command.Parameters.AddWithValue("@isinfoextrator", licenceTable.isinfoextrator); // Add the new parameter

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
                using (SqlConnection connection = GetConnection())
                {
                    string query = "UPDATE LicenceTable SET isdeleted = 1 WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
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
                using (SqlConnection connection = GetConnection())
                {
                    string query = "UPDATE LicenceTable SET isonline = @isonline WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
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
                using (SqlConnection connection = GetConnection())
                {
                    string query = "SELECT macAddress FROM LicenceTable WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
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

        public static void SetMacAddressById(int id, string email, string macAddress)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    string query = "UPDATE LicenceTable SET macAddress = @macAddress, email = @email, isactive = @isactive, isonline = @isonline WHERE id = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@macAddress", macAddress);
                        command.Parameters.AddWithValue("@email", email);
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
