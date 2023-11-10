namespace Shipping_Management_Application
{
    public abstract class LogisticsFactory
    {
        public abstract ITransportFactory CreateTransport();


        public virtual void PlanDelivery()
        {
            ITransportFactory transport = CreateTransport();
            transport.Deliver();
        }
    }
}