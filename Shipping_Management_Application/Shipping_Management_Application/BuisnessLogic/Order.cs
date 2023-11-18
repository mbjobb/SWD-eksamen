using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;

namespace Shipping_Management_Application.BuisnessLogic;

public class Order
{

    //Getter and Setter
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    public string? TypeOfGoods { get; set; }
    public  int Weight { get; set; }
    public double? Dimensions { get; set; } //Length x Width . We will decide how to acchieve this!
    public string? ReciverName { get; } = "Add the reciever or Company name";
    public string? RecieverAddress { get; set; } = "NB! We currently offer delivery within Norway";
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Region { get; set; }
    public string? SerialNumber { get; set; }
    public string? OrderStatus { get; set; } = "Order recieved! You will shortly recieve a conformation!";
    public DateTime OrderDate { get; set; } = DateTime.Now;
   
   
    //Getter & Setter for customer
    public Customer Customer { get; set; }
    public long CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public UserEntity user { get; set; }

    public Order()
    {
    }

    //Order Constructor
    public Order(long userId, string? typeOfGoods,int weight, double? dimensions, string? reciverName, string? recieverAddress, string? postalCode, string? country, string? region)
    {

        OrderStatus = OrderStatus;
        CustomerId = userId;
        OrderDate = DateTime.Now;
        SerialNumber = GenerateSerialNumberToOrder(4);
        TypeOfGoods= typeOfGoods;
        Weight= weight;
        Dimensions= dimensions;
        ReciverName = reciverName;
        RecieverAddress = recieverAddress;
        PostalCode = postalCode;
        Country = country;
        Region = region;
        
    }
    //public class Order
    //{
    //    [Key]
    //    public int OrderId { get; set; }
    //    public string? Quantity { get; set; }
    //    public string? ShippingAddress { get; set; } = "Norway";
    //    public string? OrderStatus { get; set; } = "Order placed";
    //    public DateTime OrderDate { get; set; } = DateTime.Now;
    //    public string? PostalCode { get; set; }
    //    public string? SerialNumber { get; set; }



    //    public Customer Customer { get; set; }
    //    [ForeignKey("Customer")]
    //    public long CustomerId { get; set; }

    //    public Order()
    //    {
    //    }

    //    //public Order(string quantity, string shippingAddress, string orderStatus, Customer customer)
    //    //{
    //    //    Quantity = quantity;
    //    //    ShippingAddress = shippingAddress ?? throw new ArgumentNullException(nameof(shippingAddress));
    //    //    SerialNumber = GenerateSerialNumberToOrder(4); // GenerateSerialNumber Automeat

    //    //}

    //    public Order(long userId, string? quantity, string? shippingAddress, string postalCode) { 

    //        Quantity = quantity;
    //        ShippingAddress = shippingAddress;
    //        OrderStatus = "Placed";
    //        OrderDate = DateTime.Now;
    //        PostalCode = postalCode;
    //        SerialNumber = GenerateSerialNumberToOrder(4);  
    //        CustomerId = userId;
    //    }

    //method tostring 
    public override string ToString()
    {
        return $"Order ID: {OrderId}, TypeOfGoods: {TypeOfGoods}, RecieverName: {ReciverName}, RecieverAddress {RecieverAddress} , Status: {OrderStatus}";
    }
    //method to Print order 
    public void PrintOrder(Customer customer, string? typeOfGoods,string? orderStatus, string? recieverName, string? recieverAddress, DateTime dateTime)
     {

        Console.WriteLine($"Thank you for using our service! \n Your delivery order to {recieverName} to {recieverAddress} has been placed {dateTime.Year}{dateTime.Day}{dateTime.Hour}!");
        Console.WriteLine($"********************************************************************************************************");
        Console.WriteLine($"Order Details");
        Console.WriteLine($"********************************************************************************************************");
        Console.WriteLine($"--------------------  Sender_Id         : {customer.CustomerId}                    --------------------");
        Console.WriteLine($"--------------------  Sendet Full Name  : {customer.FirstName + customer.LastName}  --------------------");
        Console.WriteLine($"--------------------  OrderId           : {OrderId}                                 --------------------");
        Console.WriteLine($"--------------------  Reciever Name     : {recieverName}                            --------------------");
        Console.WriteLine($"--------------------  Reciever Address  : {recieverAddress}                         --------------------");
        Console.WriteLine($"--------------------  Type Of Goods     : {typeOfGoods}                             --------------------");
        Console.WriteLine($"--------------------  OrderStatus       : {orderStatus}                             --------------------");
        Console.WriteLine($"--------------------  OrderDate         : {OrderDate}                               --------------------");
        Console.WriteLine($"--------------------- SerialNumber: {GenerateSerialNumberToOrder(4)}                --------------------"); // call to GenerateSerialNumberToOrder() to generateSerialnumber by 8 chars 
        Console.WriteLine($"--------------------------------------------------------------------------------------------------------");
        Console.WriteLine($"Additional information! \n Please provide Order SerialNumber when contacting our customer service! ");


    }

    // Method to generate serial number for the order
    public string GenerateSerialNumberToOrder(int length, string ser = "")
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
