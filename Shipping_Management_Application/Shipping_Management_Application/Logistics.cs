using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shipping_Management_Application
{
    public abstract class Logistics
    {
        public abstract ITransportFactory CreateTransport();


        public virtual void PlanDelivery()
        {
            ITransportFactory transport = CreateTransport();
            transport.Deliver();
        }
    }
}