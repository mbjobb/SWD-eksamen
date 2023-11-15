using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.UI
{
    internal class UserController
    {
        public static User Login()
        {
           
            using DataContext context = new ();
           
            Console.Write("Enter Username:");
            string? _username = Console.ReadLine();
            Console.Write("Enter Password:");
            string? _password = Console.ReadLine();

            CrudOperations.GetUserByUserNmaeAndPassword(_username, _password);
            
            return user;
        }

        public static void RegisterUser()
        {
            using DataContext context = new ();
            Console.Write("Enter Username:");
            string? _username = Console.ReadLine();
            Console.Write("Enter Password:");
            string? _password = Console.ReadLine();
            User user = new(_username, _password);
            context.Add(user);
            context.SaveChanges();

        }


    }
}
