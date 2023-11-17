using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;


namespace Shipping_Management_Application.UI{
    internal class UserController{
        public static UserEntity? Login(){
            
            using DataContext context = new ();
            
            Console.Write("Enter Username:");
            string? _username = Console.ReadLine();
            Console.Write("Enter Password:");
            string? _password = Console.ReadLine();

            if (CrudOperations.CheckIfUserExists(_username, _password)){
                UserEntity user = CrudOperations.GetUserByUserNameAndPassword(_username, _password);
                InitializeLoggedIn.OnLoggedIn(user);
            }
            else{
                Console.WriteLine("User does not exist in our database");
            }
            return null;
        }

        public static void RegisterUser(){
            using DataContext context = new ();
            Console.Write("Enter Username:");
            string _username = Console.ReadLine();
            Console.Write("Enter Password:");
            string _password = Console.ReadLine();
            User user = new(_username, _password);
            try
            {
            context.Add(user);
            context.SaveChanges();
            RegisterCustomer(user);

            }catch (Exception ex)
            {

                UIController.ClearConsole();
                Console.WriteLine("Username already in use, try a different username");
                RegisterUser();
            }
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
            string? address = Console.ReadLine();
            Console.WriteLine("Enter first post code");
            string? postCode = Console.ReadLine();

            Customer customer = new(user.Id, name, email, address, postCode);
            context.Add(customer);
            context.SaveChanges();
        }
    }
}
