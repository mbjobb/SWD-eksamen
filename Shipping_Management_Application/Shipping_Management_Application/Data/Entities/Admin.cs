using Shipping_Management_Application.Data.Entities;
using System.Diagnostics.CodeAnalysis;

public class Admin : UserEntity
{



    [SetsRequiredMembers]
    public Admin(string userName, string password, string role = "Admin") : base(userName, password, role)
    {
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return $"{Id} {UserName}";
    }
}
