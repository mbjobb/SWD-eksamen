using Shipping_Management_Application.Data;

namespace Shipping_Management_Application.Factories.Transport
{
    public interface ITransport{
        public void Deliver(); 
        int DeliveryCost(string address);

    }
}