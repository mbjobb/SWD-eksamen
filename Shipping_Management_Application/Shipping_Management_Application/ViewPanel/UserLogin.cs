﻿//using System;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using Shipping_Management_Application.BuisnessLogic;
//using Shipping_Management_Application.Data;

//namespace Shipping_Management_Application.ViewPanel
//{
//    public class UserLogin
//    {
//        //method to showLogin page for customer and admin 
//        public void ShowLoginPageforCustomer()
//        {
//            Console.WriteLine("Welcome to the login page! \n Enter your username and password");
//            Console.WriteLine("UserName: ");
//            string? userNameInput = Console.ReadLine();
//            Console.WriteLine("Enter password: ");
//            string? passwordInput = Console.ReadLine();
//            if (string.IsNullOrEmpty(userNameInput) && string.IsNullOrEmpty(passwordInput))
//            {
//                Console.WriteLine("Please enter a username and password");
//                return;
//            }
//            else
//            {
//                try
//                {
//                    Console.WriteLine("I am HER");
//                    IsUserInDatabase(userNameInput, passwordInput);
//                    Console.WriteLine("userNameInput added in db");
//                    Console.WriteLine("End");
//                    IsCustomer();
//                    //Console.WriteLine(result);
//                    //Testing Debuging 
//                    //bool result = true;
//                    //registration.UserRegisterPanel();
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("error : " + ex.Message);
//                }
//            }
//        }

//        // method to check out for user in the database
//        public string IsUserInDatabase(string? username, string? password)
//        {
//            Console.WriteLine("DATABASE");
//            using (DataContext context = new())
//            {
//                var user = context.Users.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower());
//                if (user != null)
//                {
//                    IsCustomer();
//                    return "User exists in the database!";
//                }
//                else
//                {
//                    // Method to register user to the database
//                    Console.WriteLine("Welcome to Registration page! ");
//                    UserRegistration userRegistration = new();
//                    var res = userRegistration.UserRegisterPanel(username, password);
//                    try
//                    {
//                        context.Add(res);
//                        context.SaveChanges();
//                    }
//                    catch (DbUpdateException ex)
//                    {
//                        Exception? innerException = ex.InnerException;
//                        Console.WriteLine($"Error Message: {innerException?.Message}");
//                        Console.WriteLine($"Stack Trace: {innerException.StackTrace}");
//                    }
//                    Console.WriteLine("You can try to log in with your UserName and Password! ");
//                    // ShowLoginPage();
//                    return res;
//                }
//            }
//        }

//        public string IsCustomer()
//        {
//            CustomerViewPanel customerViewPanel = new();
//            customerViewPanel.MainView();
//            return "CustomerViewPanel";
//        }
//    }
//}
