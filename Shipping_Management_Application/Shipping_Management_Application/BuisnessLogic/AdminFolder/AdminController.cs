using Shipping_Management_Application.BuisnessLogic.User;

namespace Shipping_Management_Application.BuisnessLogic.AdminFolder;

public class AdminController : UserController{
    public Admin Admin { get; private set; }

    private readonly List<Admin> _admins = new();

    public AdminController(){
    }

    public AdminController(Admin admin, List<Admin> admins){
        Admin = admin;
        _admins = admins;
    }

    // Method to add an admin
    public Admin? AddAdmin(Admin admin){
        _admins.Add(admin);
        Console.WriteLine("Admin has been added");
        return admin;
    }
    
    // Method to create a new admin
    public string CreateAdmin(string adminUserName, string password){
        Admin admin = new(adminUserName, password);
        AddAdmin(admin);
        Console.WriteLine("Admin created");
        return admin.UserName;
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
    public List<Admin>? GetAllAdmins(){
        foreach (Admin admin in _admins){
            Console.WriteLine($"Admin name: {admin.UserName}");
        }
        return null;
    }
    
    // Method to get an admin by username from a list
    public Admin? GetAdminByUserName (string userName){
        foreach (Admin admin in _admins)
        {
            if (admin.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)){
                Console.WriteLine($"Admin name: {admin.UserName}");
            }
        }
        return null;
    }
    
    

    // Method to check if an admin exists
    public bool IsAdmin(List<Admin> admins, string userName)
    {
        return admins.Any(admin => admin.UserName.Equals(userName));
    }
    // Method to Update AdminUserName
    public Admin? UpdateAdminName(string oldUserName, string newUserName){
        Admin? updateAdmin = GetAdminByUserName(oldUserName);
        if (updateAdmin != null){
            if (updateAdmin.UserName.ToUpper() == oldUserName.ToUpper() && newUserName.ToUpper() == newUserName.ToUpper()){
                oldUserName = oldUserName.ToLower();
                newUserName = newUserName.ToLower();
            }

            if (!string.IsNullOrEmpty(newUserName))
            {
                if (IsUserNameAvailable(_admins, newUserName)){
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
    private bool IsUserNameAvailable(List<Admin> admins, string userName){
        return admins.Any(admin => admin.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
    }

    /** Create a method to replace av username/password from big letters to small **/

    public Admin? replaceAdminUserNameAndPassword(string oldUserName, string oldPassword){
        
        var updateAdmin = _admins.FirstOrDefault(admin => admin.UserName.Equals(oldUserName.ToLower()) 
                                                          && admin.Password.Equals(oldPassword.ToLower()));
        
        
        /**
        if (updateAdmin != null){
            if (updateAdmin.UserName.ToUpper() == oldUserName.ToUpper() && newUserName.ToUpper() == newUserName.ToUpper()){
                oldUserName = oldUserName.ToLower();
                newUserName = newUserName.ToLower();
            }

            if (!string.IsNullOrEmpty(newUserName))
            {
                if (IsUserNameAvailable(_admins, newUserName)){
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
        }**/
    }
}
