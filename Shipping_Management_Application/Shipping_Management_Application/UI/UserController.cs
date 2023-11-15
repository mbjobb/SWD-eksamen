using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;


namespace Shipping_Management_Application.UI
{
    internal class UserController{
        private User _user = null!;
        public static User? Login()
        {
            using DataContext context = new ();
           
            Console.Write("Enter Username:");
            string? _username = Console.ReadLine();
            Console.Write("Enter Password:");
            string? _password = Console.ReadLine();

            CrudOperations.GetUserByUserNameAndPassword(_username, _password);
            return null;
        }

        public static void RegisterUser(){
            using DataContext context = new ();
            Console.Write("Enter Username:");
            string? _username = Console.ReadLine();
            Console.Write("Enter Password:");
            string? _password = Console.ReadLine();
            User user = new(_username, _password);
            context.Add(user);
            context.SaveChanges();
            RegisterCustomer(user);
        }

        public static void RegisterCustomer(User user){
            
            if (user == null) {
                Console.WriteLine("User not logged in.");
                return;
            }
            using DataContext context = new();
            Console.WriteLine("Enter first name");
            string? firstname = Console.ReadLine();

            Customer customer = new(user.Id, firstname);
            context.Add(customer);
            context.SaveChanges();
        }

        public static void PlaceOrder(){
            
        }
    }
}
