using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
using Shipping_Management_Application.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.BuisnessLogic.Controllers
{
    /// <summary>
    /// UserController class with the methods that are used in the UI.
    /// </summary>
    public class UserController : IUserController
    {
        public Customer CreateCustomer(long id, string? name, string? email, string? address, string? postCode)
        {
            Customer customer = new Customer(id, name, email, address, postCode);
            CrudOperations.CreateCustomer(customer);
            return customer;

        }

        public UserEntity CreateUser(string username, string password)
        {
            UserEntity user = new User(username, password);
            CrudOperations.CreateUser(user);
            return user;
        }
        public UserEntity GetUserEntityByUsernameAndPassword(string username, string password)
        {
            UserEntity user = CrudOperations.GetUserByUserNameAndPassword(username, password);
            return user;
        }
        public bool UsernameAndPasswordMatchFoundInDB(string username, string password)
        {
            bool matchFound = CrudOperations.CheckIfUserExists(username, password);
            return matchFound;
        }
        public UserEntity GetUserEntityByIdOrUsername(long id = 0, string? username = null)
        {
            if (id != 0) { return CrudOperations.GetUserEntityById((long)id); }
            if (username is not null) { return CrudOperations.GetUserEntityByUsername(username); }
            else return null;
        }
        public void DeleteUserEntity(UserEntity user)
        {
            CrudOperations.DeleteUserEntity(user);
        }
        public Customer GetCustomer(UserEntity user)
        {
            return CrudOperations.GetCustomerById(user.Id);

        }
        public Customer UpdateCustomer(Customer customer)
        {
            return CrudOperations.UdateCustomer(customer);
        }
        public void UpdateCustomer(UserEntity user)
        {
            Customer customer = InitializeApp.userController.GetCustomer(user);
            //Console.WriteLine("You can update your profile");
            //Console.WriteLine("What do you want to update? (Email, Address, PostCode, Password)");
            //string? res = Console.ReadLine();
            List<string> options = new List<string>()
            {
                "You can update your profile",
                "What do you want to update? (Email, Address, PostCode, Password)"

            };
            List<string> validInput = new List<string>()
            {
                "Email",
                "Address",
                "PostCode",
                "Password"
            };
            string res = UIController.MenuFacade(options, validInput);
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
