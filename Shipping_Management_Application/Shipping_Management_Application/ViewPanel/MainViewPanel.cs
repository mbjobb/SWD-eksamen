using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;

namespace Shipping_Management_Application.ViewPanel
{
    public class MainViewPanel
    {
        private bool _exitProgram = false;

        public void MainView()
        {
            InfoAboutOurApp _infoAboutOurApp = new();
            LoadingView _loadingView = new();

            _infoAboutOurApp.HeaderComponent();
            _loadingView.Print("Loading...");
            _infoAboutOurApp.WelcomeMesseag();
            _infoAboutOurApp.About();

            // Menu 
            while (!_exitProgram)
            {
                Console.WriteLine("----------- Enter your Choice! 1, 2, or 3");
                Console.WriteLine("----------- 1. SignIn / Register ");
                Console.WriteLine("----------- 2. Admin");
                Console.WriteLine("----------- 3. Exit");

                var userInput = Console.ReadLine();

                if (!IsValidInput(userInput))
                {
                    Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
                    continue;
                }

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Sign In page for Customer");
                        User user = new User("", "", "");   
                        SignInForCustomerViewPanel signInForCustomerViewPanel = new();
                        signInForCustomerViewPanel.GetSingInViewPanel(user);
                        break;
                    case "2":
                        Console.WriteLine("Sign In page for Admin");
                        UserRegistration userRegistration = new();
                        userRegistration.SignInAdmin();
                        break;
                    case "3":
                        Console.WriteLine("Do you want to Exit Program? (yes/no)");
                        string? input = Console.ReadLine();
                        if (input?.ToLower() == "yes")
                        {
                            Console.WriteLine("Exiting....\nProgram finished");
                            _exitProgram = true;
                            return;
                        }
                        else if (input?.ToLower() == "no")
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Please enter 'yes' to exit or 'no' to return to the main menu.");
                        }
                        break;
                }




            }
            _exitProgram = false;
        }

        // Method to check if user input is valid or not 
        private static bool IsValidInput(string input)
        {
            return input == "1" || input == "2" || input == "3";
        }
        // if user in db
        public void IsUserInDatabase(User user)
        {
            using (DataContext dataContext = new())
            {

                try
                {
                    // Check if the user already exists in the database
                    var existingUser = dataContext.Users.FirstOrDefault(u => u.UserName == user.UserName);

                    if (existingUser != null && existingUser.UserName == user.UserName)
                    {
                        Console.WriteLine("Welcome....");
                    }
                    Console.WriteLine("error");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

    }
}
    
         
              
                    
                   