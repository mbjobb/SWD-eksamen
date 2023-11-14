using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Linq;

namespace Shipping_Management_Application.ViewPanel
{
    public class UserRegistration
    {
        User _user;
        UserEntity _userEntity;
        CustomerRegistration _customerRegistration;

        public string UserRegisterPanel()
        {
            Console.WriteLine("Welcome to the registration page! Please follow the instructions.");
            Console.WriteLine("Enter UserName: ");
            string? userName = Console.ReadLine();
            Console.WriteLine("Enter password");
            string? password = Console.ReadLine();

            // We check if the user is an admin
            Console.WriteLine("Are you an Admin? (yes or no)");
            string? userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || userInput?.ToLower() == "no"){
                _user = new User(userName, password);
                _user.Role = "Customer";

                using (DataContext context = new())
                {
                    var existingUser = context.Users.FirstOrDefault(u => u.UserName == userName);
                    if (existingUser != null){
                        Console.WriteLine("User already exists.");
                    }
                    else{
                        Console.WriteLine("i am here");
                        context.Users.Add(_user);
                        //  it must Debug 
                        Console.WriteLine("added");
                        context.SaveChanges();
                        Console.WriteLine("saved");
                        Console.WriteLine("User added to the database!");
                        // Registre Customer if not found in database
                        _customerRegistration = new CustomerRegistration();
                        _customerRegistration.RegisterCustomer();
                    }
                }
            }
            else{
                _user = new(userName, password);
                _user.Role = "admin";
                Console.WriteLine(_user.UserName, _user.Role);
            }
            return "Registration Is successful";
        }
    }
}
