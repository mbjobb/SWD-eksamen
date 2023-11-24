using Shipping_Management_Application.Data;

namespace Shipping_Management_Application.BuisnessLogic.Controllers
{
    public interface IOrderController
    {
        Order CreateOrder(UserEntity user, string shippingAddress);
        IEnumerable<Order> GetAllCustomerOrders(UserEntity user);
        Customer GetCustomer(UserEntity user);
        Order UpdateOrderStatus(Order order, string status);
    }
}