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
        Console.WriteLine("Welcome to the Customer sign-in page! Please follow the instructions.");
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

                    if (existingUser != null && existingUser.UserName == _Password && existingUser.Password == _Password)
                    {
                        Console.WriteLine("Customer logged in successfully!");
                        CustomerViewPanel customerViewPanel = new();
                        customerViewPanel.CustomerMainView(existingUser);
                        return "Customer logged in successfully!";
                    }
                    else if (existingUser != null)
                    {
                        Console.WriteLine("Incorrect password or username. Please try again.");
                      
                    }
                    else
                    {
                        Console.WriteLine("Please try to sign up!");
                        SignUpCustomer(_Username, _Password);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return "Sign-in failed";
                }
            }
        } while (true);
        return "";
    }

    // Method for Customer registration
    public string SignUpCustomer(string username, string password)
    {
        Console.WriteLine("Welcome to the Customer registration page! Please follow the instructions.");
        do
        {
            Console.WriteLine("Enter UserName: ");
            _Username = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            _Password = Console.ReadLine();

            _Username = username;
            _Password = password;

            using (DataContext context = new())
            {
                try
                {
                    // Check if the user already exists in the database
                    var existingUser = context.Users.FirstOrDefault(u => u.UserName == _Username);

                    if (existingUser != null)
                    {
                        Console.WriteLine("Username already exists. Please choose a different one.");
                    }
                    else
                    {
                        // User does not exist, proceed with registration                

                        CustomerRegistration customerRegistration = new();
                        customerRegistration.RegisterCustomer();
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


    // Method for Admin 
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
                using (DataContext context = new())
                {
                    try
                    {
                        var existingAdminUsername = context.Users.FirstOrDefault(u => u.UserName == enteredUsername);
                        if (existingAdminUsername != null)
                        {
                            Console.WriteLine($"Admin username : {existingAdminUsername.UserName} already exists.");
                            AdminViewPanel _adminViewPanel = new AdminViewPanel();
                            _adminViewPanel.AdminViewPage(existingAdminUsername);
                            return $"Admin Name: {existingAdminUsername.UserName}";
                        }
                    }
                    catch (DbException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

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
    public string CreateAdminFromAdmin()
    {
        Console.WriteLine("Admin registration! ");

        string newAdminUsername;
        string newAdminPassword;

        do
        {
            Console.WriteLine("Enter UserName: ");
            newAdminUsername = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            newAdminPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newAdminUsername) || string.IsNullOrWhiteSpace(newAdminPassword))
            {
                Console.WriteLine("Username and password cannot be empty. Please try again.");
            }
        } while (string.IsNullOrWhiteSpace(newAdminUsername) || string.IsNullOrWhiteSpace(newAdminPassword));

        User adminUser = new User(newAdminUsername, newAdminPassword);

        using (DataContext context = new DataContext())
        {
            try
            {
                // Check if the newAdminUsername already exists in the database
                var existingAdmin = context.Users.FirstOrDefault(u => u.UserName == newAdminUsername);

                if (existingAdmin != null)
                {
                    Console.WriteLine($"Admin username: {existingAdmin.UserName} already exists.");
                    AdminViewPanel _adminViewPanel = new AdminViewPanel();
                    _adminViewPanel.AdminViewPage(existingAdmin); // Pass the existing admin instead of the newly created one
                    return $"Admin Name: {existingAdmin.UserName}";
                }

                // Add the new admin user to the database
                context.UserEntities.Add(adminUser);

                // Set the role for the admin user
                adminUser.Role = "Admin";

                context.SaveChanges();
                Console.WriteLine("Admin added to the database!");

                AdminViewPanel adminViewPanel = new AdminViewPanel();
                adminViewPanel.AdminViewPage(adminUser);
            }
            catch (DbException ex)
            {
                Console.WriteLine($"Error Message: {ex.Message}");
                return "Registration failed";
            }
        }

        return "Admin registration is successful";
    }

}

