using Microsoft.EntityFrameworkCore;
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
            Console.WriteLine("Press 3 create a new admin account");

            char input = UIController.ReadASingleKeyPress("123");

            switch (input)
            {
                case '1':
                    {
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
                        Console.Write("username or id: ");
                        string filterChoice = Console.ReadLine().ToLower();

                        if (filterChoice == "username") 
                        {
                            Console.Write("Enter username of the user you want to manage:");
                            string username = Console.ReadLine();
                            ManageUserByUsername(username);
                        }

                        if (filterChoice == "id")
                        {
                            
                            Console.Write("Enter the ID of the user you want to manage:");
                            string id = Console.ReadLine();
                            //Converts the string to long, since thats the datatype of the ids in the db
                            long longId = (long)Convert.ToInt64(id);

                            //and here it is in a oneliner, but its less readable
                            //long longId = (long)Convert.ToInt64((string)Console.ReadLine());
                            ManageUserById(longId);
                        }
                        
                        break;
                    }
                case '3':
                    {
                        Console.Write("Username for new admin:");
                        string username = Console.ReadLine();
                        Console.Write("Password for new admin:");
                        string password = Console.ReadLine();
                        try
                        {
                            UserEntity admin = AdminController.CreateAdmin(username, password);
                            Console.WriteLine($"New admin created. \n ID:{admin.Id} Username:{username}");

                        }
                        catch (DbUpdateException e)
                        {

                            Console.WriteLine("username already exists, please try a different username");
                        }
                        break;
                    }
            }
        }

        //TODO: dry this
        private static void ManageUserByUsername(string username)
        {
            UserEntity user = InitializeApp.userController.GetUserEntityByUsername(username);
            Console.WriteLine($"user found :{user}");
            Console.WriteLine($"would you like to delete {user.UserName}");
            Console.WriteLine("(y/n");
            char yesNo = UIController.ReadASingleKeyPress("yn");
            if (yesNo == 'y') InitializeApp.userController.DeleteUserEntity(user); else ManageUsers();
        }

        public static void ManageUserById(long id)
        {
            UserEntity user = InitializeApp.userController.GetUserEntityById(id);
            Console.WriteLine($"user found :{user}");
            Console.WriteLine($"would you like to delete {user.UserName}");
            Console.WriteLine("(y/n");
            char yesNo = UIController.ReadASingleKeyPress("yn");
            if (yesNo == 'y') InitializeApp.userController.DeleteUserEntity(user); else ManageUsers();

        }
    }
}
