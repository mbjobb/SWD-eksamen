using Shipping_Management_Application.OldStuff;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Shipping_Management_Application.Data.Entities
{
    public class Customer
    {

        public Customer(long customerId, string? name)
        {
            CustomerId = customerId;
            Name = name;
        }
        [SetsRequiredMembers]
        public Customer(long customerId, string? name, string? email, string? address, string? postCode) : this(customerId, email)
        {
            Name = name;
            Email = email;
            Adress = address;
            PostCode = postCode;
        }

        public long CustomerId { get; set; }
        public User? User { get; set; }
        public ICollection<Order> Orders { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public string? PostCode { get; set; }

    }


}