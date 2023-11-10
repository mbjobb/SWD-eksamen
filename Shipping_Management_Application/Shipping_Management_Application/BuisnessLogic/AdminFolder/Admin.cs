public class Admin{
    private readonly long _adminId;
    private string _userName;
    private string _password;
    
    // Add admin to Database
    // private AdminDb _adminDb = new AdminDb(); // Kommenterte ut, vurder å inkludere hvis nødvendig

    // Default constructor
    public Admin(){
        _userName = "SuperAdmin";
        _password = "SuperAdmin";
    }
    
    // Constructor with parameters
    public Admin(string name, string password){
        _userName = name;
        _password = password;
    }

    // Property for username
    public string UserName { get => _userName; set => _userName = value; }

    // Property for password
    public string Password { get => _password; set => _password = value; }

    // ToString method
    public override string ToString() => $"ID: {_adminId}\nUserName: {_userName}\nPassword: {_password}";
}
