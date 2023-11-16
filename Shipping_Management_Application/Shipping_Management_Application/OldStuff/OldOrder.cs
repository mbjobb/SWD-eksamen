using Shipping_Management_Application.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping_Management_Application.OldStuff
{
    public class OldOrder
    {

        public long OrderId { get; set; }

        public int Quantity { get; set; }
        public string? ShippingAddress { get; set; } = "Norway";
        public string? OrderStatus { get; set; } = "Order placed";
        public DateTime OrderDate { get; set; } = DateTime.Now;


        public long CustomerId { get; set; }

        public Customer Customer { get; set; }
        public string? SerialNumber { get; set; }
        List<OldOrder> _orders = new();
        private long _orderId;

        public OldOrder()
        {
        }

        public OldOrder(int quantity, string shippingAddress, int customerId)
        {
            Quantity = quantity;
            ShippingAddress = shippingAddress ?? throw new ArgumentNullException(nameof(shippingAddress));
            CustomerId = customerId;
            SerialNumber = GenerateSerialNumberToOrder(4); // GenerateSerialNumber Automeat
        }

        public OldOrder(long customerId)
        {

            CustomerId = customerId;
        }

        public void PlanDelivery()
        {
            throw new NotImplementedException();
        }
        // method to ckeck isorderplaced -> true hvis "Order placed": false
        public bool IsOrderPlaced()
        {
            return OrderStatus == "Order placed";
        }
        //method to getallorders
        public List<OldOrder> GetAllOrders()
        {

            foreach (OldOrder order in _orders)
            {
                Console.WriteLine(order);
            }
            return _orders;
        }
        //method tostring 
        public override string ToString()
        {
            return $"Order ID: {OrderId}, Quantity: {Quantity}, Status: {OrderStatus}";
        }
        //method to Print order 
        public void PrintOrder()
        {
            //Console.WriteLine($"--------------------- Thanks you  {Customer.FirstName} for you ordred! ");
            Console.WriteLine($"--------------------  CustomerId  : {Customer.CustomerId}         --------------------");
            //Console.WriteLine($"--------------------  Customer    : {Customer.FirstName + Customer.LastName}           --------------------");
            Console.WriteLine($"--------------------  OrderId     : {OrderId}            --------------------");
            Console.WriteLine($"--------------------  Quantity    : {Quantity}           --------------------");
            Console.WriteLine($"--------------------  Address     : {ShippingAddress}    --------------------");
            Console.WriteLine($"--------------------  OrderStatus : {OrderStatus}        --------------------");
            Console.WriteLine($"--------------------  OrderDate   : {OrderDate}          --------------------");
            Console.WriteLine($"-----------------------------------------------------------------------------");
            // call to GenerateSerialNumberToOrder() to generateSerialnumber by 8 chars 
            Console.WriteLine($"---------- SerialNumber: {GenerateSerialNumberToOrder(4)}   --------------------");
        }
        //
        //Method to genreate serialnumber to order 
        public string GenerateSerialNumberToOrder(int length, string ser = "")
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Character set for random string
            var random = new Random();
            // return new string from chars by input length size and using random class to generate random string!
            string serialNumber;
            // serialnumber[0] = "A" add A-serialnumber 
            HashSet<string> serialList = new();
            // we check if serialNumber is Duplicate or not, we add all of serialNumber to serialList and we check....
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
