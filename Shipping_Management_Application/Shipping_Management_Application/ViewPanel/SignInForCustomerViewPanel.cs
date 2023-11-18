using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.ViewPanel
{
    public class SignInForCustomerViewPanel
    {
        private readonly DataContext _dbContext;

        public SignInForCustomerViewPanel()
        {
        }

        public SignInForCustomerViewPanel(DataContext context)
        {
            _dbContext = context;
        }
        public void GetSingInViewPanel(User user)
        {
            Console.WriteLine("---------Enter 1 Or 2---------");
            Console.WriteLine("1. Sing In ");
            Console.WriteLine("2. Sing Up ");

            string? input = Console.ReadLine();
            while (true)
            {
                switch (input)
                {
                    case "1":

                        UserRegistration userRegistration = new();
                        userRegistration.SignInCustomerHowHaveSignUp();
                        break;
                    case "2":
                        CustomerRegistration customerRegistration = new();
                        customerRegistration.RegisterCustomer(user);
                        break;

                }
            }

        }
    }
}
