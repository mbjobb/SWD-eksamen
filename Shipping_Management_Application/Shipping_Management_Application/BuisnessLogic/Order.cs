using Shipping_Management_Application.Data;

namespace Shipping_Management_Application.BuisnessLogic
{
    public class Order
    {
        public long OrderId { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string ShippingAddress { get; set; }
        public string OrderStatus { get; set; } = "Order placed";
        public int Price { get; set; }
        public Order(long customerId){
            CustomerId = customerId;
        }
    }
}
