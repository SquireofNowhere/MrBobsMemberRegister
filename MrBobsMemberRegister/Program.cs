using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MrBobsMemberRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Connection string for SQL Server LocalDB
            string connString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;";

            DBConnect conn = new DBConnect(connString);
            conn.Connect();

            Console.WriteLine("Welcome to Mr Bob's Member Register");
            Console.WriteLine("1. Database options");

            //Switch for first menu choice
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("1. Check database tables");
                    conn.CheckDBTables();
                    break;

                default:
                    break;
            }

            Console.WriteLine("Press any to exit");
            Console.ReadKey();
        }
    }
}
