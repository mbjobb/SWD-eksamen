using Shipping_Management_Application.Data;
using Shipping_Management_Application.Factories.Transport;

namespace Shipping_Management_Application.Factories.Logistics
{
    public abstract class LogisticsFactory
    {
        public abstract ITransport CreateTransport();


        public virtual void PlanDelivery(){
            ITransport transport = CreateTransport();
            transport.Deliver();
        }
    }
}