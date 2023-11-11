using System.Diagnostics.CodeAnalysis;

namespace Shipping_Management_Application.BuisnessLogic.User
{
    public class User : UserEntity
    {
        [SetsRequiredMembers]
        public User(string userName, string password) : base(userName, password)
        {
        }

        List<Order> _orders = new();
        public string FirstName { get; set; }
    }
}