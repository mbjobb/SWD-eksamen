using Shipping_Management_Application.Data;

namespace Shipping_Management_Application.Factories.Transport
{
    public interface ITransport{

        //TODO: Deliver should take paramaters
        //TODO: Change if one truck goes to many addresses
        public void Deliver(); 
    }
}