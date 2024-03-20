using Library_Designpatterns.LibraryCommand;
using Library_Designpatterns.LibraryProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library_Designpatterns.LibraryBuilder
{
    public class Library  
    {
        LibraryManager libraryManager;

        BorrowBookCommand borrowBookCommand;

        AddBookCommand addBookCommand;

        ReturnBookCommand returnBookCommand;
        public Library() 
        {
            DatabaseConnection db = new DatabaseConnection();
            libraryManager = new LibraryManager(db.GetBookDatabase());

            borrowBookCommand = new BorrowBookCommand(libraryManager);

            addBookCommand = new AddBookCommand(libraryManager);

            returnBookCommand = new ReturnBookCommand(libraryManager);
        }

        public void MainMenu() 
        {
            Console.WriteLine("Welcome to the library!");
            
            Console.WriteLine();

            bool loggedIn = false;

            while (!loggedIn) 
            {
                Console.WriteLine("Username: ");

                string usernameInput = Console.ReadLine();

                Console.WriteLine();

                Console.WriteLine("Password: ");

                string passwordInput = Console.ReadLine();

                if (usernameInput == "user" && passwordInput == "1234")
                {
                    loggedIn = true;
                    int userMenuChoice = 0;

                    while (userMenuChoice != 4)
                    {
                        try
                        {
                            Console.Clear();

                            Console.WriteLine("What do you want to do today?");
                            Console.WriteLine();
                            Console.WriteLine("1. Borrow book");
                            Console.WriteLine("2. Add new book");
                            Console.WriteLine("3. Return book");
                            Console.WriteLine("4. End program");
                            Console.WriteLine();

                            userMenuChoice = int.Parse(Console.ReadLine());

                        }
                        catch
                        {
                            Console.WriteLine("You can only write numbers.");
                        }

                        //Switch case that holds all the menu chioces.
                        switch (userMenuChoice)
                        {
                            case 1:
                                Console.Clear();
                                borrowBookCommand.Execute();
                                break;
                            case 2:
                                Console.Clear();
                                addBookCommand.Execute();
                                break;
                            case 3:
                                Console.Clear();
                                returnBookCommand.Execute();
                                break;
                            case 4:
                                break;
                            default:
                                Console.WriteLine("You wrote too many numbers or a number that doesn't exist");
                                break;
                        }
                    }

                }
                else
                {
                    Console.Clear ();
                    Console.WriteLine("Wrong username or password, try again.");
                    Console.WriteLine();

                }
            }
            
            

            








        }
    }
}
