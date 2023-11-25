using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.Data;

namespace Shipping_Management_Application.UI{
    public class InitializeOrder{

        public static void OnOrdering(UserEntity user)
        {
            //TODO: implement sign out
            
            bool running = true;
            while (running){
                
                using DataContext context = new();
                Console.WriteLine("Choose a delivery modes");
                Console.WriteLine("Press 1 to order by air");
                Console.WriteLine("Press 2 to order by land");
                Console.WriteLine("Press 3 to order by sea");
                
                char input = UIController.ReadASingleKeyPress("12");

                switch (input){
                    case '1':{
                        OrderControllerUI.PlaceOrder(user);
                        break;
                    }
                    case '2':{
                        running = false;
                        throw new NotImplementedException();
                    }
                    case '3':{
                        running = false;
                        throw new NotImplementedException();
                    }
                }
            }
        }
    }
}