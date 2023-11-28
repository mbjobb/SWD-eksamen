using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Factories.Transportt;
using System;
using System.Data.Common;
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
                    .Include(o => o.User)
                    .FirstOrDefault(o => o.SerialNumber == serialNumber);
                Truck tr = new();

                if (foundOrder != null)
                {
                    // Display order details
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine($"------Order found with {foundOrder.SerialNumber}------");
                    Console.WriteLine("*******************************************************");
                    Console.WriteLine();
                    Console.WriteLine($"Order ID:          {foundOrder.OrderId}");
                    Console.WriteLine($"Reciver name:      {foundOrder.RecieverName}");
                    Console.WriteLine($"Reciever Address:  {foundOrder.RecieverAddress}");
                    Console.WriteLine($"Reciever Region:   {foundOrder.Region}");
                    Console.WriteLine($"Reciever Country:  {foundOrder.Country}");
                    Console.WriteLine($"Dimensions:        {foundOrder.Dimensions}");
                    Console.WriteLine($"Order Status:      {foundOrder.OrderStatus}");
                    Console.WriteLine($"SerialNumber:      {foundOrder.SerialNumber}");
                    Console.WriteLine($"{tr.DeliverOrderByCountry(foundOrder.Country)}");
                    Console.WriteLine("*******************************************************");
                }
                else
                {
                    Console.WriteLine("Order not found with the specified serial number.");
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return;
            }
            
        }
    }
}
