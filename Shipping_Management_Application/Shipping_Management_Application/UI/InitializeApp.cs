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
            UIController.SetTitle("App Name");
        }

        public void OnStartup()
        {
            using DataContext context = new();
            Console.WriteLine("Welcome");
            Console.WriteLine("Press 1 to login to an existing user");
            Console.WriteLine("Press 2 to sign up if you don't have a user");

            char input = UIController.ReadASingleKeyPress("12");

            switch (input)
            {
                case '1' :{
                    break;
                }

                case '2' :{ 
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
