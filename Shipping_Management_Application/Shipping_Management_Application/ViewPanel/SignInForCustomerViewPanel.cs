using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;

namespace Shipping_Management_Application.ViewPanel
{
    public class SignInForCustomerViewPanel
    {

        public SignInForCustomerViewPanel()
        {
        }


        public void GetSingInViewPanel(User user)
        {
            while (true)
            {
                Console.WriteLine("---------Enter 1 or 2---------");
                Console.WriteLine("1. Sign In");
                Console.WriteLine("2. Sign Up");
              

                string? input = Console.ReadLine();

                if (IsValidInput(input))
                {
                    switch (input)
                    {
                        case "1":
                            UserRegistration userRegistration = new UserRegistration();
                            userRegistration.SignInCustomerHowHaveSignUp();
                            break;
                        case "2":
                            CustomerRegistration customerRegistration = new CustomerRegistration();
                            customerRegistration.CheckCustomerBeforeRegistration(user);
                            break;
                       
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid option (1 or 2).");
                }
            }
        }

        // Method to check if user input is valid or not 
        private static bool IsValidInput(string input)
        {
            return input == "1" || input == "2";
        }
    }
}
