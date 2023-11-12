using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;

namespace Shipping_Management_Application.ViewPanel
{
    public class UserRegistration
    {
        //Method to UserRegistration
        public string UserRegisterPanel()
        {
            Console.WriteLine("Welcome to the registration page! Please follow the instructions.");
            Console.WriteLine("Enter UserName: ");
            string _userName = Console.ReadLine();
            Console.WriteLine("Enter password");
            string _password = Console.ReadLine();

            if (!string.IsNullOrEmpty(_userName) && !string.IsNullOrEmpty(_password))
            {
                using (DataContext context = new DataContext())
                {
                    try
                    {
                        var newUser = new User (_userName, _password);
                        context.Users.Add(newUser);
                        context.SaveChanges();
                        Console.WriteLine("User added to the database!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error to adding the user: " + ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Please Enter username and password to register.");
            }
            return "Registration Is secsusfulld";
        }
    }
}
