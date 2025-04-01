using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrBobsMemberRegister
{
    internal class Members
    {
        private string connString = @"Server=(localdb)\MSSQLLocalDB;Database=MrBobArtDB;Integrated Security=true;";

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int numArtworks { get; set; }
        public int Rent {  get; set; }

        public Members(string name, string surname, int numartworks, int rent)
        {
            Name = name;
            Surname = surname;
            numArtworks = numartworks;
            Rent = rent;
        }

        public Members() { }

        public void UpdateCount()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "UPDATE Bob_Members SET numArtworks = (SELECT COUNT(*) FROM Bob_Artworks WHERE OwnerID = @OwnerID) WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@OwnerID", ID);
                    command.Parameters.AddWithValue("@ID", ID);
                    int count = (int)command.ExecuteScalar();
                    Console.WriteLine($"There are {count} Artworks for {Name} in the database.");
                    Console.ReadKey();
                }
            }
        }

        public bool AddMember()
        {
            if (Name != "")
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "INSERT INTO Bob_Members (Name, Surname, numArtworks, rent) VALUES (@Name, @Surname, @numArtworks, @rent)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Surname", Surname);
                        command.Parameters.AddWithValue("@numArtworks", numArtworks);
                        command.Parameters.AddWithValue("@rent", Rent);
                        
                        command.ExecuteNonQuery();

                        Console.WriteLine("Member added to Database");
                        Console.ReadKey();
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine("Member not added to Database");
                Console.ReadKey();
                return false;
            }
        }

        public bool RemoveMember()
        {
            return false;
        }

        public List<Members> allmembers()
        {
            List<Members> members = new List<Members>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM Bob_Members";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Members member = new Members();

                            member.ID = (int)reader["ID"];
                            member.Name = reader["Name"].ToString();
                            member.Surname = reader["Surname"].ToString();
                            member.numArtworks = (int)reader["numArtworks"];
                            member.Rent = (int)reader["rent"];

                            members.Add(member);
                        }
                    }
                }
            }


            return members;
        }

        public override string ToString()
        {
            return $"{ID}. Name: {Name}, Surname: {Surname}, Number of Artworks: {numArtworks}, Rent: {Rent}";
        }

    }
}
