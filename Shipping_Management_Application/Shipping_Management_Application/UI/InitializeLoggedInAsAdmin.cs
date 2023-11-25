using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;

namespace Shipping_Management_Application.UI
{
    public class InitializeLoggedInAsAdmin{
        internal static AdminController AdminController = new AdminController();
        public static OrderController orderController = new OrderController();

        public static void OnLoggedIn(UserEntity user)
        {
            bool running = true;
            while (running){

                Console.WriteLine("Press 1 to manage users");
                Console.WriteLine("Press 2 to view  orders");
                Console.WriteLine("Press 9 to sign out");
                
                
                char input = UIController.ReadASingleKeyPress("12");

                switch (input){
                    case '1':{

                            AdminControllerUi.ManageUsers();
                            //Console.WriteLine(AdminController.GetAllUserEntities());
                            break;
                    }case '2':{
                        OrderControllerUI.PrintCurrentUsersOrders(user);
                        break;
                    }
                    case '9':{
                        running = false;
                        UIController.ClearConsole();
                        InitializeApp.OnStartup();
                        break;
                    }
                }
            }
        }
    }
}