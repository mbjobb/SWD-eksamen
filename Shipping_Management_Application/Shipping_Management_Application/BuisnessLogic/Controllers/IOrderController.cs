using Shipping_Management_Application.Data.Entities;

namespace Shipping_Management_Application.BuisnessLogic.Controllers
{
    /// <summary>
    /// Interface for the OrderController class with the methods that are used in the UI.
    /// </summary>
    public interface IOrderController
    {
        Order CreateOrder(UserEntity user, string shippingAddress);
        IEnumerable<Order> GetAllCustomerOrders(UserEntity user);
        Customer GetCustomer(UserEntity user);
        Order UpdateOrderStatus(Order order, string status);
    }
}