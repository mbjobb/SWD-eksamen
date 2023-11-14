using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.Data;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;

namespace Shipping_Management_Application.BuisnessLogic.UserFolder
{
    public class User : UserEntity
    {

        
        //public Customer Customer { get; set; }
        [SetsRequiredMembers]
        public User(string userName, string password, string firstname) : base(userName, password)
        {
            FirstName = firstname;
        }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(100)]
        public string? FirstName { get; set; }
        

        public User()
        {


        }

        public User(string? firstName)
        {
            FirstName = firstName;
        }
        
        public ICollection<Order>? Orders { get; set; } = new List<Order>();

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(utb => { utb.ToTable("Customers"); });

        }
    }
}