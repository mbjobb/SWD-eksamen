using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Linq;

namespace Shipping_Management_Application.ViewPanel
{
    public class UserRegistration{
        private User _user;
        private CustomerRegistration _customerRegistration;

        public string UserRegisterPanel(){
            Console.WriteLine("Welcome to the registration page! Please follow the instructions.");
            Console.WriteLine("Enter UserName: ");
            string? userName = Console.ReadLine();
            Console.WriteLine("Enter password");
            string? password = Console.ReadLine();
            
            Console.WriteLine("Are you an Admin? (yes or no)");
            string? userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || userInput?.ToLower() == "no"){
                _user = new User(userName, password);
                _user.Role = "Customer";

                using (DataContext context = new DataContext()){
                    var existingUser = context.Users.FirstOrDefault(u => u.UserName == userName);
                    if (existingUser != null){
                        Console.WriteLine("User already exists.");
                    }
                    else{
                        context.UserEntities.Add(_user);
                        context.SaveChanges();
                        Console.WriteLine("User added to the database!");
                        // Register Customer if not found in database
                        _customerRegistration = new CustomerRegistration();
                        _customerRegistration.RegisterCustomer();
                    }
                }
            }
            else{
                _user = new User(userName, password); // Using 'User' for admin as well
                _user.Role = "admin";
                using (DataContext context = new DataContext()){
                    context.Users.Add(_user);
                    context.SaveChanges();
                }

                Console.WriteLine("Admin registered successfully.");
            }
            return "Registration Is successful";
        }
    }
}

