using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Shipping_Management_Application.Data.Entities
{
    public abstract class UserEntity
    {

        /// <summary>
        /// Dependancy injection start. 1/6 
        /// Here we have UserEntity as the base/parent/super- class for all
        /// current and future "user" objects.(ps, maybe we should change the
        /// name of the User class)
        /// 
        /// We use this to define the minimum necessities of a user object that
        /// all derived members need to have.
        /// In this case we have an id, used as primary key in the database, as
        /// well as a foreign key for the customer object; username and 
        /// password which is needed for logging in; and lastly a role which
        /// can be used to manage permissions.
        /// <see cref="Admin"/>
        /// </summary>

        public long Id { get; set; }
        [Required]
        public required string UserName { get; init; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required string Role { get; set; } = "Customer";//sets default value to "Customer"

        //default constuctor
        [SetsRequiredMembers]
        protected UserEntity(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        protected UserEntity()
        {

        }

        //constructor with role, used for creating admins
        [SetsRequiredMembers]
        protected UserEntity(string userName, string password, string role) : this(userName, password)
        {
            Role = role;
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
            return $"{Id} {UserName} {Role}";
        }
    }
}
