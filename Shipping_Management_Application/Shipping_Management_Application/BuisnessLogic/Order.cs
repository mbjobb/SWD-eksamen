using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Shipping_Management_Application.BuisnessLogic.User
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public string TypeOfGoods { get; set; }
        public int Weight { get; set; }
        public double? Dimensions { get; set; }
        public string? RecieverName { get; set; }
        public string RecieverAddress { get; set; } = "NB! We currently offer delivery within Norway";
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string SerialNumber { get; set; }
        public string OrderStatus { get; set; } = "Order received! You will shortly receive a confirmation!";
        public DateTime OrderDate { get; set; } = DateTime.Now;

        // Navigation properties
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public UserEntity User { get; set; }

        public Order()
        {
        }

        public Order(long userId, string sendetFullName, string typeOfGoods, int weight, double? dimensions,
            string reciverName, string recieverAddress, string postalCode, string country, string region)
        {
            CustomerId = userId;
            RecieverName = sendetFullName;
            OrderDate = DateTime.Now;
            SerialNumber = GenerateSerialNumberToOrder(4);
            TypeOfGoods = typeOfGoods;
            Weight = weight;
            Dimensions = dimensions;
            RecieverAddress = recieverAddress;
            PostalCode = postalCode;
            Country = country;
            Region = region;
        }

        public override string ToString()
        {
            return $"Order ID: {OrderId}, TypeOfGoods: {TypeOfGoods}, RecieverName: {RecieverName}, RecieverAddress: {RecieverAddress}, Status: {OrderStatus}";
        }

        public void PrintOrder(Order order)
        {
            // Truck transpot = new(); // You might want to create an instance of Truck and use it in your printout

            Console.WriteLine($"Thank you for using our service!\nYour delivery order to {order.RecieverName} to {order.RecieverAddress} has been placed {order.OrderDate.Year}{order.OrderDate.Day}{order.OrderDate.Hour}!");
            Console.WriteLine($"********************************************************************************************************");
            Console.WriteLine($"Order Details");
            Console.WriteLine($"********************************************************************************************************");
            Console.WriteLine($"--------------------  Sender_Id         : {order.CustomerId}        --------------------");
            Console.WriteLine($"--------------------  Sendet Full Name  : {order.RecieverName}      --------------------");
            Console.WriteLine($"--------------------  OrderId           : {order.OrderId}           --------------------");
            Console.WriteLine($"--------------------  Reciever Name     : {order.RecieverName}       --------------------");
            Console.WriteLine($"--------------------  Reciever Address  : {order.RecieverAddress}   --------------------");
            Console.WriteLine($"--------------------  Reciever Address  : {order.Country}            --------------------");
            Console.WriteLine($"--------------------  Type Of Goods     : {order.TypeOfGoods}       --------------------");
            Console.WriteLine($"--------------------  OrderStatus       : {order.OrderStatus}       --------------------");
            Console.WriteLine($"--------------------  OrderDate         : {order.OrderDate}         --------------------");
            Console.WriteLine($"--------------------- SerialNumber: {GenerateSerialNumberToOrder(4)}       --------------------");
            // Console.WriteLine($"--------------------- Transpor :  {transpot.DeliverTo(Country)}    --------------------");
            Console.WriteLine($"--------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Additional information! Please provide Order SerialNumber when contacting our customer service!");
        }

        public string GenerateSerialNumberToOrder(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            string serialNumber;

            HashSet<string> serialList = new();

            do
            {
                serialNumber = new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                if (!serialList.Contains(serialNumber))
                {
                    serialList.Add(serialNumber);
                    return serialNumber;
                }
                else
                {
                    Console.WriteLine($"Duplicate serial number found  {serialNumber}");
                }

            } while (true);
        }
    }
}
