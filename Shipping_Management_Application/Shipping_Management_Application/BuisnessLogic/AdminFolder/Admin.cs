using Shipping_Management_Application.BuisnessLogic.User;

public class Admin : IUserEntity
{
    // Interface Fields
    public long Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }


    // Add admin to Database
    // private AdminDb _adminDb = new AdminDb(); // Kommenterte ut, vurder å inkludere hvis nødvendig

    // Default constructor


    // Constructor with parameters
    public Admin(string name, string password)
    {
        UserName = name;
        Password = password;
    }

    // Property for username
    // Property for password








    // ToString method
    public override string ToString() => $"ID: {Id}\nUserName: {UserName}\nPassword: {Password}";

}
