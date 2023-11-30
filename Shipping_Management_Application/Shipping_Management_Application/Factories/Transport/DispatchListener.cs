using EventDispatcher;
using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data.Entities;
using Shipping_Management_Application.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.Factories.Transport
{
    internal class DispatchListener
    {
        private OrderController _orderController;
        private Order _order;
        private int _dispatchCount = 0;
        private int _numberOfStatusUpdates = 3;
        private DispatchTerminal _terminal;
        private List<string> deliveryStatus = new(){
                "Ready",
                "In transit",
                "Delivered"
            };

        

        public DispatchListener(OrderController orderController, Order order, DispatchTerminal terminal)
        {
            _orderController = orderController;
            _order = order;
            _terminal = terminal;
            _numberOfStatusUpdates = deliveryStatus.Count;
            terminal.TransportReceivedHandler += OnDispatchReceived;


        }

        public void OnDispatchReceived(object? sender, EventArgs? arguments)
        {
            
            if (_dispatchCount == _numberOfStatusUpdates)
            {
                _terminal.TransportReceivedHandler -= OnDispatchReceived;
                List<string> options = new List<string>()
                {
                    "place an order",
                    "view orders",
                    "update user or customer profile",
                    "sign out",
                    "exit program"
                };
                UIController.MenuFacade(options);
                return;
            }
         
                Console.WriteLine($"order:{_order.Id} Status:{deliveryStatus[_dispatchCount]}");
                _orderController.UpdateOrderStatus(_order, deliveryStatus[_dispatchCount]);

                _dispatchCount++;


        }
    }
}
