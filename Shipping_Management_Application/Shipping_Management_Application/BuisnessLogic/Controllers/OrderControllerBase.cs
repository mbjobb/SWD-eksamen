using Shipping_Management_Application.Data;

namespace Shipping_Management_Application.BuisnessLogic.Controllers
{
    public abstract class OrderControllerBase
    {
        public abstract  Order CreateOrder(UserEntity user, string shippingAddress);
        public abstract  IEnumerable<Order> GetAllCustomerOrders(UserEntity user);
        public abstract  Customer GetCustomer(UserEntity user);
        public abstract Order UpdateOrderStatus(Order order, string status);
    }
}