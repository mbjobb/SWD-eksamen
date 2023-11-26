using Shipping_Management_Application.Factories.Transport;

namespace Shipping_Management_Application.Factories.Logistics
{
    public class RoadLogistics : LogisticsFactory
    {
        public override ITransport CreateTransport(){
           return new Truck();
        }
    }
}