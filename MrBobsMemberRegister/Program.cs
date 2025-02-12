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
            // Connection string for SQL Server LocalDB and MrBobArtDB database
            string connString = @"Server=(localdb)\MSSQLLocalDB;Database=MrBobArtDB;Integrated Security=true;";
            DBConnect conn = new DBConnect(connString);
            conn.Connect();

           
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Mr Bob's Member Register");
                Console.WriteLine("1. Database options");
                Console.WriteLine("2. Member Management");
                Console.WriteLine("0. Exit Application\n");


                ConsoleKeyInfo choice = Console.ReadKey(false);

                //Switch for first menu choice
                switch (choice.KeyChar)
                {
                    case '0':
                        
                        Console.Clear();
                        Console.WriteLine("Exiting...");
                        //using return instead of [Exit = true] to exit Main. closing the app.
                        return;

                    case '1':

                        DatabaseOptionsMenu(conn);                       
                        break;

                    case '2':

                        Console.Clear();
                        Console.WriteLine("1. Members");
                        Console.WriteLine("2. Manage Members");
                        break;

                    default:

                        //code for if someone presses an option not on the menu
                        if (choice.Key == ConsoleKey.Enter)
                        {
                            Console.Write("Pressing nothing is an invalid choice\nPress anything!");
                        }
                        else
                        {
                            Console.Write(" is an invalid choice\nPress anything!");
                        }                      
                        Console.ReadKey(true);
                        break;
                }
            }

            

          
        }

        //menu for database options
        static void DatabaseOptionsMenu(DBConnect conn)
        {

            var Exit = false;

            while (!Exit)
            {
                Console.Clear();
                Console.WriteLine("1. Check database tables");
                Console.WriteLine("2. Create database tables");
                Console.WriteLine("3. Drop database tables");
                Console.WriteLine("4. Insert data");
                Console.WriteLine("5. Update data");
                Console.WriteLine("6. Delete data");
                Console.WriteLine("0. Return to main menu\n");

                ConsoleKeyInfo choice = Console.ReadKey(false);

                switch (choice.KeyChar)
                {
                    case '0':
                        return;
                        

                    case '1':
                        conn.CheckDBTables();
                        break;

                    case '2':
                        break;

                    case '3':
                        break;

                    case '4':
                        break;

                    case '5':
                        break;

                    case '6':
                        break;

                    default:
                        //code for if someone presses an option not on the menu
                        if (choice.Key == ConsoleKey.Enter)
                        {
                            Console.Write("Pressing nothing is an invalid choice\nPress anything!");
                        }
                        else
                        {
                            Console.Write(" is an invalid choice\nPress anything!");
                        }
                        Console.ReadKey(true);
                        break;
                }
            }
            
        }
    }
}
