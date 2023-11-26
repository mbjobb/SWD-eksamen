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
            Customer customer = CrudOperations.GetCustomerById(user.Id);
            return customer;
        }
        public Order CreateOrder(UserEntity user, string shippingAddress)
        {
            Order order = new(user.Id, shippingAddress);
            CrudOperations.SaveOrder(order);
            return order;
        }
        public Order UpdateOrderStatus(Order order, string status)
        {
            Order updatedOrder = CrudOperations.UpdateOrderStatus(order, status);
            return updatedOrder;
        }
        public IEnumerable<Order> GetAllCustomerOrders(UserEntity user)
        {
            IEnumerable<Order> orders = CrudOperations.GetOrdersByUserId(user.Id);
            return orders;
        }
    }
}
