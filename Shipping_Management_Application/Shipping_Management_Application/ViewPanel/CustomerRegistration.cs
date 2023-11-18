using Shipping_Management_Application.Data;
using System;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Microsoft.EntityFrameworkCore;

namespace Shipping_Management_Application.ViewPanel
{
    public class CustomerRegistration
    {
        //private Customer? _customer = new();
        //private UserRegistration? _userRegistration = new();
        // Method to register customer
        public void RegisterCustomer(User user)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the customer registration page! Please follow the instructions.");

            // Add prompts for userName and password
            string? _password = user.Password;
            string? _userName = user.UserName;
            long? _id = user.Id;


            // Gather user details
            Console.WriteLine("Enter First Name:");
            string? firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string? lastName = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            string? address = Console.ReadLine();
            Console.WriteLine("Enter City:");
            string? city = Console.ReadLine();
            Console.WriteLine("Enter Region:");
            string? region = Console.ReadLine();
            Console.WriteLine("Enter Postal Code:");
            string? postalCode = Console.ReadLine();
            Console.WriteLine("Enter Country:");
            string? country = Console.ReadLine();
            Console.WriteLine("Enter Phone Number:");
            string? phone = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            string? email = Console.ReadLine();

           
            //check out is alle staff is not null
            bool CustomerLogik = !string.IsNullOrEmpty(firstName) &&
                                 !string.IsNullOrEmpty(lastName) &&
                                 !string.IsNullOrEmpty(address) &&
                                 !string.IsNullOrEmpty(city) &&
                                 !string.IsNullOrEmpty(region) &&
                                 !string.IsNullOrEmpty(postalCode) &&
                                 !string.IsNullOrEmpty(country) &&
                                 !string.IsNullOrEmpty(phone) &&
                                 !string.IsNullOrEmpty(email);

            if (CustomerLogik)
            {
                using (DataContext context = new())
                {
                    using var transaction = context.Database.BeginTransaction();
                    try
                    {
                        Console.WriteLine("userEntity before adding in db");
                        User newUser = new User(_userName, _password);
                        context.UserEntities.Add(newUser);
                        Console.WriteLine("userEntity adding in db");
                        context.SaveChanges();
                        Console.WriteLine("userEntity saved in db");

                        Customer _customer = new Customer(firstName, lastName, address, city, region, postalCode, country, phone, email)
                        {
                            CustomerId = newUser.Id,
                            //User = new User(_userName, _password)
                        };
                        context.Add(_customer);
                        context.SaveChanges();
                        transaction.Commit();
                        Console.Clear();
                        Thread.Sleep(2000);
                        Console.WriteLine( " Please SignIn ...");
                        UserRegistration userRegistration = new();
                        userRegistration.SignInCustomer();
                        //Console.WriteLine($" Welcome {_customer.FirstName} ");
                        //Console.WriteLine();
                        //CustomerViewPanel customerViewPanel = new();
                        //customerViewPanel.CustomerMainView(_customer);

                    }
                    catch (DbUpdateException ex)
                    {
                        Exception? innerException = ex.InnerException;
                        Console.WriteLine($"Error Message: {innerException.Message}");
                        Console.WriteLine($"Stack Trace: {innerException.StackTrace}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Registration field! Please try agin! ");
            }
        }
    }
}