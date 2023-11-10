using Shipping_Management_Application.BuisnessLogic.User;

namespace Shipping_Management_Application.BuisnessLogic.AdminFolder;

public class AdminController : UserController
{
    public Admin Admin { get; private set; }

    public List<Admin> _admins = new();

    public AdminController()
    {
    }

    public AdminController(Admin admin, List<Admin> admins)
    {
        this.Admin = admin;
        _admins = admins;
    }

    // Method to add an admin
    public void AddAdmin(Admin admin)
    {
        _admins.Add(admin);

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

    // Method to get all admins
    public List<Admin> GetAllAdmins()
    {
        return _admins;
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



    // Method to create a new admin
    public string CreateAdmin(string userName, string password)
    {
        Admin admin = new(userName, password);
        AddAdmin(admin);
        Console.WriteLine("Admin created");
        return admin.UserName;
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
