public class Admin
{
    // Interface Fields
    // public long Id { get; set; }
    //public string Name { get; set; }
    //public string Password { get; set; }

    private readonly long _adminId;
    private string _userName;
    private string _password;


    // Add admin to Database
    // private AdminDb _adminDb = new AdminDb(); // Kommenterte ut, vurder å inkludere hvis nødvendig

    // Default constructor
    public Admin()
    {
        _userName = "admin";
        _password = "admin";
    }

    // Constructor with parameters
    public Admin(string name, string password)
    {
        _userName = name;
        _password = password;
    }

    // Property for username
    // Property for password


    public long AdminId => _adminId;

    public string UserName { get => _userName; set => _userName = value; }
    public string Password { get => _password; set => _password = value; }


    // ToString method
    public override string ToString() => $"ID: {_adminId}\nUserName: {_userName}\nPassword: {_password}";

}
