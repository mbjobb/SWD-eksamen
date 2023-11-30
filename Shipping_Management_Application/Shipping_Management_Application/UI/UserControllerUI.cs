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
            string username = UIController.ReadAStringInput();
            Console.Write("Enter Password:");
            string password = UIController.ReadAStringInput();

            //Placeholder for proper authentication since actual implimentation of something like OAuth is outside the scope of this subject.
            LoginAuthentication loginAuthentication = new LoginAuthentication();
            bool isAuthenticated = loginAuthentication.Authentication(username, password);

            //Checks database for match
            bool matchFound = userController.UsernameAndPasswordMatchFoundInDB(username, password);

            if (matchFound && isAuthenticated)
            {
                UserEntity? user = userController.GetUserEntityByUsernameAndPassword(username, password);
                UIController.ClearConsole();
                if (user.Role == "Admin") { InitializeLoggedInAsAdmin.OnLoggedIn(user); }
                InitializeLoggedIn.OnLoggedIn(user);
            }
            else{
                Console.WriteLine("User does not exist in our database");
            }
        }
        public static UserEntity RegisterUser(IUserController userController){
            Console.Write("Enter Username:");
            string? username = UIController.ReadAStringInput();
            Console.Write("Enter Password:");
            string password = UIController.ReadAStringInput();
            User user = new(username, password);
            
            try{
                userController.CreateUser(username,password);
                InitializeApp.OnStartup(userController);

            }catch (Exception ex){

                UIController.ClearConsole();
                Console.WriteLine("Username already in use, try a different username" + ex.Message);
                RegisterUser(userController);
            }
            return user;
        }

        public static Customer RegisterCustomer(IUserController userController, UserEntity user){
            
            Console.WriteLine("Enter name");
            string? name = UIController.ReadAStringInput();
            Console.WriteLine("Enter email");
            string? email = UIController.ReadAStringInput();
            Console.WriteLine("Enter adress");
            string? address = UIController.ReadAStringInput();
            Console.WriteLine("Enter post code");
            string? postCode = UIController.ReadAStringInput();

            Customer? customer = userController.CreateCustomer(user.Id, name, email, address, postCode);
            if (customer is not null) { Console.WriteLine($"Customer created \n {customer}"); }
            return customer ?? throw new NullReferenceException();

        }
        /// <summary>
        /// After refatoring
        /// The method has been seperated with multiple methods in their appropriate layers
        /// this is the UI part, it handles input from user and then sends to the buisness logic layer
        /// <see cref="UserController.UpdateCustomerWithValues"/>
        /// </summary>

        public static void UpdateCustomer(IUserController userController, UserEntity user)
        {
            Customer customer = InitializeApp.userController.GetCustomer(user);

            List<string> options = new List<string>()
            {
                
                "What do you want to update? (Email, Home Address, Post code, Password)"

            };
            List<string> validInput = new List<string>()
            {
                "Email",
                "Address",
                "PostCode",
                "Password"
            };
            string? inputOption = UIController.MenuFacade(options, validInput);
            Console.WriteLine($"please enter new {inputOption}");
            string inputValueToChange = UIController.ReadAStringInput();
            if(inputOption is not "Password" && customer is null)
            {
                Console.WriteLine("You need to register as a customer to manage customer profile");
                return;
            }
            else if (inputOption == "Password")
            {
                userController.UpdateUserEntityPassword(user, inputValueToChange);
            }
            else
            {
                userController.UpdateCustomerWithValues(customer, inputOption, inputValueToChange);

            }






        }

    }
}
