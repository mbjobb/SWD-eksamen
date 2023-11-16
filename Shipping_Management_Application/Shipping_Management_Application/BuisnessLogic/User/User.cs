using Shipping_Management_Application.Data;
using Shipping_Management_Application.OldStuff;
using System.Diagnostics.CodeAnalysis;

namespace Shipping_Management_Application.BuisnessLogic.User
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

       

        

    }
}