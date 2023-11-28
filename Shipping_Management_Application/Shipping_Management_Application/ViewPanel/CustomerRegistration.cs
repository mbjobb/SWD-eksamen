using Shipping_Management_Application.Data;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic.User;

namespace Shipping_Management_Application.ViewPanel
{
    public class CustomerRegistration
    {
        public string CheckCustomerBeforeRegistration(User user)
        {
            do
            {
                Console.WriteLine("Please check if username and password available before proceeding to registration");
                Console.WriteLine("");
                Console.WriteLine("Enter UserName: ");
                string? username = Console.ReadLine();

                Console.WriteLine("Enter password: ");
                string? password = Console.ReadLine();

                using (DataContext context = new())
                {
                    try
                    {
                        var existingUser = context.Users.FirstOrDefault(u => u.UserName == username);

                        if (existingUser != null && existingUser.Password == password)
                        {
                            Console.WriteLine("Customer logged in successfully!");
                            CustomerViewPanel customerViewPanel = new();
                            customerViewPanel.CustomerMainView(existingUser);
                            return "Customer logged in successfully!";
                        }
                        else if (existingUser != null)
                        {
                            Console.WriteLine("Incorrect password. Please try again.");
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Username and password available. You may proceed with the registration form!");
                            RegisterCustomer();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        return "Registration failed";
                    }
                }
            } while (true);
        }

        public void RegisterCustomer()
        {
            Console.WriteLine("Welcome to the customer registration page! Please follow the instructions.");
            Console.WriteLine("Enter UserName: ");
            string? username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string? password = Console.ReadLine();

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

            bool isInputValid = !string.IsNullOrEmpty(username) &&
                                !string.IsNullOrEmpty(password) &&
                                !string.IsNullOrEmpty(firstName) &&
                                !string.IsNullOrEmpty(lastName) &&
                                !string.IsNullOrEmpty(address) &&
                                !string.IsNullOrEmpty(city) &&
                                !string.IsNullOrEmpty(region) &&
                                !string.IsNullOrEmpty(postalCode) &&
                                !string.IsNullOrEmpty(country) &&
                                !string.IsNullOrEmpty(phone) &&
                                !string.IsNullOrEmpty(email);

            if (isInputValid)
            {
                using (DataContext context = new())
                {
                    using var transaction = context.Database.BeginTransaction();
                    try
                    {
                        var existingUser = context.Users.FirstOrDefault(u => u.UserName == username);

                        if (existingUser != null)
                        {
                            Console.WriteLine("The username already exists!");
                            CustomerViewPanel customerViewPanel = new();
                            customerViewPanel.CustomerMainView(existingUser);
                        }
                        else
                        {
                            User newUser = new User(username, password);
                            context.Users.Add(newUser);
                            context.SaveChanges();

                            Customer customer = new Customer(firstName, lastName, address, city, region, postalCode, country, phone, email)
                            {
                                CustomerId = newUser.Id,
                                User = newUser
                            };

                            context.Customers.Add(customer);
                            context.SaveChanges();
                            transaction.Commit();
                            Console.Clear();
                            Thread.Sleep(2000);
                            Console.WriteLine("Please Sign In...");
                            UserRegistration userRegistration = new();
                            userRegistration.SignInCustomerHowHaveSignUp();
                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        Exception? innerException = ex.InnerException;
                        Console.WriteLine($"Error Message: {innerException?.Message}");
                        Console.WriteLine($"Stack Trace: {innerException?.StackTrace}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid registration input! Please try again.");
            }
        }
    }
}
