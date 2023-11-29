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
        { /// <summary>
          /// Refactoring  3/x <see cref="UserControllerUI.Login"/>
          /// Removed manual printing of the menu
          /// </summary>

            bool running = true;
            while (running){

                List<string> list = new List<string>()
                {
                    "Sign In",
                    "Sign Up",
                    "Exit"

                };
                Console.WriteLine("Welcome");
                UIController.DrawMenu(list);
                

                char input = UIController.ReadASingleKeyPress("129");
                // TODO: check and fix switch case formatting

                switch (input)
                {
                    case '1':
                    {

                        UserControllerUI.Login(userController);
                        break;
                    }
                    case '2':
                    { 
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
