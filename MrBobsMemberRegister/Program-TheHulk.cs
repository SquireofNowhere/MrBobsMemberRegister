﻿using System;
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

            Users user;
            //catches user that signed in
            do
            {
                user = LoginScreen();
            }
            while (user != null);
            
           

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

        static Users LoginScreen()
        {
            Console.Clear();
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. See all Users");
            Console.WriteLine("0. Exit Application\n");

            ConsoleKeyInfo choice = Console.ReadKey(false);

            switch (choice.KeyChar)
            {
                case '0':

                    Console.Clear();
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0); // exits the application
                    break;

                case '1':

                    Console.WriteLine("Enter your username: ");
                    string username = Console.ReadLine();
    
                    Console.WriteLine("Enter your password: ");
                    string password = Console.ReadLine();

                    Users user = new Users(username, password);

                    //entering info loop
                    while (true)
                    {
                        if (user.Exists())
                        {
                            if (user.CheckPassword(user.PasswordHash))
                            {
                                //returns the user if the password is correct
                                Console.WriteLine("User exists and password is correct");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Password is incorrect");
                                Console.WriteLine("Enter your password or press 0 to cancel: ");

                                switch (Console.ReadLine())
                                {
                                    case "0":
                                        //returning null restarts LoginScreen method
                                        return null;

                                    default:
                                        user.PasswordHash = Console.ReadLine();
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("User does not exist in the database");
                            Console.WriteLine("Enter your username or press 0 to cancel: ");

                            switch (Console.ReadLine())
                            {
                                case "0":
                                    //returning null restarts LoginScreen method
                                    return null;

                                default:
                                    user.Name = Console.ReadLine();
                                    break;
                            }
                        }
                    }
                    
                    
                    //exits login screen loop with verified user
                    return user;

                case '2':
                    return Register();

                case '3':
                    return null;

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

            


            return new Users(username, password);
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
