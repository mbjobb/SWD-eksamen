using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;

namespace Shipping_Management_Application.UI
{
    public class InitializeLoggedIn{
        /// <summary>
        /// Dependancy injection continued. 5/6
        /// Since we pass a reference to the base object rather than its 
        /// concrete implimentation we end up with a loose, rather than tight; 
        /// coupling.
        /// <see cref="OrderControllerUI"/>
        /// </summary>

        public static void OnLoggedIn(UserEntity user)
        {
            /// <summary>
            /// Refactoring  4/x <see cref="Factories.Transport.DispatchListener"/>
            /// Removed manual printing of menu
            /// </summary>
            bool running = true;
            while (running){
                Console.WriteLine($"Welcome {user?.UserName}");
                List<string> options = new List<string>()
                {
                    "Place delivery order",
                    "View order history",
                    "Manage Account",
                    "Sign out",
                    "Exit program"
                };
                UIController.DrawMenu(options);
                
                if ( user is null) { throw new NullReferenceException(); }
                
                char userInput = UIController.ReadASingleKeyPress("1234");

                switch (userInput){
                    case '1':
                    {
                        OrderControllerUI.PlaceOrder(user);
                        break;
                    }
                    case '2':
                    {
                        OrderControllerUI.PrintCurrentUsersOrders(user);
                        break;
                    }
                    case '3':
                    {
                        UserControllerUI.UpdateCustomer(InitializeApp.userController, user);
                        break;
                    }
                    case '4':
                    {
                        running = false;
                        UIController.ClearConsole();
                        InitializeApp.OnStartup(InitializeApp.userController);
                        break;
                    }
                    case '5':
                    {
                        UIController.CloseApplication();
                        break;
                    }
                }
            }
        }
    }
}