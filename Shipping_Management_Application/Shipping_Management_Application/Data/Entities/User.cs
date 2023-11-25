using Shipping_Management_Application.OldStuff;
using System.Diagnostics.CodeAnalysis;

namespace Shipping_Management_Application.Data.Entities
{
    public class User : UserEntity
    {
        public Customer Customer { get; set; }

        [SetsRequiredMembers]
        public User(string userName, string password) : base(userName, password)
        {

        }

        public User()
        {


        }

        public override string? ToString()
        {
            return $"{Id} {UserName} {Role}";
        }
    }
}