using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shipping_Management_Application
{
    public class Truck : ITransportFactory
    {
        private readonly int _truckId;


        /// <summary>
        /// status of vehicle, ie "ready", "in transit", "returning" etc
        /// </summary>
        public string TransportStatus { get; set; }



        public void Deliver()
        {
            throw new NotImplementedException();
        }

    }
}