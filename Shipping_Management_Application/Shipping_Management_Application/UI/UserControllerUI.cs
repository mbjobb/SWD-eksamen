using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
using System.Security.AccessControl;

namespace Shipping_Management_Application.UI
{
    internal class UserControllerUI{
        /// <summary>
        /// Dependancy injection continued 4/6
        /// This is where the actual dependency injection starts to happen.
        /// Login() creates a object derived from the UserEntity base class,
        /// and that derived object is then passed as an argument for further
        /// method calls, thus method dependancy injection is accomplished.
        /// <see cref="InitializeLoggedIn"/>
        /// </summary>

        public static void Login(IUserController userController){
            Console.Write("Enter Username:");
            string? username = Console.ReadLine();
            Console.Write("Enter Password:");
            string? password = Console.ReadLine();

            //Placeholder for proper authentication since actual implimentation of something like OAuth is outside the scope of this subject.
            LoginAuthentication loginAuthentication = new LoginAuthentication();
            bool isAuthenticated = loginAuthentication.Authentication(username, password);
            bool matchFound = userController.UsernameAndPasswordMatchFoundInDB(username, password);

            if (matchFound && isAuthenticated)
            {
                UserEntity user = userController.GetUserEntityByUsernameAndPassword(username, password);
                if (user.Role == "Admin") { InitializeLoggedInAsAdmin.OnLoggedIn(user); }
                InitializeLoggedIn.OnLoggedIn(user);
            }
            else{
                Console.WriteLine("User does not exist in our database");
            }
        }
        public static UserEntity RegisterUser(IUserController userController){
            Console.Write("Enter Username:");
            string? username = Console.ReadLine();
            Console.Write("Enter Password:");
            string? password = Console.ReadLine();
            User user = new(username, password);
            
            try{
            userController.CreateUser(username,password);

            }catch (Exception ex){

                UIController.ClearConsole();
                Console.WriteLine("Username already in use, try a different username" + ex.Message);
                RegisterUser(userController);
            }
            return user;
        }

        public static void RegisterCustomer(IUserController userController, UserEntity user){
            
            Console.WriteLine("Enter first name");
            string? name = Console.ReadLine();
            Console.WriteLine("Enter first email");
            string? email = Console.ReadLine();
            Console.WriteLine("Enter first adress");
            string? address = Console.ReadLine();
            Console.WriteLine("Enter first post code");
            string? postCode = Console.ReadLine();

            userController.CreateCustomer(user.Id, name, email, address, postCode);
            Console.WriteLine("Customer created");

        }
    }
}
