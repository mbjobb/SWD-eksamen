using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.BuisnessLogic.Controllers
{
    public class OrderController : OrderControllerBase
    {
        /// <summary>
        /// The implimentation here has been made easily replaceable since we are only doing a partial simulation of the shipping and ordering process.
        /// </summary>
        //TODO: extract interface
        
        //TODO: move to UserController?
        public override Customer GetCustomer(UserEntity user)
        {
            Customer customer = CrudOperations.GetCustomerById(user.Id);
            return customer;
        }
        public override Order CreateOrder(UserEntity user, string shippingAddress)
        {
            Order order = new(user.Id, shippingAddress);
            CrudOperations.SaveOrder(order);
            return order;
        }
        public override Order UpdateOrderStatus(Order order, string status)
        {
            Order updatedOrder = CrudOperations.UpdateOrderStatus(order, status);
            return updatedOrder;
        }
        public override IEnumerable<Order> GetAllCustomerOrders(UserEntity user) 
        {
            IEnumerable<Order> orders = CrudOperations.GetOrdersByUserId(user.Id);
            return orders;
        }
    }
}
