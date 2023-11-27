using System.Data;
namespace Shipping_Management_Application.Factories.Transport
{
    /// <summary>
    /// class Truck with the methods that are used in the UI. implements ITransport.
    /// </summary>
    public class Truck : ITransport {
        public void Deliver(string shippingAddress){
            Console.WriteLine($"Delivering to {shippingAddress} by truck");
        }
    }
}