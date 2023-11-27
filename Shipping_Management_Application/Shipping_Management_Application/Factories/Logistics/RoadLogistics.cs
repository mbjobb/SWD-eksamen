using System.Diagnostics.CodeAnalysis;
using EventDispatcher;
using Shipping_Management_Application.Data.Entities;
using Shipping_Management_Application.Factories.Transport;

namespace Shipping_Management_Application.Factories.Logistics
{
    public class RoadLogistics : LogisticsFactory
    {
        public override ITransport CreateTransport(){
           return new Truck(dispatchTerminal, _order);
        }
        
        DispatchTerminal dispatchTerminal = new();
       
    }
}