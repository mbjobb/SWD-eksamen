using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Threading;

namespace Shipping_Management_Application.ViewPanel
{
    public class CustomerViewPanel
    {
        InfoAboutOurApp _infoAboutOurApp = new();
        DataContext _dataContext = new();

        public void CustomerMainView(User user)
        {
            _infoAboutOurApp.WelcomeMesseag();
            Thread.Sleep(1000);
            _infoAboutOurApp.About();
            Thread.Sleep(1000);

            Console.WriteLine($"----- Welcome {user.UserName} -----");

            while (true)
            {
                Console.WriteLine("----------- Enter your Choice! 1, 2, 3 or 4");
                Console.WriteLine("----------- 1. Make Delivery order");
                Console.WriteLine("----------- 2. Manage Profile");
                Console.WriteLine("----------- 3. Orders History");
                Console.WriteLine("----------- 4. Log Out");

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            PlaceOrderRegistrationViewPanel placeOrderRegistrationViewPanel = new(_dataContext);
                            placeOrderRegistrationViewPanel.CreateOrderPanel(user);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("ManageProfile()");
                            // Implement your ManageProfile logic here
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("OrdersHistory()");
                            OrdersHistoryViewPanel ordersHistoryViewPanel = new(_dataContext);
                            ordersHistoryViewPanel.ShowOrderHistory(user);
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Do you want to Log Out? (yes/no)");
                            string input = Console.ReadLine().ToLower();
                            if (input == "yes")
                            {
                                Console.WriteLine("Logging Out....");
                                _infoAboutOurApp.EndProgram();
                                Thread.Sleep(1000);
                                Environment.Exit(0);
                            }
                            else if (input == "no")
                            {
                                // Continue with the loop
                            }
                            else
                            {
                                Console.WriteLine("Please enter 'yes' to log out or 'no' to return to the main menu.");
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("Invalid option. Please enter 1, 2, 3, or 4.");
                        break;
                }
            }
        }

        // Method to check if user input is valid or not
        public bool IsValidInput(string input)
        {
            return input == "1" || input == "2" || input == "3" || input == "4";
        }
    }
}
