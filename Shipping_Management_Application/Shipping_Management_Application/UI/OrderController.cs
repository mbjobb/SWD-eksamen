using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Factories.Logistics;
using ITransport = Shipping_Management_Application.Factories.Transport.ITransport;

namespace Shipping_Management_Application.UI{
    
    public class OrderController{

        public static void PlaceOrder(UserEntity user)
        {
            using DataContext context = new();
            Order order = new(user.Id, "derp 12"){
                ShippingAddress = "Urtegata 14"
            };
            context.Orders.Add(order);
            context.SaveChanges();
            ProcessOrder(order);
        }
        
        public static void ProcessOrder(Order order){
            try{
                using DataContext context = new();
                LogisticsFactory logisticsFactory = new RoadLogistics();
                ITransport transport = logisticsFactory.CreateTransport();

                int cost = logisticsFactory.DeliveryCost(order.ShippingAddress);
                order.Price = cost;
                Console.WriteLine($"Delivery price for Order {order.OrderId}: {order.Price}");

                transport.Deliver();
                order.OrderStatus = "Delivered";
                Console.WriteLine($"Order {order.OrderId} status: {order.OrderStatus}");
                context.Orders.Add(order);
                context.SaveChanges();

                // Add logic for updating the order in the database
            }
            catch (Exception ex){
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}