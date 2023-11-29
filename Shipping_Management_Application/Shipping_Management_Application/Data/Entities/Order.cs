namespace Shipping_Management_Application.Data.Entities
{
    /// <summary>
    /// Order class with the properties that are used to create an order object. 
    /// with a 3 overrided methods to make it easier to print the order.
    /// </summary>
    public class Order
    {
        public Order(long customerId, string shippingAddress, int price)
        {
            CustomerId = customerId;
            ShippingAddress = shippingAddress;
            Price = price;
        }

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string ShippingAddress { get; set; }
        public string OrderStatus { get; set; } = "Order placed";
        public int Price { get; set; }
        

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
            return string.Format($"Order number:{Id}  Shipping address:{ShippingAddress}  Order status:{OrderStatus}  Price:{Price}");
        }
    }
}
