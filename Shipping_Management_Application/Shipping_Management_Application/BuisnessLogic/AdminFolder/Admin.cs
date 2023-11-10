using Shipping_Management_Application.BuisnessLogic.AdminFolder;

public class Admin{
    
    private readonly long _adminId;
    private string _userName;
    private string _password;
    public AdminController? AdminController;
    
    // Add admin to Database
    // private AdminDb _adminDb = new AdminDb(); // Kommenterte ut, vurder å inkludere hvis nødvendig

    // Default constructor
    public Admin(){
        _userName = "superadmin";
        _password = "superadmin";
    }
    
    // Constructor with parameters
    public Admin(string userName, string password) {
        _userName = userName;
        _password = password;
        AdminController?.CreateAdmin(_userName, _password);
    }

    // Property for username
    public string UserName { get => _userName; set => _userName = value; }

    // Property for password
    public string Password { get => _password; set => _password = value; }

    // ToString method
    public override string ToString() => $"ID: {_adminId}\nUserName: {_userName}\nPassword: {_password}";
}
