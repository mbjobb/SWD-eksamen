using System;
using System.Linq;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.Data;

namespace Shipping_Management_Application.ViewPanel
{
    public class UserLogin
    {
        
        private UserRegistration registration = new(context: new DataContext());
        private CustomerRegistration _customerRegistration = new();
        //method to showLogin page for customer and admin 
        public void ShowLoginPage()
        {
            Console.WriteLine("Welcome to the login page! \n Enter your username and password");
            Console.WriteLine("UserName: ");
            string userNameInput = Console.ReadLine();
            if (string.IsNullOrEmpty(userNameInput)){
                Console.WriteLine("Please enter a username");
                return;
            }
            Console.WriteLine("Enter password: ");
            string passwordInput = Console.ReadLine();
            if (string.IsNullOrEmpty(passwordInput)){
                Console.WriteLine("Please enter a password");
                return;
            }

            try{
                Console.WriteLine("I am HER");
                IsUserInDatabase(userNameInput);
                Console.WriteLine("End");

                //Console.WriteLine(result);
                //Testing Debuging 
                //bool result = true;
                //registration.UserRegisterPanel();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error : " + ex.Message);
            }
        }
        // method to check out for user in database
        public string IsUserInDatabase(string username){
            Console.WriteLine("DATABASE");
            using (DataContext context = new ())
            {
                var user = context.Users.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower());

                if (user != null){
                    return "User exists in the database!";
                }
                else
                {
                    //Method to register user to database
                    Console.WriteLine("Welcome to Registration page! ");
                    var res = registration.UserRegisterPanel();
                    try{
                        context.Add(res);
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" An error :" + e.Message);
                    }
                    Console.WriteLine("You Can to try to login with your UserName and Password! ");
                    ShowLoginPage();
                    return res;
                }
            }
        }
    }
}
