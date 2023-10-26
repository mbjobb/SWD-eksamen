using Shipping_Management_Application.Factories.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.Factories.Logistics
{
    public abstract class Logistics
    {
        public abstract ITransport CreateTransport();

        public virtual void PlanDelivery()
        {
            ITransport transport = CreateTransport();
            transport.Deliver();
        }
    }
}
