using Shipping_Management_Application.BuisnessLogic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class Admin : UserEntity
{



    [SetsRequiredMembers]
    public Admin(string userName, string password, string role = "Admin") : base(userName, password, role)
    {
    }
}
