namespace Shipping_Management_Application
{
    public class RoadLogistics : Logistics
    {
        public override ITransportFactory CreateTransport()
        {
            return new Truck();
        }
    }
}