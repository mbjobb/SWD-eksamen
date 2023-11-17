using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;

namespace Shipping_Management_Application.UI{
    public class InitializeLoggedIn{

        public static void OnLoggedIn(UserEntity user)
        {
            
            bool running = true;
            while (running){
                using DataContext context = new();
                Console.WriteLine("Press 1 to place an order");
                Console.WriteLine("Press 2 to sign out");
                
                char input = UIController.ReadASingleKeyPress("12");

                switch (input){
                    case '1':{
                        OrderController.PlaceOrder(user);
                        break;
                    }
                    case '2':{
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