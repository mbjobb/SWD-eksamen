namespace Shipping_Management_Application.Data.Entities
{
    /// <summary>
    /// Order class with the properties that are used to create an order object. 
    /// with a 3 overrided methods to make it easier to print the order.
    /// </summary>
    public class Order
    {
        public long OrderId { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string ShippingAddress { get; set; }
        public string OrderStatus { get; set; } = "Order placed";
        public int Price { get; set; }
        public Order(long customerId)
        {
            CustomerId = customerId;
        }

        public Order(long customerId, string shippingAddress) : this(customerId)
        {
            ShippingAddress = shippingAddress;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
      
        public override string? ToString()
        {
            return string.Format($"Order number:{OrderId}  Shipping address:{ShippingAddress}  Order status:{OrderStatus}  Price:{Price}");
        }
    }
}
