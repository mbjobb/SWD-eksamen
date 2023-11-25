using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System.Security.AccessControl;

namespace Shipping_Management_Application.UI{
    internal class UserControllerUI{
        public static UserController userController = new UserController();
        public static void Login(){
            
            using DataContext context = new ();
            
            Console.Write("Enter Username:");
            string? _username = Console.ReadLine();
            Console.Write("Enter Password:");
            string? _password = Console.ReadLine();

            //Placeholder for proper authentication since actual implimentation of something like OAuth is outside the scope of this subject.
            LoginAuthentication loginAuthentication = new LoginAuthentication();
            bool isAuthenticated = loginAuthentication.Authentication(_username, _password);


            if (CrudOperations.CheckIfUserExists(_username, _password) && isAuthenticated)
            {
                UserEntity user = CrudOperations.GetUserByUserNameAndPassword(_username, _password);
                Console.WriteLine(user);
                InitializeLoggedIn.OnLoggedIn(user);
            }
            else{
                Console.WriteLine("User does not exist in our database");
            }
            
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

            }catch (Exception ex)
            {

                UIController.ClearConsole();
                Console.WriteLine("Username already in use, try a different username");
                RegisterUser();
            }
        }

        public static void RegisterCustomer(UserEntity user){
            
            
            
            
            Console.WriteLine("Enter first name");
            string? name = Console.ReadLine();
            Console.WriteLine("Enter first email");
            string? email = Console.ReadLine();
            Console.WriteLine("Enter first adress");
            string? address = Console.ReadLine();
            Console.WriteLine("Enter first post code");
            string? postCode = Console.ReadLine();

            Customer customer = userController.CreateCustomer(user.Id, name, email, address, postCode);

        }
    }
}
