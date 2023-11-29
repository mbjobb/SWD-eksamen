using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Shipping_Management_Application.Data.Entities
{
    /// <summary>
    ///customer class with the properties that are used to create a customer object.
    /// </summary>
    public class Customer
    {
        [SetsRequiredMembers]
        public Customer(long id, string? email, string? name, string? adress, string? postCode)
        {
            
            Id = id;
            Email = email;
            Name = name;
            Adress = adress;
            PostCode = postCode;
        }

        
        [Required]
        public long Id   { get; set; }
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Adress { get; set; }
        [Required]
        public string? PostCode { get; set; }

    }


}