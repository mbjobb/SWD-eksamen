using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
using Shipping_Management_Application.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application
{
    public class PreRefactorUserController
    {
        /// <summary>
        /// Refactoring example.
        /// This was a method written late at night, two days before the exam due date, which violated several of our design prinsipals.
        /// We let it stand since it worked, and tech debt can be allowed if it helps with upholding deadlines,
        /// but we ended up having time to refactor, and chose this one of the focus for said refactoring.
        /// 
        /// the prinicples it violates:
        /// 1. SOLID Single-responsibility principle. This handles input/output from/to user, and the writing to the database.
        /// 2. SOLID Open–closed principle. Expanding the functionality would require changing both the UI drwing as well as the switch case
        /// 3. 
        /// </summary>
        public void UpdateCustomer(UserEntity user)
        {
            Customer customer = InitializeApp.userController.GetCustomer(user);
            Console.WriteLine("You can update your profile");
            Console.WriteLine("What do you want to update? (Email, Address, PostCode, Password)");
            string? res = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(res))
            {
                Console.WriteLine("Invalid input, please try again");
                return;
            }
            try
            {
                //TODO: se if we can dry this off
                //if (res is "email" or "address" or "postcode" ) 
                //{
                //    using DataContext context = new DataContext();
                //    Console.WriteLine($"enter new {res}");
                //    string input = Console.ReadLine();
                //    context.Customers.First(c => c.Id == customer.Id).Valueof(res) = input;
                //}
                switch (res.ToLower())
                {

                    case "email":
                        Console.WriteLine("Enter the new email:");
                        string? newEmail = Console.ReadLine();
                        customer.Email = newEmail;
                        Console.WriteLine("Email updated successfully");
                        break;
                    case "address":
                        Console.WriteLine("Enter the new address:");
                        string? newAddress = Console.ReadLine();
                        customer.Adress = newAddress;
                        Console.WriteLine("Address updated successfully");
                        break;
                    case "postcode":
                        Console.WriteLine("Enter the new postcode:");
                        string? newPostCode = Console.ReadLine();
                        customer.PostCode = newPostCode;
                        Console.WriteLine("Postcode updated successfully");
                        break;
                    case "password":
                        Console.WriteLine("Enter the new postcode:");
                        string? newPassword = Console.ReadLine();
                        user.Password = newPassword;
                        Console.WriteLine("Postcode updated successfully");
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

            }
            catch (DbUpdateException)
            {

                Console.WriteLine("something went wrong");
            }
        }


    }
}
