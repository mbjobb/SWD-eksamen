﻿using Shipping_Management_Application.BuisnessLogic.Controllers;

namespace Shipping_Management_Application.UI
{
    public class InitializeApp
    {
        public static IUserController userController = new UserController();
        public InitializeApp()
        {
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
            while (running)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Welcome to Shipping Management Application");
                Console.ResetColor();

                List<string> list = new()
                {
                    "Sign In",
                    "Sign Up",
                    "Exit"
                };

                UIController.DrawMenu(list);

                char loginInput = UIController.ReadASingleKeyPress("129");


                switch (loginInput)
                {
                    case '1':
                        {
                            running = false;
                            UserControllerUI.Login(userController);
                            break;
                        }
                    case '2':
                        {
                            UserControllerUI.RegisterUser(userController);
                            break;
                        }
                    case '9':
                        {
                            running = false;
                            UIController.CloseApplication();
                            break;
                        }
                }
            }
        }
    }
}
