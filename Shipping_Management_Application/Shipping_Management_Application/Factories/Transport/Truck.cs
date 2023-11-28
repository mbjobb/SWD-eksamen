using System.Data;
using EventDispatcher;
using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data.Entities;

namespace Shipping_Management_Application.Factories.Transport
{
    public class Truck : ITransport
    {
        private OrderController _orderController = new();

        private DispatchTerminal _dispatcher;
        public Truck(Order order, DispatchTerminal dispatchTerminal)
        {
            
            _dispatcher = dispatchTerminal;
        }

        public void Deliver(Order order)
        {
            DispatchListener listener = new DispatchListener(_orderController, order, _dispatcher);

        }
    }

}