using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Shipping_Management_Application.ViewPanel
{
    public class OrdersHistoryViewPanel
    {
        // Connection for db
        private readonly DataContext _dbContext;

        public OrdersHistoryViewPanel(DataContext context)
        {
            _dbContext = context;
        }

        public List<Order> ShowOrderHistory(User user)
        {
            try
            {
                // navigation from User to Orders
                List<Order> orderHistory = _dbContext.Orders
                    .Where(order => order.CustomerId == user.Id)
                    .ToList();

                if (orderHistory.Count > 0)
                {
                    // Display order history
                    Console.WriteLine("Order History:");
                    foreach (var order in orderHistory)
                    {
                        Console.WriteLine($"Order ID: {order.OrderId}, Quantity: {order.Dimensions}, Status: {order.OrderStatus}");
                        // You can display other order details as needed
                        //order.PrintOrder();
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("No orders found! ");
                }

                // Pause for better display
                Thread.Sleep(1000);

                return orderHistory;
            }
            catch (DbUpdateException ex)
            {
                Exception? innerException = ex.InnerException;
                Console.WriteLine($"Error Message: {innerException.Message}");
                Console.WriteLine($"Stack Trace: {innerException.StackTrace}");
                return new List<Order>(); // Return an empty list --> if an error
            }
        }
    }
}
