using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.UserFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.ViewPanel
{
    public class OrderRegistration
    {
        //This class can used by Customer and Admin to doing CURD operation 
        User? _user { get; set; }
        Order? _order { get; set; }
        List<Order>? _orders { get; set; }

        //Method to create an order from Customer and Admin
        public void CreateOrder()
        {
            Console.WriteLine("Register your Order!");

            //connection to db

        }
        //Method to Update order and send back to database
        public void UpdateOrder(int orderId)
        {
            //connection to db, and get order by orderId and we update and send back to db 

        }
        //Method to delate Order 
        public void DeleteOrder(int orderId)
        {
            //connection to db

        }
        //Method to ReadOrder from Database 
        public List<Order> GetOrders()
        {
            //connection to db
            return _orders;
        }
    }
}
