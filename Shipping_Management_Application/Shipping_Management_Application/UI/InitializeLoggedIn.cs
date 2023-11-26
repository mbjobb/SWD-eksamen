using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;

namespace Shipping_Management_Application.UI
{
    public class InitializeLoggedIn{

        public static void OnLoggedIn(UserEntity user)
        {
            bool running = true;
            while (running){
                Console.WriteLine("Press 1 to place an order");
                Console.WriteLine("Press 2 to view orders");
                Console.WriteLine("Press 9 to sign out");
                
                
                char input = UIController.ReadASingleKeyPress("129");

                switch (input){
                    case '1':{
                        OrderControllerUI.PlaceOrder(user);
                        break;
                    }case '2':{
                        OrderControllerUI.PrintCurrentUsersOrders(user);
                        break;
                    }
                    case '9':{
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