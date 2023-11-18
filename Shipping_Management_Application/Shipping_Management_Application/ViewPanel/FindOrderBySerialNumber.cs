using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Linq;

namespace Shipping_Management_Application.ViewPanel
{
    public class FindOrderBySerialNumber
    {
        private readonly DataContext _dbContext;

        public FindOrderBySerialNumber(DataContext context)
        {
            _dbContext = context;
        }

        public void GetOrderBySerialNumber(User user)
        {
            try
            {
                Console.WriteLine("Enter Serial Number to find the order:");
                string? serialNumber = Console.ReadLine();

                // Assuming there is a DbSet<Order> in your DataContext
                Order? foundOrder = _dbContext.Orders
                    .Include(o => o.Customer)
                    .FirstOrDefault(o => o.SerialNumber == serialNumber && o.CustomerId == user.Id && user.Role == "Customer");

                if (foundOrder != null) 
                {
                    // Display order details
                    Console.WriteLine($"Order ID: {foundOrder.OrderId}");
                    Console.WriteLine($"Dimensions: {foundOrder.Dimensions}");
                    Console.WriteLine($"RecieverAddress: {foundOrder.RecieverAddress}");
                    Console.WriteLine($"Order Status: {foundOrder.OrderStatus}");
                    // Display other order details as needed
                }
                else
                {
                    Console.WriteLine("Order not found with the specified serial number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                // You might want to log or handle the exception in an appropriate way
            }
        }
    }
}
