﻿using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
using System.Security.AccessControl;

namespace Shipping_Management_Application.UI
{
    internal class UserControllerUI{
        public static UserController userController = new UserController();
        public static void Login(){
            

            
            Console.Write("Enter Username:");
            string? username = Console.ReadLine();
            Console.Write("Enter Password:");
            string? password = Console.ReadLine();

            //Placeholder for proper authentication since actual implimentation of something like OAuth is outside the scope of this subject.
            LoginAuthentication loginAuthentication = new LoginAuthentication();
            bool isAuthenticated = loginAuthentication.Authentication(username, password);
            bool matchFound = userController.UsernameAndPasswordMatchFoundInDB(username, password);

            if (matchFound && isAuthenticated)
            {
                UserEntity user = userController.FindUserByUsernameAndPassword(username, password);
                if (user.Role == "Admin") { InitializeLoggedInAsAdmin.OnLoggedIn(user); }
                InitializeLoggedIn.OnLoggedIn(user);
            }
            else{
                Console.WriteLine("User does not exist in our database");
            }
            
        }

        public static UserEntity RegisterUser(){
            Console.Write("Enter Username:");
            string username = Console.ReadLine();
            Console.Write("Enter Password:");
            string password = Console.ReadLine();
            User user = new(username, password);
            try
            {
            userController.CreateUser(username,password);

            }catch (Exception ex)
            {

                UIController.ClearConsole();
                Console.WriteLine("Username already in use, try a different username");
                RegisterUser();
            }
            return user;
        }

        public static void RegisterCustomer(UserEntity user){
            
            
            
            
            Console.WriteLine("Enter first name");
            string? name = Console.ReadLine();
            Console.WriteLine("Enter first email");
            string? email = Console.ReadLine();
            Console.WriteLine("Enter first adress");
            string? address = Console.ReadLine();
            Console.WriteLine("Enter first post code");
            string? postCode = Console.ReadLine();

            Customer customer = userController.CreateCustomer(user.Id, name, email, address, postCode);

        }
    }
}