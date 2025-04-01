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
        public string Password { get; set; }

        //constructor used when creating a new user
        public Users(string name, string password)
        {
            Name = name;
            Password = password;
        }

        //constructer for existing users
        public Users() { }


        //private method to hash the password
        private string HashPassword(string password)
        {
            // Hash the password
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool AddUser()
        {
            // Add the user to the database

            string PasswordHash = HashPassword(Password);

            if (!Exists() && Name != "" && Password != "") //if they do not already exist on the database
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "INSERT INTO Bob_Users (Name, PasswordHash) VALUES (@Name, @PasswordHash)";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@PasswordHash", PasswordHash);
                        command.ExecuteNonQuery();
                        Console.WriteLine("User added to Database");
                        Console.ReadKey();
                    }
                }

                return true;
            }
            else
            {
                
                Console.WriteLine("Error when adding user!");
                Console.ReadKey();
                return false;
            }


        }

        public bool Exists()
        {
            // Check if the user exists in the database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Bob_Users WHERE Name = @Name";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        //method to check if the password is correct against the database using the user Name
        public bool CheckPassword()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT PasswordHash FROM Bob_Users WHERE Name = @Name";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    string PasswordHash = (string)command.ExecuteScalar(); //returns the password hash from the database
                    return BCrypt.Net.BCrypt.Verify(Password, PasswordHash); //compares the password entered with the hash from the database
                }
            }

            
        }

        

    }
}
