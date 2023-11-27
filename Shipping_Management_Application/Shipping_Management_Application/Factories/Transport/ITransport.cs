﻿using Shipping_Management_Application.Data;

namespace Shipping_Management_Application.Factories.Transport
{
    /// <summary>
    /// Interface for the ITransport class with the methods that are used in the UI.
    /// </summary>
    public interface ITransport{
        public void Deliver(string shippingAddress); 
    }
}