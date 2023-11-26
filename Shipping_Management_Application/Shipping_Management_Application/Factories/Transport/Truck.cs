using System.Data;
namespace Shipping_Management_Application.Factories.Transport
{
    public class Truck : ITransport {
        public void Deliver(string shippingAddress){
            Console.WriteLine($"Delivering to {shippingAddress} by truck");
        }
    }
}