using Shipping_Management_Application.Data;
using Shipping_Management_Application.BuisnessLogic.User;
using System;
using System.Linq;

namespace Shipping_Management_Application.ViewPanel
{
    public class UserRegistration
    {
        private readonly DataContext? _context;

        public UserRegistration(DataContext? context){
            _context = context;
        }

        public User CreateUser(string userName, string password, string role)
        {
            var existingUser = _context.UserEntities.OfType<User>().FirstOrDefault(u => u.UserName == userName);
            if (existingUser != null)
            {
                Console.WriteLine("User already exists.");
                return null;
            }

            var user = new User(userName, password) { Role = role };
            _context.UserEntities.Add(user);
            _context.SaveChanges();

            return user;
        }

        public string UserRegisterPanel()
        {
            Console.WriteLine("Welcome to the user registration page! Please follow the instructions.");
            Console.WriteLine("Enter Username: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            Console.WriteLine("Are you an Admin? (yes or no)");
            string userInput = Console.ReadLine();

            string role = userInput?.ToLower() == "yes" ? "Admin" : "Customer";
            User user = CreateUser(userName, password, role);

            if (user == null)
            {
                return "Registration failed.";
            }

            if (role == "Customer")
            {
                // If the user is a customer, also register them as a customer
                CustomerRegistration customerRegistration = new();
                customerRegistration.RegisterCustomer();
            }

            Console.WriteLine("Registration is successful.");
            return "Registration is successful.";
        }
    }
}
