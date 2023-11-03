using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shipping_Management_Application.Factories.Logistics
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