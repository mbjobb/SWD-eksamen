using System.Data;
using EventDispatcher;
using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data.Entities;

namespace Shipping_Management_Application.Factories.Transport
{
    public class Truck : ITransport{
        private OrderController _orderController = new();
        private Order _order;
        private int _dispatchCount = 0;
        private int _numberOfDeliveryMessages;
        public void Deliver(string shippingAddress){

        }
        public Truck(DispatchTerminal terminal, Order order){
            _order = order;
            while (_dispatchCount <= _numberOfDeliveryMessages){
                terminal.TruckReceivedHandler += OnDispatchReceived;
                terminal.TruckReceivedHandler -= OnDispatchReceived;
            }
        }
        
        public void OnDispatchReceived(object? sender, EventArgs? arguments){
            List<string> deliveryStatus = new(){
                "Ready",
                "In transit",
                "Delivered",
                "Returning"
            };
            _numberOfDeliveryMessages = deliveryStatus.Count;
            Console.WriteLine(deliveryStatus[_dispatchCount]);
            _dispatchCount++;
            _orderController.UpdateOrderStatus(_order,deliveryStatus[_dispatchCount]);
            Console.WriteLine(_order);
            
        }
    }

}