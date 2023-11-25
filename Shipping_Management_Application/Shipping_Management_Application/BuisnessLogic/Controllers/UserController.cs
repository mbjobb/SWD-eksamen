using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.BuisnessLogic.Controllers
{
    internal class UserController
    {
        internal Customer CreateCustomer(long id, string? name, string? email, string? address, string? postCode)
        {
            Customer customer = new Customer(id, name, email, address, postCode);
            CrudOperations.CreateCustomer(customer);
            return customer;
            
        }
    }
}
