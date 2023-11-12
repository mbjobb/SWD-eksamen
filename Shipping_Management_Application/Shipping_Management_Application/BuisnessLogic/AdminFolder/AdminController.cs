using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;

namespace Shipping_Management_Application.BuisnessLogic.AdminFolder;

public class AdminController : UserController
{
    // TODO: redo all of this

    public Admin Admin { get; private set; }
    private List<UserEntity> admins { get;  set; }

    // Create Admin and add => sending to Database
    public void CreateAdmin(string userName, string password)
    {
        //Dtabase Connection
        using (DataContext dataContext = new())
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
                    Console.WriteLine("You must enter a 'userName' and 'password'");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    // Method to get all admins
    public List<UserEntity> GetAllAdmins()
    {
        //Dtabase Connection
        using (DataContext dataContext = new())
        {

            //admins => UserEntity.Equals("Admin", StringComparison.OrdinalIgnoreCase);
            try
            {
                IQueryable<Admin> admins1 = dataContext.UserEntities
                                    .Where(u => u.Role == "Admin")
                                    .Select(u => new Admin(u.UserName, u.Password, "Admin"));
                admins = admins1
                    .ToList();
            }


            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        return admins;

    } 
    // Method to get an admin by username from a list
    public Admin? GetAdmin(List<Admin> admins, string userName)
    {
        foreach (Admin admin in admins)
        {
            if (admin.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase))
            {
                return admin;
            }
        }
        return null;
    }




    // Method to remove an admin
    public Admin RemoveAdmin(List<Admin> admins, string userName)
    {
        Admin adminToRemove = admins.FirstOrDefault(a => a.UserName.Equals(userName));
        if (adminToRemove != null)
        {
            admins.Remove(adminToRemove);
        }
        return adminToRemove;
    }

  
   


    // Method to check if an admin exists
    public bool IsAdmin(List<Admin> admins, string userName)
    {
        return admins.Any(admin => admin.UserName.Equals(userName));
    }
    // Method to Update AdminUserName
    public Admin? UpdateAdminName(List<Admin> admins, string userName, string newUserName)
    {
        Admin? updateAdmin = GetAdmin(admins, userName);
        if (updateAdmin != null)
        {
            if (updateAdmin.UserName.ToUpper() == userName.ToUpper() && newUserName.ToUpper() == newUserName.ToUpper())
            {
                userName = userName.ToLower();
                newUserName = newUserName.ToLower();
            }

            if (!string.IsNullOrEmpty(newUserName))
            {
                if (IsUserNameAvailable(admins, newUserName))

                {
                    return null;
                }
                else
                {
                    updateAdmin.UserName = newUserName;
                    return updateAdmin;
                }
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
    //Method for superAdmin to Genareate Admin, Connection To DB




    // Helper method to check if a username is available
    private bool IsUserNameAvailable(List<Admin> admins, string userName)
    {
        return admins.Any(admin => admin.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
    }
}
