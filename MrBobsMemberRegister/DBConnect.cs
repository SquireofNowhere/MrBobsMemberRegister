using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrBobsMemberRegister
{
    internal class DBConnect
    {
        private string connString;

        // Constructor taking one argument: connection string
        public DBConnect(string connString)
        {
            this.connString = connString;
        }
        public void Connect()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    Console.WriteLine("Connected to SQL Server LocalDB successfully!");

                    // Example: Create a database if it doesn't exist
                    string createDbQuery = "IF DB_ID('MrBobArtDB') IS NULL CREATE DATABASE MrBobArtDB;";
                    using (SqlCommand command = new SqlCommand(createDbQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Database created or already exists.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void CheckDBTables()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                // Query to get table names from INFORMATION_SCHEMA
                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Tables in the database:");
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["TABLE_NAME"].ToString());
                        }
                    }
                }
            }
        }
    }
}
