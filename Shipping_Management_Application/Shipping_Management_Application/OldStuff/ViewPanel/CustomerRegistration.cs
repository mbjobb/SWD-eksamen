﻿using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
using System;

namespace Shipping_Management_Application.OldStuff.ViewPanel
{
    public class CustomerRegistration
    {
        Customer _customer;

        // Method to register customer
        public void RegisterCustomer()
        {
            Console.WriteLine("Welcome to the customer registration page! Please follow the instructions.");

            // Gather user details
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter Region:");
            string region = Console.ReadLine();
            Console.WriteLine("Enter Postal Code:");
            string postalCode = Console.ReadLine();
            Console.WriteLine("Enter Country:");
            string country = Console.ReadLine();
            Console.WriteLine("Enter Phone Number:");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();
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
                using (DataContext context = new DataContext())
                {
                    //try
                    //{
                    //    _customer = new Customer(firstName, lastName, address, city, region, postalCode, country, phone, email);
                    //    context.Add(_customer);
                    //    context.SaveChanges();
                    //    Console.WriteLine("Customer added to the database!");
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine("An error to adding the customer: " + ex.Message);
                    //}
                }
            }
            else
            {
                Console.WriteLine("Please register a customer.");
            }
        }
    }
}
