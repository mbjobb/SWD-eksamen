﻿using NUnit.Framework.Constraints;
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
            ///TODO: check and fix switch case formating
            switch (input)
            {
                case '1' :{
                    UserController.Login();
                    break;
                }

                case '2' :{
                        UserController.RegisterUser();
                        break;
                 }
            }
        }
    }
}
