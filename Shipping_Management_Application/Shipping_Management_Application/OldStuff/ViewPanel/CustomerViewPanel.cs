using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.OldStuff.ViewPanel
{
    public class CustomerViewPanel
    {
        //viewpanel for Customer <--> OrderRegistration.cs 
        // We must have an method to deleteOwnProffile();
        InfoAboutOurApp _infoAboutOurApp = new();
        LoadingView loadingView = new();
        UserLogin userLogin = new();
        public void MainView()
        {
            _infoAboutOurApp.HeaderComponent("app");
            // show welcome Message
            loadingView.Print("Loading...");
            _infoAboutOurApp.WelcomeMesseag(); //we write more info about our application
            Thread.Sleep(4000);
            _infoAboutOurApp.About();
            Thread.Sleep(5000);


            // menu 
            while (true)
            {
                Console.WriteLine("----------- Enter your Choice! 1, 2, 3 or 4");
                Console.WriteLine("----------- 1. Place Order"); // loading PlaceOrderViewPanel(){OrderRegistration.cs} -> return CustomerViewPanel();
                                                                 // loading TransportViewPanel- create transpot methods for order Randomlig
                Console.WriteLine("----------- 2. Manage Profile");//Loading UserProfileViewPanel(string username);CURD methods
                Console.WriteLine("----------- 3. Orders History");//Method to List<Order> -> GetAllHistoryOrders()
                Console.WriteLine("----------- 4. LogOut");// Return MainViewPanel() ->Exit;

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            Console.WriteLine("LogIn for Customer");
                            loadingView.Print("Loading...");
                            // comming method -> CustomerViewPanel() 
                            userLogin.ShowLoginPage();
                            break;
                        }


                    case "2":
                        {
                            Console.WriteLine("LogIn for Admin");
                            loadingView.Print("Loading...");
                            // comming method -> AdminViewPanel()
                            userLogin.ShowLoginPage();
                            break;
                        }

                    case "3":
                        while (true)
                        {
                            Console.WriteLine("Do you want to Exit Program? (yes/no)");
                            string input = Console.ReadLine().ToLower();
                            if (input.ToLower() == "yes")
                            {
                                Console.WriteLine("Exiting....\n Program finished");
                                _infoAboutOurApp.EndProgram();
                                Thread.Sleep(7000);
                                return;
                            }
                            else if (input.ToLower() == "no")
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
        public bool IsValidInput(string input)
        {
            return input == "1" || input == "2" || input == "3";
        }
    }
}
