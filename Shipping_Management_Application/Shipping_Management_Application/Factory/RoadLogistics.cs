using Shipping_Management_Application.Services.Factory;
using LogisticsFactory = Shipping_Management_Application.Services.Factories.LogisticsFactory;

namespace Shipping_Management_Application.Factory{
    
    public class RoadLogistics : LogisticsFactory{
        public override ITransport CreateTransport(){
            return new Truck();
        }
    }
}