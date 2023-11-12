using System;
using System.Linq;
using Shipping_Management_Application.Data;

namespace Shipping_Management_Application.ViewPanel
{
    public class UserLogin
    {
        //method to showLogin page for customer and admin 
        public void ShowLoginPage()
        {
            Console.WriteLine("Welcome to the login page! \n Enter your username and password");
            Console.WriteLine("UserName: ");
            string userNameInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userNameInput))
            {
                Console.WriteLine("Please enter a username");
                return;
            }
            Console.WriteLine("Enter password: ");
            string passwordInput = Console.ReadLine();
            if (string.IsNullOrEmpty(passwordInput))
            {
                Console.WriteLine("Please enter a password");
                return;
            }

            try
            {
                string result = IsUserInDatabase(userNameInput);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }
        // method to check out for user in database
        public string IsUserInDatabase(string username)
        {
            using (DataContext context = new DataContext())
            {
                var user = context.Users.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower());

                if (user != null)
                {
                    return "User exists in the database!";
                }
                else
                {
                    return "User does not exist in the database!";
                }
            }
        }
    }
}
