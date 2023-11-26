using NUnit.Framework.Constraints;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.UI{
    public class InitializeApp{
            public static IUserController userController = new UserController();
        public InitializeApp(){
            /// <summary>
            /// Facade pattern continued. 2/2
            /// This is essentially a wrapper, allowing us to initialize the 
            /// program with a single line, as seen in  Program.cs.
            /// The method calls here are also mostly to wrapeprs, meaning we
            /// have a loose coupling to the concrete implimentations
            /// and thus a more modular codebase.
            /// </summary>

            UIController.SetTitle("App Name");
            FirstStart.ChecksIfUserEntityTableIsEmpty();
            OnStartup(userController);
        }
        
        public static void OnStartup(IUserController userController)
        {

            bool running = true;
            while (running){
                

                Console.WriteLine("Welcome");
                Console.WriteLine("Press 1 to login to an existing user");
                Console.WriteLine("Press 2 to sign up if you don't have a user");
                Console.WriteLine("Press 9 to exit");

                char input = UIController.ReadASingleKeyPress("12");
                // TODO: check and fix switch case formatting

                switch (input){
                    case '1':{
                        UserControllerUI.Login(userController);
                        break;
                    }

                    case '2':{
                        UserControllerUI.RegisterUser(userController);
                        break;
                    }
                    case '9':{
                        running = false;
                        UIController.CloseApplication();
                        break;
                    }
                }
            }
        }
    }
}
