//using Microsoft.EntityFrameworkCore;
//using Shipping_Management_Application.BuisnessLogic.User;
//using Shipping_Management_Application.Data;
//using System;
//using System.Linq;

//namespace Shipping_Management_Application.ViewPanel
//{
//    public class IsCustomer
//    {
//        // Method to show sign in page for customer 
//        public void ShowLoginPageForCustomer()
//        {
//            Console.WriteLine("Welcome to the Sign In page!");
//            Console.WriteLine();
//            Console.WriteLine("Enter UserName: ");
//            string? customerName = Console.ReadLine();
//            Console.WriteLine("Enter password: ");
//            string? customerPassword = Console.ReadLine();
//            Console.WriteLine();

//            if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerPassword))
//            {
//                Console.WriteLine("Please enter a valid username and password");
//                return;
//            }
//            else
//            {
//                try
//                {
//                    Console.WriteLine("I am HERE AuthenticateCustomer");
//                    AuthenticateCustomer(customerName, customerPassword);
//                    Console.WriteLine("End i had  AuthenticateCustomer");
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("error: " + ex.Message);
//                }
//            }
//        }
//        public void AuthenticateCustomer(string? username, string? password)
//        {
//            Console.WriteLine("DATABASE for user");
//            using (DataContext context = new())
//            {
//                var user = context.Users.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower());

//                if (user != null)
//                {
//                    if (user.Password.ToLower() == password.ToLower())
//                    {
//                        Console.WriteLine("Customer logged in successfully!");
//                        CustomerViewPanel customerViewPanel = new();
//                        customerViewPanel.CustomerMainView(); // Pass the logged-in user to IamCustomer
//                    }
//                    else
//                    {
//                        Console.WriteLine("Invalid password. Please try again.");
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("Welcome to Registration page! ");
//                    UserRegistration userRegistration = new();
//                    var registeredUser = userRegistration.UserRegisterPanel(username, password, "Customer");


//                    try
//                    {
//                        context.Add(registeredUser);
//                        context.SaveChanges();
//                        Console.WriteLine("Customer registered successfully! You can now log in.");
//                        CustomerViewPanel customerViewPanel = new();
//                        customerViewPanel.CustomerMainView(); // Pass the registered user to IamCustomer
//                    }
//                    catch (DbUpdateException ex)
//                    {
//                        Exception? innerException = ex.InnerException;
//                        Console.WriteLine($"Error Message: {innerException?.Message}");
//                        Console.WriteLine($"Stack Trace: {innerException.StackTrace}");
//                    }
//                }
//            }
//        }

      
//    }
//}



//public string AuthenticateCustomer(string? username, string? password)
//{
//    Console.WriteLine("DATABASE for user");
//    using (DataContext context = new())
//    {
//        var user = context.Users.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower()) u => u.Password.Tolower() == password.ToLower());



//        if (user != null)
//        {
//            IamCustomer();
//            return "Customer signed in successfully!";
//        }
//        else
//        {
//            Console.WriteLine("Please Enter your information for Registration!");
//            Console.WriteLine();
//            Thread.Sleep(1000);
//            Console.WriteLine("Welcome to Registration page! ");
//            UserRegistration userRegistration = new();
//            var res = userRegistration.UserRegisterPanel(username, password, "Customer");
//            try
//            {
//                context.Add(res);
//                context.SaveChanges();
//            }
//            catch (DbUpdateException ex)
//            {
//                Exception? innerException = ex.InnerException;
//                Console.WriteLine($"Error Message: {innerException?.Message}");
//                Console.WriteLine($"Stack Trace: {innerException.StackTrace}");
//            }
//            Console.WriteLine("You can try to log in with your UserName and Password! ");
//           return "";
//        }
//    }
//}


