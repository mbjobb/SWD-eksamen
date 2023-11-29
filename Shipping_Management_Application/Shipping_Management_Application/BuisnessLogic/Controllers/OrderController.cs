using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.BuisnessLogic.Controllers
{
    public class OrderController : IOrderController
    {
        /// <summary>
        /// The implimentation here has been made easily replaceable since we are only doing a partial simulation of the shipping and ordering process.
        /// </summary>
        //TODO: extract interface

        //TODO: move to UserController?
        public Customer GetCustomer(UserEntity user)
        {
            return CrudOperations.GetCustomerById(user.Id);
            
        }
        public Order CreateOrder(Customer customer, string shippingAdress, int price )
        {
            Order order = new(customer.Id, shippingAdress, price);
            CrudOperations.SaveOrder(order);
            return order;
        }
        public Order UpdateOrderStatus(Order order, string status)
        {
            return CrudOperations.UpdateOrderStatus(order, status);
        }
        public IEnumerable<Order> GetAllCustomerOrders(UserEntity user)
        {
            return CrudOperations.GetOrdersByUserId(user.Id);
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return CrudOperations.GetAllOrders();
        }
    }
}
