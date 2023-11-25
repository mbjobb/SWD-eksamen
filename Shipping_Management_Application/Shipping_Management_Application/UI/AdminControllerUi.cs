using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.UI
{
    public static class AdminControllerUi
    {
        internal static AdminController AdminController = new AdminController();

        public static void ManageUsers()
        {
            Console.WriteLine("Press 1 for a list of all users");
            Console.WriteLine("Press 2 to alter a user");
            Console.WriteLine("Press 3 register a new user admin");

            char input = UIController.ReadASingleKeyPress("123");

            switch (input)
            {
                case '1':{
                        IEnumerable<UserEntity> users = AdminController.GetAllUserEntities();
                        foreach (var userEntity in users)
                        {
                            Console.WriteLine(userEntity);
                        }
                        break;
                    }
                case '2':
                    {
                        Console.WriteLine("select a user by username or id");
                        Console.Write("username or id");
                        string filterChoice = Console.ReadLine();
                        break;
                    }
            }
        }
    }
}
