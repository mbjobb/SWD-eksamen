﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.ViewPanel
{
    public class LogInDashboardForCustomer
    {
        UserLogin _userLogin = new();
        CustomerRegistration _customerRegistration = new();
        //MainViewPanel _mainViewPanel = new MainViewPanel(); <--> Infinity loop 
        //InfoAboutOurApp _infoAboutOurApp = new();
        // method for LogInDashboard for customer
        public void LogInDashboard()
        {
            //_infoAboutOurApp.HeaderComponent();

            //bool res = true;
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
                            _userLogin.ShowLoginPage();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("2");
                            Console.WriteLine("Sign Up Please");
                            _customerRegistration.RegisterCustomer();
                            break;
                        }
                    case "3":
                        {
                            //_mainViewPanel.MainView();
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
