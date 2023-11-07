using Shipping_Management_Application.Services.Factory;

namespace Shipping_Management_Application.Factory{
    public class Truck : ITransport{
        public string Deliver(){
            return "";
        }
        public int GetShippingCost(){
            return 100;
        }
    }
}