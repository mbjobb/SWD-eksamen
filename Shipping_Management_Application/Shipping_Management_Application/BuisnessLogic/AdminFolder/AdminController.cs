using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shipping_Management_Application.BuisnessLogic.UserFolder;
using Shipping_Management_Application.Data;
using System;
using System.Diagnostics.Metrics;

namespace Shipping_Management_Application.BuisnessLogic.AdminFolder;

public class AdminController : UserController
{
    // TODO: redo all of this

    public Admin? Admin { get; private set; }
    private List<Admin>? admins { get; set; }


    // Create Admin and add => sending to Database
    public void CreateAdmin(string userName, string password)
    {
        //Database Connection
        using (DataContext2 dataContext = new())
        {
            try
            {
                // if password / username not null -> adding admin to database
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                {
                    var newAdmin = new Admin(userName, password);
                    dataContext.Add(newAdmin);
                    dataContext.SaveChanges();
                    Console.WriteLine("Admin Added to Database!");
                }
                else
                {

                    for (int count = 3; count > 0; count--)
                    {
                        Console.WriteLine("You must enter a 'userName' and 'password'");
                        Console.WriteLine($"You have {count} Attempts");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    // Method to get all admins
    public List<Admin> GetAllAdmins()
    {
        //Database Connection
        using (DataContext2 dataContext = new())
        {

            // try to find out all admins in usertabel where rolle = "Admin"
            try
            {
               //admins = dataContext.UserEntities
               //         .Where(u => u.Role == "Admin")
               //         .Select(u => new Admin(u.UserName, u.Password, "Admin"))
               //          .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        return admins;

    }
    //Method to remove an Admin by Id
    public void RemoveAdminById(int id)
    {
        using (DataContext2 dataContext = new DataContext2())
        {
            try
            {
                var admin = dataContext.Admins.FirstOrDefault(a => a.Id == id);
                if (admin != null)
                {
                    dataContext.Admins.Remove(admin);
                    dataContext.SaveChanges();
                    Console.WriteLine("Admin removed! ");
                }
                else
                {
                    //If the admin ID is not found, give the admin 3 attempts to enter a valid admin ID
                    for (int count = 3; count > 0; count--)
                    {
                        Console.WriteLine("Admin not found! Try again.");
                        Console.WriteLine($"You have {count} Attempts");
                        return;
                    }
                    Console.WriteLine("You can look for the admin you want to remove!");
                    GetAllAdmins();
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    // Update username and password an admin 
    public void UpdateAdminInfo(int id, string newUserName, string newPassword)
    {
        using (DataContext2 dataContext = new DataContext2())
        {
            try
            {
                // try to found admin by id and set username to newusername an password to newpassword
                var admin = dataContext.Admins.FirstOrDefault(a => a.Id == id);
                if (admin != null)
                {
                    admin.UserName = newUserName;
                    admin.Password = newPassword;
                    dataContext.SaveChanges();
                    Console.WriteLine("Admin information updated!");
                }
                else
                {
                    Console.WriteLine("Admin not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

//// Method to get an admin by username from a list
//public Admin? GetAdmin(List<Admin> admins, string userName)
//{
//    foreach (Admin admin in admins)
//    {
//        if (admin.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase))
//        {
//            return admin;
//        }
//    }
//    return null;
//}
//// Helper method to check if a username is available
//private bool IsUserNameAvailable(List<Admin> admins, string userName)
//{
//    return admins.Any(admin => admin.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
//}
//// Method to check if an admin exists
//public bool IsAdmin(List<Admin> admins, string userName)
//{
//    return admins.Any(admin => admin.UserName.Equals(userName));
//}
//    // Method to Update AdminUserName
//    public Admin? UpdateAdminName(List<Admin> admins, string userName, string newUserName)
//    {
//        Admin? updateAdmin = GetAdmin(admins, userName);
//        if (updateAdmin != null)
//        {
//            if (updateAdmin.UserName.ToUpper() == userName.ToUpper() && newUserName.ToUpper() == newUserName.ToUpper())
//            {
//                userName = userName.ToLower();
//                newUserName = newUserName.ToLower();
//            }

//            if (!string.IsNullOrEmpty(newUserName))
//            {
//                if (IsUserNameAvailable(admins, newUserName))

//                {
//                    return null;
//                }
//                else
//                {
//                    updateAdmin.UserName = newUserName;
//                    return updateAdmin;
//                }
//            }
//            else
//            {
//                return null;
//            }
//        }
//        else
//        {
//            return null;
//        }
//    }  
//}
