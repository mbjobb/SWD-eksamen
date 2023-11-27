using System.Data;
namespace Shipping_Management_Application.Factories.Transport
{
    public class Truck : ITransport {
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
            _orderController.UpdateOrderStatus(_order, deliveryStatus[3]);
            Console.WriteLine(_order);
            
        }
    }

}