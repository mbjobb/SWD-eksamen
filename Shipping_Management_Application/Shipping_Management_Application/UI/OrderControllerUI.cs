
using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
using Shipping_Management_Application.Factories.Logistics;
using System.Runtime.CompilerServices;
using ITransport = Shipping_Management_Application.Factories.Transport.ITransport;

namespace Shipping_Management_Application.UI
{

    public class OrderControllerUI
    {

        /// <summary>
        /// Dependancy injection continued. 6/6
        /// Here we are using the constructor dependancy injection pattern,
        /// and by instantiating an Order controller from its interface, rather
        /// than its concrete implementation. 
        /// </summary>

        public static IOrderController orderController = new OrderController();

        public static void PlaceOrder(UserEntity user)
        {
            
            Customer customer = orderController.GetCustomer(user);

            if (customer == null)
            {
                Console.WriteLine("You need to register as a customer to proceed");
                customer = UserControllerUI.RegisterCustomer(InitializeApp.userController, user);

            }

            try
            {
                Console.Write("Please enter shipping address:");
                string shippingAddress = Console.ReadLine();
                ProcessOrder(shippingAddress, customer, user);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You must enter a shipping address, please try again");
                InitializeLoggedIn.OnLoggedIn(user);
            }
        }

        public static void ProcessOrder(string shippingAddress, Customer customer, UserEntity user)
        {
            Console.WriteLine("Choose your delivery method"); 
            List<string> options = new()
            {
                "Truck",
                "Van",
                "Bike"
            };
            UIController.MenuFacade(options);

            char deliveryMethodChoice = UIController.ReadASingleKeyPress("123");

            try{
                LogisticsFactory logisticsFactory = ChooseLogisticsFactory(deliveryMethodChoice);
                int deliveryPrice = logisticsFactory.DeliveryCost(shippingAddress);

                Order order = orderController.CreateOrder(customer,shippingAddress, deliveryPrice );
                
                ITransport transport = logisticsFactory.CreateTransport(order);

                UIController.ClearConsole();
                order.Price = deliveryPrice;
                Console.WriteLine($"Delivery price for Order {order.Id}: {order.Price}");
                transport.Deliver(order);

                //Logic for updating status in db, function takes Order order and string status as arguments
                Console.WriteLine($"Order {order.Id} status: {order.OrderStatus}");
            }
            catch (Exception ex){
                Console.WriteLine("Error: " + ex.ToString());
            }
        }

        private static LogisticsFactory ChooseLogisticsFactory(char deliveryMethodChoice)
        {
            switch (deliveryMethodChoice){
                case '1':
                    {
                    return new RoadLogistics();
                    }
                    
                case '2':
                {
                    throw new NotImplementedException("Van delivery is not implemented yet, maybe for future development");
                }
                    
                case '3':
                {
                    throw new NotImplementedException("Bike delivery is not implemented yet, maybe for future development");
                }
                    
                default:
                {
                    throw new ArgumentException("Error, invalid choice");
                }
                    
            }
        }

        public static void PrintCurrentUsersOrders(UserEntity user)
        {

            IEnumerable<Order> Orders = orderController.GetAllCustomerOrders(user);
            foreach (Order Order in Orders)
            {
                Console.WriteLine(Order);
            }


        }

        public static void PrintAllOrders()
        {
            IEnumerable<Order> Orders = CrudOperations.GetAllOrders();
            foreach (Order Order in Orders)
            {
                Console.WriteLine(Order);
            }

        }
    }
}