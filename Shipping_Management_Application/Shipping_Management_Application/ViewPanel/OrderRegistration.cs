//using Shipping_Management_Application.BuisnessLogic;
//using Shipping_Management_Application.BuisnessLogic.User;
//using Shipping_Management_Application.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Shipping_Management_Application.ViewPanel
//{
//    public class OrderController
//    {
//        private User _user;
//        private Order _order;
//        List<Order> _orders = new List<Order>();

//        // Method to create an order from Customer and Admin
//        public void CreateOrder()
//        {
//            Console.WriteLine("Register your Order!");
//            _order = new Order();

//            using (DataContext db = new())
//            {
//                // Assuming you have a DbSet<Order> in your DataContext
//                db.Orders.Add(_order);
//                db.SaveChanges();
//            }
//        }

//        // Method to Update order and send back to database
//        public void UpdateOrder(int orderId)
//        {
//            using (DataContext db = new())
//            {
//                // Retrieve the order from the database
//                Order? existingOrder = db.Orders.FirstOrDefault(predicate: o => o.OrderId == orderId);

//                if (existingOrder != null)
//                {
//                    //// Update the order properties as needed
//                    //existingOrder.Property1 = "New Value1";
//                    //existingOrder.Property2 = "New Value2";

//                    // Save changes to the database
//                    db.SaveChanges();
//                }
//                else
//                {
//                    Console.WriteLine("Order not found.");
//                }
//            }
//        }

//        // Method to delete Order
//        public void DeleteOrder(int orderId)
//        {
//            using (DataContext db = new())
//            {
//                // Retrieve the order from the database
//                Order? existingOrder = db.Orders.FirstOrDefault(o => o.OrderId == orderId);

//                if (existingOrder != null)
//                {
//                    // Remove the order from the DbSet and save changes
//                    db.Orders.Remove(existingOrder);
//                    db.SaveChanges();
//                }
//                else
//                {
//                    Console.WriteLine("Order not found.");
//                }
//            }
//        }

//        // Method to ReadOrder from Database 
//        public List<Order> GetOrders()
//        {
//            using (DataContext db = new())
//            {
//                // Retrieve all orders from the database
//                _orders = db.Orders.ToList();
//            }

//            return _orders;
//        }
//    }
//}
