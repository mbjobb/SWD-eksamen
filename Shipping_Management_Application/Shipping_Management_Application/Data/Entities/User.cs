using Shipping_Management_Application.OldStuff;
using System.Diagnostics.CodeAnalysis;

namespace Shipping_Management_Application.Data.Entities
{
    public class User : UserEntity
    {
        /// <summary>
        /// Dependancy injection continued. 3/x
        /// The customer object is the second derived type of UserEntity, and 
        /// it has a property not included in the base type, namely the 
        /// "Customer" member.
        /// </summary>

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