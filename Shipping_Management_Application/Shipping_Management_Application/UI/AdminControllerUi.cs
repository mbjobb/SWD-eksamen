﻿using Microsoft.EntityFrameworkCore;
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
    /// <summary>
    /// AdminControllerUi class with the methods that are used in the UI. 
    /// </summary>
    public static class AdminControllerUi
    {
        internal static AdminController AdminController = new AdminController();
         // manages the admin menu and calls the methods from the AdminController class.
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
                        string? idOrUsername = Console.ReadLine();
                        long id = 0;
                        //TODO: unfuck this
                        try
                        {
                            id = (long)Convert.ToInt64(idOrUsername);
                            idOrUsername = null;

                        }
                        catch (FormatException)
                        {
                            //This is fine
                        }

                        UserEntity user = InitializeApp.userController.GetUserEntityByIdOrUsername(id, idOrUsername);
                        Console.WriteLine($"user found :{user}");
                        Console.WriteLine($"would you like to delete {user.UserName}");
                        Console.WriteLine("(y/n)");
                        char yesNo = UIController.ReadASingleKeyPress("yn");
                        if (yesNo == 'y') InitializeApp.userController.DeleteUserEntity(user); else ManageUsers();

                       
                        break;
                    }
                case '3':
                    {
                        Console.Write("Username for new admin:");
                        string? username = Console.ReadLine();
                        Console.Write("Password for new admin:");
                        string? password = Console.ReadLine();
                        try
                        {
                            UserEntity admin = AdminController.CreateAdmin(username, password);
                            Console.WriteLine($"New admin created. \n ID:{admin.Id} Username:{username}");

                        }
                        catch (DbUpdateException e)
                        {

                            Console.WriteLine("username already exists, please try a different username");
                            Console.WriteLine(e.Message);
                        }
                        break;
                    }
            }
        }

    }
}
