using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Factories.Logistics;
using ITransport = Shipping_Management_Application.Factories.Transport.ITransport;

namespace Shipping_Management_Application.UI{
    
    public class OrderController{

        public static void PlaceOrder(){

            Order order = new(2){
                ShippingAddress = "Urtegata 14"
            };
            ProcessOrder(order);
        }
        
        public static void ProcessOrder(Order order){
            try{
                LogisticsFactory logisticsFactory = new RoadLogistics();
                ITransport transport = logisticsFactory.CreateTransport();

                int cost = logisticsFactory.DeliveryCost(order.ShippingAddress);
                order.Price = cost;
                Console.WriteLine($"Delivery price for Order {order.OrderId}: {order.Price}");

                transport.Deliver();
                order.OrderStatus = "Delivered";
                Console.WriteLine($"Order {order.OrderId} status: {order.OrderStatus}");

                // Add logic for updating the order in the database
            }
            catch (Exception ex){
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}