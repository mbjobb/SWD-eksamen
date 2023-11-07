using Shipping_Management_Application.Services.Factory;

namespace Shipping_Management_Application.Models{
    public class Shipping{

        public int ShippingId{ get; private set; }
        public string Address{ get; }
        public ITransport Transport{ get; }
        public int Price{ get; private set; }

        public Shipping(string address, ITransport transport, int price){
            Address = address;
            Transport = transport;
            Price = price;
        }

        public string GetShippingStatus(){
            return null;
        }

        public void ExecuteShipping(Order order){
            
        }
    }
}