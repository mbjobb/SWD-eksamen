using Shipping_Management_Application.Factories.Transport;

namespace Shipping_Management_Application.Factories.Logistics
{
    /// <summary>
    ///   Abstract class for the LogisticsFactory class with the methods that are used in the UI.
    ///   <see cref="LogisticsFactory"/>
    ///    <summary/>
    public class RoadLogistics : LogisticsFactory
    {
        public override ITransport CreateTransport(){
           return new Truck();
        }
    }
}