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
            string? name = Console.ReadLine();
            Console.WriteLine("Enter first email");
            string? email = Console.ReadLine();
            Console.WriteLine("Enter first adress");
            string? adress = Console.ReadLine();
            Console.WriteLine("Enter first post code");
            string? postCode = Console.ReadLine();

            Customer customer = new(user.Id, email, name, adress, postCode);
            context.Add(customer);
            context.SaveChanges();
        }

        public static void PlaceOrder(){
            
        }
    }
}
