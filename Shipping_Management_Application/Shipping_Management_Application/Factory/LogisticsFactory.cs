using Shipping_Management_Application.Services.Factory;

namespace Shipping_Management_Application.Factory{
    public abstract class LogisticsFactory{
        
        public abstract ITransport CreateTransport();
    }
}