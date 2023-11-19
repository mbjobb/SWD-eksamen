using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.ViewPanel;
using System;
using System.Data.Common;

public class UserRegistration
{
   public string? _Username;
   public string? _Password;

    // Method for customer how have signup before
    public string SignInCustomerHowHaveSignUp()
    {
        Console.WriteLine("Welcome to the Customer registration page! Please follow the instructions.");
        do
        {
            Console.WriteLine("Enter UserName: ");
            _Username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            _Password = Console.ReadLine();

            using (DataContext context = new())
            {
                try
                {
                    // Check if the user already exists in the database
                    var existingUser = context.Users.FirstOrDefault(u => u.UserName == _Username);

                    if (existingUser != null && existingUser.Password == _Password)
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
                        Console.WriteLine("Please Try to signup!");
                        UserRegistration userRegistration = new();
                        userRegistration.SignUpCustomer();

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



    // Method for Customer registration
    public string SignUpCustomer()  
 {
        Console.WriteLine("Welcome to the Customer registration page! Please follow the instructions.");
        do
        {
            Console.WriteLine("Enter UserName: ");
            _Username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            _Password = Console.ReadLine();

            using (DataContext context = new())
            {
                try
                {
                    // Check if the user already exists in the database
                    var existingUser = context.Users.FirstOrDefault(u => u.UserName == _Username);

                    if (existingUser != null && existingUser.Password == _Password)
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
                        // User does not exist, proceed with registration
                        User user = new User(_Username, _Password);
                        user.Role = "Customer";
                        Console.WriteLine("Customer added to the database!");

                        CustomerRegistration customerRegistration = new();
                        customerRegistration.RegisterCustomer(user);
                        return "Customer registration is successful!";
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


    // Method for Admin registration
    public string SignInAdmin()
    {
        Console.WriteLine("Welcome to the Admin registration page! Please follow the instructions.");

        string correctAdminUsername = "admin";
        string correctAdminPassword = "admin";

        string? enteredUsername;
        string? enteredPassword;

        do
        {
            Console.WriteLine("Enter UserName: ");
            enteredUsername = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            enteredPassword = Console.ReadLine();

            if (enteredUsername != correctAdminUsername || enteredPassword != correctAdminPassword)
            {
                Console.WriteLine("Incorrect username or password. Please try again.");
            }
            else
            {
                User adminUser = new User(enteredUsername, enteredPassword);

                using (DataContext context = new())
                {
                    try
                    {
                        // Check if the admin user already exists in the database
                        var existingAdmin = context.Users.FirstOrDefault(u => u.UserName == enteredUsername);
                        if (existingAdmin != null)
                        {
                            Console.WriteLine($"Admin username : {existingAdmin.UserName} already exists.");
                            AdminViewPanel _adminViewPanel = new AdminViewPanel();
                            _adminViewPanel.AdminViewPage(adminUser);
                            return $"Admin Name: {existingAdmin.UserName}";
                        }

                        // Add the new admin user to the database
                        context.UserEntities.Add(adminUser);

                        // Set the role for the admin user
                        adminUser.Role = "Admin";

                        context.SaveChanges();
                        Console.WriteLine("Admin added to the database!");

                        // Additional logic for admin registration, if needed

                        AdminViewPanel adminViewPanel = new();
                        adminViewPanel.AdminViewPage(adminUser);
                    }
                    catch (DbException ex)
                    {
                        Console.WriteLine($"Error Message : {ex.Message}");
                        return "Registration failed";
                    }
                }
            }
        } while (enteredUsername != correctAdminUsername || enteredPassword != correctAdminPassword);

        return "Admin registration is successful";
    }
}
