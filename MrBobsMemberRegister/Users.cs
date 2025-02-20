using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net; 

namespace MrBobsMemberRegister
{
    internal class Users
    {
        private string connString = @"Server=(localdb)\MSSQLLocalDB;Database=MrBobArtDB;Integrated Security=true;";
        public string Name { get; set; }
        public string PasswordHash { get; set; }

        //constructor used when creating a new user, automatically hashes the password
        public Users(string name, string password)
        {
            Name = name;
            PasswordHash = HashPassword(password);
           
        }


        //private method to hash the password
        private string HashPassword(string password)
        {
            // Hash the password
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public void AddUser()
        {
            // Add the user to the database

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "INSERT INTO Users (Name, PasswordHash) VALUES (@Name, @PasswordHash)";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@PasswordHash", PasswordHash);
                    command.ExecuteNonQuery();
                    Console.WriteLine("User added to Database");
                }
            }
        }

        public bool Exists()
        {
            // Check if the user exists in the database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Name = @Name";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        //method to check if the password is correct against the database using the user Name
        public bool CheckPassword(string password)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT PasswordHash FROM Users WHERE Name = @Name";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    string PasswordHash = (string)command.ExecuteScalar();
                    return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
                }
            }

            
        }

        

    }
}
