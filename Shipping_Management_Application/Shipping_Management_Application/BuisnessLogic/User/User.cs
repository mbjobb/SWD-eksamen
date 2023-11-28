using Shipping_Management_Application.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Shipping_Management_Application.BuisnessLogic.User
{
    public class User : UserEntity
    {
        [InverseProperty("User")]
        public Customer Customer { get; set; }


        public List<Order> Orders { get; set; } = new List<Order>();
        [SetsRequiredMembers]
        public User(string? userName, string? password, string role = "Customer") : base(userName, password, role)
        {

        }

        public User()
        {

        }
    }
}
