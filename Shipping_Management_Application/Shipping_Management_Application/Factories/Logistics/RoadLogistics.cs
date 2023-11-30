using System.Diagnostics.CodeAnalysis;
using EventDispatcher;
using Shipping_Management_Application.Data.Entities;
using Shipping_Management_Application.Factories.Transport;

namespace Shipping_Management_Application.Factories.Logistics{
    public class RoadLogistics : LogisticsFactory{
        private Order? _order;

        public override ITransport CreateTransport(Order order){
           return new Truck(order, _dispatchTerminal);
        }
        
        DispatchTerminal _dispatchTerminal = new();
       
    }
}