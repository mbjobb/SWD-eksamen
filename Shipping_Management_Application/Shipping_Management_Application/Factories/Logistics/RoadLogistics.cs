using System.Diagnostics.CodeAnalysis;
using EventDispatcher;
using Shipping_Management_Application.Data.Entities;
using Shipping_Management_Application.Factories.Transport;

namespace Shipping_Management_Application.Factories.Logistics{
    public class RoadLogistics : LogisticsFactory{

        public override ITransport CreateTransport(Order order){
           return new Truck( _dispatchTerminal);
        }

        readonly DispatchTerminal _dispatchTerminal = new();
       
    }
}