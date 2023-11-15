using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shipping_Management_Application.Data
{
    public class Customer
    {
        public Customer(long customerId, string? firstName)
        {
            CustomerId = customerId;
            FirstName = firstName;
        }


        // We use DataAnnotations to manage and validate input data
        [Key]
        public long CustomerId { get; set; }
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }
        
        
        
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? Adress { get; set; } = "streetname int";
        public int Postcode { get; set; }
        public string? Email { get; set; } = $"+@example.com";

        

    }


}