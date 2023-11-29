using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;

namespace Shipping_Management_Application.UI
{
    /// <summary>
    /// Class for the InitializeLoggedInAsAdmin class with the methods that are used in the UI.
    /// </summary>
    public class InitializeLoggedInAsAdmin{
        internal static AdminController AdminController = new AdminController();
        public static OrderController orderController = new OrderController();
         // onloggedin method for admin, this is where the admin can manage users and view orders
        public static void OnLoggedIn(UserEntity user)
        {
            bool running = true;
            while (running){

                List<string> options = new List<string>()
                {
                    "manage users",
                    "view orders",
                    "update user profile",
                    "sign out",
                    
                };
                Console.WriteLine($"Welcome {user.UserName}");
                UIController.MenuFacade(options);
                
                
                char input = UIController.ReadASingleKeyPress("1238");

                switch (input){
                    case '1':{

                            AdminControllerUi.ManageUsers(user);
                            running = false;
;
                            break;
                    }
                    case '2':{
                            OrderControllerUI.PrintAllOrders();
                        break;
                    }
                    case '3':
                        {
                            string inputValueToChange = UIController.ReadAStringInput();
                            InitializeApp.userController.UpdateUserEntityPassword(user, inputValueToChange);
                            break;
                        }
                    case '8':{
                        running = false;
                        UIController.ClearConsole();
                        InitializeApp.OnStartup(InitializeApp.userController);
                        break;
                    }
                }
            }
        }
    }
}