using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shipping_Management_Application
{
    public class Order
    {
        public readonly int _orderId;
        public readonly int _userId;
        public readonly DateTime _orderDate;

        public Order(int orderId, int userId, DateTime orderDate)
        {
            _orderId = orderId;
            _userId = userId;
            _orderDate = orderDate;
        }

        public int Quantity { get; set; }
        public string ShippingAdress { get; set; }
        public string OrderStatus { get; set; }

        public int OrderId => _orderId;

        public int UserId => _userId;

        public DateTime OrderDate => _orderDate;

        public void PlanDelivery()
        {
            throw new NotImplementedException();
        }
    }
}