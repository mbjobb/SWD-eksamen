namespace Shipping_Management_Application
{
    public class RoadLogistics : LogisticsFactory
    {
        public override ITransportFactory CreateTransport()
        {
            return new Truck();
        }
    }
}