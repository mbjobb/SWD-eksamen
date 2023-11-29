using System.Diagnostics.CodeAnalysis;

namespace Shipping_Management_Application.Data.Entities
{
    public class User : UserEntity
    {
        /// <summary>
        /// Dependancy injection continued. 3/6
        /// The customer object is the second derived type of UserEntity, and 
        /// it has a property not included in the base type, namely the 
        /// "Customer" member.
        /// <see cref="UI.UserControllerUI"/>
        /// </summary>

        public Customer Customer { get; set; }

        [SetsRequiredMembers]
        public User(string userName, string password) : base(userName, password)
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
            return base.ToString();
        }
    }
}