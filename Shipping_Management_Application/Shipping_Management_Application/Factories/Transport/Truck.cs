using System.Data;
namespace Shipping_Management_Application.Factories.Transport
{
    public class Truck : ITransport {
        public void Deliver(){
            Console.WriteLine("Delivering by truck");
        }
        
    }
}