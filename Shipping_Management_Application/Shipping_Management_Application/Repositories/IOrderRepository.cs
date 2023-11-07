using Shipping_Management_Application.Models;

namespace Shipping_Management_Application.Repositories{
    public interface IOrderRepository{
        void AddOrder(Order order);
        List<Order> GetOrderByUserId(User user);
    }
}