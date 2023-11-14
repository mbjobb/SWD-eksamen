/**
using Shipping_Management_Application.Factories.Transport;

namespace Shipping_Management_Application.Factories.Logistics
{
    public class RoadLogistics : LogisticsFactory
    {
        public override ITransportFactory CreateTransport()
        {
            return new Truck();
        }
    }
}
**/