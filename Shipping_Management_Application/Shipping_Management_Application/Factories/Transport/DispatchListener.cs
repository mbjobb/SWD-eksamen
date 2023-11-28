using EventDispatcher;
using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data.Entities;
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
        private int _numberOfDeliveryMessages = 3;
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
            _numberOfDeliveryMessages = deliveryStatus.Count;
            terminal.TruckReceivedHandler += OnDispatchReceived;


        }

        public void OnDispatchReceived(object? sender, EventArgs? arguments)
        {
            if (_dispatchCount == _numberOfDeliveryMessages)
            {
                _terminal.TruckReceivedHandler -= OnDispatchReceived;
                return;
            }
            try
            {
            }
            catch (Exception)
            {

                //known bug
            }
                Console.WriteLine(deliveryStatus[_dispatchCount]);
                _orderController.UpdateOrderStatus(_order, deliveryStatus[_dispatchCount]);
                //Interlocked.Increment(ref _dispatchCount);
                _dispatchCount++;


        }
    }
}
