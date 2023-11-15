using NUnit.Framework.Constraints;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.UI
{
    public class InitializeApp
    {
        public InitializeApp()
        {
            ConsoleController.SetTitle("App Name");
        }

        public void OnStartup()
        {
            using DataContext context = new DataContext();
            Console.WriteLine("Welcome");
            Console.WriteLine("Press 1 to login to an existing user");
            Console.WriteLine("Press 2 to sign up if you don't have a user");

            switch (ConsoleController.ReadASingleKeyPress("12"))
            {

                case (char)1:

                case (char)2:
                    {
                        Console.Write("Enter Username:");
                        string _username = Console.ReadLine();
                        Console.Write("Enter Password:");
                        string _password = Console.ReadLine();

                        User user = new(_username, _password);
                        context.Add(user);
                        context.SaveChanges();

                        break;

                    }
                
            }
        }
    }
}
