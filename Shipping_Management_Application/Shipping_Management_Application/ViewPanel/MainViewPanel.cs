using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Shipping_Management_Application.ViewPanel
{
    public class MainViewPanel
    {
        InfoAboutOurApp _infoAboutOurApp = new();
        LoadingView _loadingView = new();

        public void MainView()
        {
            _infoAboutOurApp.HeaderComponent();
            // show welcome Message
            _loadingView.Print("Loading...");
            _infoAboutOurApp.WelcomeMesseag(); //we write more info about our application
            Thread.Sleep(1000);
            _infoAboutOurApp.About(); //we write more info about our application
            Thread.Sleep(1000);


            // menu 
            while (true)
            {
                Console.WriteLine("----------- Enter your Choice! 1, 2, or 3");
                Console.WriteLine("----------- 1. SignIn / Register "); //sign In for Customer , vise ny meny signIn eller register
                Console.WriteLine("----------- 2. Admin");//sign In for Admin
                Console.WriteLine("----------- 3. Exit");

                var userInput = Console.ReadLine(); // Get input from User, and saved i UserInput variabel

                switch (userInput)
                {
                    case "1":
                        {
                            Console.WriteLine("Sign In page for Customer");  // Case 1 for Customer 
                            User user = new User("", "", "");
                            SignInForCustomerViewPanel signInForCustomerViewPanel = new();
                            signInForCustomerViewPanel.GetSingInViewPanel(user);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Sign In page for Admin"); // Case 2 for Admin
                            UserRegistration userRegistration = new();
                            userRegistration.SignInAdmin();

                            break;
                        }

                    case "3":        // Case 3 for Exiting 
                        while (true)
                        {
                            Console.WriteLine("Do you want to Exit Program? (yes/no)");
                            string? input = Console.ReadLine();
                            if (input?.ToLower() == "yes")
                            {
                                Console.WriteLine("Exiting....\nProgram finished");
                                _infoAboutOurApp.EndProgram();
                                Thread.Sleep(2000);
                                return;
                            }
                            else if (input?.ToLower() == "no")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter 'yes' to exit or 'no' to return to the main menu.");
                            }
                        }

                        break;

                    default:
                        Console.WriteLine("Invalid option. Please enter 1, 2, or 3.");
                        break;
                }
            }

        }

        // Method to check Is user Input is valid or not 
        public static bool IsValidInput(string input)
        {
            return input == "1" || input == "2" || input == "3";
        }

    }
}