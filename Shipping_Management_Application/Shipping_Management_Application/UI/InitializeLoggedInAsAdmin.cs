using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;

namespace Shipping_Management_Application.UI
{
    public class InitializeLoggedInAsAdmin{

        public static void OnLoggedIn(UserEntity user)
        {
            bool running = true;
            while (running){

                Console.WriteLine("Press 1 to manage users");
                Console.WriteLine("Press 2 to view customer orders");
                Console.WriteLine("Press 9 to sign out");
                
                
                char input = UIController.ReadASingleKeyPress("12");

                switch (input){
                    case '1':{

                        break;
                    }case '2':{
                        OrderControllerUI.PrintCurrentUsersOrders(user);
                        break;
                    }
                    case '3':{
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