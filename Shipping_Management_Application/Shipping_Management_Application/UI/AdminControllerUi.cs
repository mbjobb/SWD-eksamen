using Microsoft.EntityFrameworkCore;

using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data.Entities;

namespace Shipping_Management_Application.UI
{
    /// <summary>
    /// AdminControllerUi class with the methods that are used in the UI. 
    /// </summary>
    public static class AdminControllerUi
    {
        internal static AdminController AdminController = new();
        // manages the admin menu and calls the methods from the AdminController class.
        public static void ManageUsers(UserEntity user)
        {
            bool running = true;
            while (running)
            {

                List<string> options = new()
                {
                "List all registerd users",
                "Delete a user",
                "Create a new admin account",
                "Account settings",
                "Return"
                };
                UIController.DrawMenu(options);


                char input = UIController.ReadASingleKeyPress("12345");

                switch (input)
                {
                    case '1':
                        {
                            IEnumerable<UserEntity> users = AdminController.GetAllUserEntities();
                            foreach (var userEntity in users)
                            {
                                Console.WriteLine(userEntity);
                            }
                            break;
                        }
                    case '2':
                        {
                            Console.WriteLine("select a user by username or id");
                            Console.Write("username or id: ");
                            string? idOrUsername = Console.ReadLine();
                            long id = 0;

                            try
                            {
                                id = (long)Convert.ToInt64(idOrUsername);
                                idOrUsername = null;

                            }
                            catch (FormatException)
                            {
                                //This is fine
                            }

                            UserEntity userToManage = InitializeApp.userController.GetUserEntityByIdOrUsername(id, idOrUsername);
                            Console.WriteLine($"user found : ID:{userToManage.Id} Username: {userToManage.UserName}");
                            Console.WriteLine($"would you like to delete {userToManage.UserName}");
                            Console.WriteLine("(y/n)");
                            char yesNo = UIController.ReadASingleKeyPress("yn");
                            if (yesNo == 'y') InitializeApp.userController.DeleteUserEntity(userToManage); else ManageUsers(user);

                            break;
                        }
                    case '3':
                        {
                            Console.Write("Username for new admin:");
                            string? username = UIController.ReadAStringInput();
                            Console.Write("Password for new admin:");
                            string? password = UIController.ReadAStringInput();
                            try
                            {
                                UserEntity admin = AdminController.CreateAdmin(username, password);
                                Console.WriteLine($"New admin created. \n ID:{admin.Id} Username:{username}");

                            }
                            catch (DbUpdateException e)
                            {

                                Console.WriteLine("username already exists, please try a different username");
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case '4':
                        {
                            Console.WriteLine("enter new pasword");
                            string value = UIController.ReadAStringInput();
                            InitializeApp.userController.UpdateUserEntityPassword(user, value);
                            break;
                        }
                    case '5':
                        {
                            running = false;
                            InitializeLoggedInAsAdmin.OnLoggedIn(user);
                            break;
                        }
                }
            }

        }
    }
}
