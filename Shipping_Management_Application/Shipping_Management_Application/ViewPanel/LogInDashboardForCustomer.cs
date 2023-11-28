using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.ViewPanel
{
    public class LogInDashboardForCustomer
    {
        //MainViewPanel _mainViewPanel = new MainViewPanel(); <--> Infinity loop 
        InfoAboutOurApp _infoAboutOurApp = new();
        // method for LogInDashboard for customer
        public void LogInDashboard(User user)
        {
            _infoAboutOurApp.HeaderComponent();

            while (true)
            {
                Console.WriteLine("1. Sing In"); // retur ShowLoginPage
                Console.WriteLine("2. Register"); // return customerRegistration()
                Console.WriteLine("3. Exit"); //  return to mainviewpanel
               

                //menu
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            Console.WriteLine("1");
                            Console.WriteLine("Customer LogIn");
                            UserRegistration userRegistration = new();
                            userRegistration.SignInCustomerHowHaveSignUp();

                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("2");
                            Console.WriteLine("Sign Up Please");
                            CustomerRegistration _customerRegistration = new();
                            _customerRegistration.RegisterCustomer();
                            break;
                        }
                    case "3":
                        {
                            MainViewPanel mainViewPanel = new();
                            mainViewPanel.MainView();
                            break;

                        }
                    default:
                        Console.WriteLine("Invalid choice ");
                        break;
                }
                break;

            }

        }
    }

}