namespace Shipping_Management_Application
{
    public class Order
    {
        private readonly int _orderId;
        private readonly int _userId;
        private readonly DateTime _orderDate = DateTime.Now;

        public Order(int quantity, string shippingAdress, int orderId, int userId)
        {
            Quantity = quantity;
            ShippingAdress = shippingAdress ?? throw new ArgumentNullException(nameof(shippingAdress));
            OrderId = orderId;
            UserId = userId;
        }

        public int Quantity { get; set; }
        public string ShippingAdress { get; set; }
        public string OrderStatus { get; set; } = "Order placed";
        public int OrderId { get; init; }
        public int UserId { get; init; }





        public void PlanDelivery()
        {
            throw new NotImplementedException();
        }
    }
}