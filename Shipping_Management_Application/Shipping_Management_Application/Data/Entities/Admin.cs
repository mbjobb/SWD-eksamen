using Shipping_Management_Application.Data.Entities;
using System.Diagnostics.CodeAnalysis;

public class Admin : UserEntity
{
    /// <summary>
    /// Dependancy injection continued. 2/x
    /// The Admin object is a derived type of the UserEntity, but does not
    /// contain any meaningfull differences to its base type.
    /// It is still required since the UserEntity type is abstract and thus
    /// cannot be instansiated.
    /// </summary>



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
