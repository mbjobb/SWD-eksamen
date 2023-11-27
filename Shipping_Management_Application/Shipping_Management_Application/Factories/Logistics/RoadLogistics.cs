using System.Diagnostics.CodeAnalysis;
using EventDispatcher;
using Shipping_Management_Application.Data.Entities;
using Shipping_Management_Application.Factories.Transport;

namespace Shipping_Management_Application.Factories.Logistics{
    public class RoadLogistics : LogisticsFactory{
        private Order _order;
        [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
        public override ITransport CreateTransport(){
           return new Truck(dispatchTerminal, _order);
        }
        
        DispatchTerminal dispatchTerminal = new();
       
    }
}