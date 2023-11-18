//using Microsoft.EntityFrameworkCore;
//using Shipping_Management_Application.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Shipping_Management_Application.ViewPanel
//{
//    public class IsAdmin
//    {
//        //method to showLogin page for admin 
//        public void ShowLoginPageForAdmin()
//        {
//            Console.WriteLine("Welcome to the login page! \n Enter your username and password");
//            Console.WriteLine("UserName: ");
//            string? adminName = Console.ReadLine();
//            Console.WriteLine("Enter password: ");
//            string? adminPassword = Console.ReadLine();
//            if (string.IsNullOrEmpty(adminName) && string.IsNullOrEmpty(adminPassword))
//            {
//                Console.WriteLine("Please enter a username and password");
//                return;
//            }
//            else
//            {
//                try
//                {
//                    Console.WriteLine("I am HER");
//                    IsAdminInDatabase(adminName, adminPassword);
//                    Console.WriteLine("userNameInput added in db");
//                    Console.WriteLine("End");
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("error : " + ex.Message);
//                }
//            }
//        }

//        // method to check out for user in database
//        public string IsAdminInDatabase(string? username, string? password)
//        {
//            Console.WriteLine("DATABASE for user");
//            using (DataContext context = new())
//            {
//                var user = context.Users.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower());
//                if (user != null)
//                {
//                    // IsCustomer();
//                    return "User exists in the database!";
//                }
//                else if (username == "Admin".ToLower() && password == "Admin".ToLower())
//                {
//                    Console.WriteLine("Inside else If IamAdmin()");
//                    IamAdmin();
//                    Console.WriteLine("Outside else If IamAdmin()");
//                    return "IamAdmin";
//                }
//                else
//                {
//                    // Method to register user to the database
//                    Console.WriteLine("Welcome to Registration page! ");
//                    UserRegistration userRegistration = new();
//                    var res = userRegistration.UserRegisterPanel(user.UserName, user.Password, user.Role);
//                    try
//                    {
//                        context.Add(res);
//                        context.SaveChanges();
//                    }
//                    catch (DbUpdateException ex)
//                    {
//                        Exception? innerException = ex.InnerException;
//                        Console.WriteLine($"Error Message: {innerException?.Message}");
//                        Console.WriteLine($"Stack Trace: {innerException.StackTrace}");
//                    }
//                    Console.WriteLine("You Can try to log in with your UserName and Password! ");
//                    // ShowLoginPage();
//                    return res;
//                }
//            }
//        }

//        public string IamAdmin()
//        {
//            AdminViewPanel adminViewPanel = new();
//            adminViewPanel.AdminViewPage();
//            return "IamAdmin";
//        }
//    }
//}
