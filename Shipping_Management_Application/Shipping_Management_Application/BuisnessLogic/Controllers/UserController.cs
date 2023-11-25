using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
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

        internal UserEntity CreateUser(string username, string password)
        {
            UserEntity user = new User(username, password);
            CrudOperations.CreateUser(user);
            return user;
        }
        internal UserEntity FindUserByUsernameAndPassword(string username, string password)
        {
            UserEntity user = CrudOperations.GetUserByUserNameAndPassword(username, password);
            return user;
        }
    }
}
