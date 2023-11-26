using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Interfaces;
using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data.Entities;
using Shipping_Management_Application.Factories.Logistics;
using ITransport = Shipping_Management_Application.Factories.Transport.ITransport;

namespace Shipping_Management_Application.UI
{

    public class OrderControllerUI{

        /// <summary>
        /// Dependancy injection continued. 6/6
        /// Here we are using the constructor dependancy injection pattern,
        /// and by instantiating an Order controller from its interface, rather
        /// than its concrete implementation. 
        /// </summary>

        public static IOrderController orderController = new OrderController();
        //TODO: make constructor instance an interface
        public static void PlaceOrder(UserEntity user){
            
            Customer customer = orderController.GetCustomer(user);

            if (customer == null){
                Console.WriteLine("You need to register as a customer to proceed");
                UserControllerUI.RegisterCustomer(InitializeApp.userController,user);
            }
            //TODO: decide on how we are handling exceptions so it's consistant throughout the code base
            try
            {
                Console.Write("Please enter shipping address:");
                string shippingAddress = Console.ReadLine();
                Order order = orderController.CreateOrder(user, shippingAddress);
                
                ProcessOrder(order);

            }
            catch (ArgumentException e)
            {
                Console.WriteLine("You must enter a shipping adress, please try again");
                InitializeLoggedIn.OnLoggedIn(user);

            }
        }
        
        public static void ProcessOrder(Order order){
            try{

                LogisticsFactory logisticsFactory = new RoadLogistics();
                ITransport transport = logisticsFactory.CreateTransport();
                int price = logisticsFactory.DeliveryCost(order.ShippingAddress);
                
                order.Price = price;
                Console.WriteLine($"Delivery price for Order {order.OrderId}: {order.Price}");

                transport.Deliver();

                //Logic for updating status in db, function takes Order order and string status as arguments
                orderController.UpdateOrderStatus(order, "Delivered");
                Console.WriteLine($"Order {order.OrderId} status: {order.OrderStatus}");
            }
            catch (Exception ex){
                Console.WriteLine("Error: " + ex.ToString());
            }
        }

        public static void PrintCurrentUsersOrders(UserEntity user){
            
            IEnumerable<Order> Orders = orderController.GetAllCustomerOrders(user);
            foreach (Order Order in Orders)
            {
                Console.WriteLine(Order);
            }


        }
    }
}
// Addresses