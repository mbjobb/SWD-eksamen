using Shipping_Management_Application.Data;
using System.Diagnostics.CodeAnalysis;

namespace Shipping_Management_Application.BuisnessLogic.User
{
    public class User : UserEntity
    {
        public Customer customer { get; set; }
        [SetsRequiredMembers]
        public User(string userName, string password) : base(userName, password)
        {
            //customer = new Customer();
        }
       
        public User()
        {
            
            
        }

       

        List<Order> _orders = new();
        public string FirstName { get; set; }
    }
}