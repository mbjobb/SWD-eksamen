using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.ViewPanel
{
    public class CustomerViewPanel 
    {
        //viewpanel for Customer <--> OrderRegistration.cs 
        //We must have an method to deleteOwnProffile();
        InfoAboutOurApp _infoAboutOurApp = new();
       
        DataContext _dataContext = new();
        //LoadingView loadingView = new(); 
        //UserLogin userLogin = new(); 
        public void CustomerMainView(User user)
        {
            //_infoAboutOurApp.HeaderComponent("app");
            //// show welcome Message
            //loadingView.Print("Loading...");
            _infoAboutOurApp.WelcomeMesseag(); //we write more info about our application
            Thread.Sleep(1000);
            _infoAboutOurApp.About();
            Thread.Sleep(1000);

            Console.WriteLine($"----- Welcome {user.UserName} -----");
            // menu 
            while (true)
            {
                Console.WriteLine("----------- Enter your Choice! 1, 2, 3 or 4");
                Console.WriteLine("----------- 1. Make Delivery order"); // loading PlaceOrderViewPanel(){OrderRegistration.cs} -> return CustomerViewPanel();
                                                                 // loading TransportViewPanel- create transpot methods for order Randomlig
                Console.WriteLine("----------- 2. Manage Profile");//Loading UserProfileViewPanel(string username);CURD methods
                Console.WriteLine("----------- 3. Orders History");//Method to List<Order> -> GetAllHistoryOrders()
                Console.WriteLine("----------- 4. LogOut");// Return MainViewPanel() ->Exit;

                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            /*long cid = 123;*/ // we must taked from customerRegistration()
                            //long id =_userEntity.Id = 1;                         
                            Console.WriteLine("PlaceOrderPnael()");
                            PlaceOrderRegistrationViewPanel placeOrderRegistrationViewPanel = new(_dataContext);
                            placeOrderRegistrationViewPanel.CreateOrderPanel(user);
                            //loadingView.Print("Loading...");
                            // comming method -> CustomerViewPanel() 
                            //userLogin.ShowLoginPage();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("ManageProfile()");
                            //loadingView.Print("Loading...");
                            //// comming method -> AdminViewPanel()
                            //userLogin.ShowLoginPage();
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
                        while (true)
                        {
                            Console.WriteLine("Do you want to Exit Program? (yes/no)");
                            string? input = Console.ReadLine().ToLower();
                            if (input.ToLower() == "yes")
                            {
                                Console.WriteLine("Exiting....\n LogOut");
                                _infoAboutOurApp.EndProgram();
                                Thread.Sleep(2000);
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
            return input == "1" || input == "2" || input == "3" || input == "4";
        }
    }
}
