using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace Shipping_Management_Application.Factories.Transport
{
    public class Truck //ITransportFactory 
    {
        private readonly int _truckId;
        /// <summary>
        /// status of vehicle, ie "ready", "in transit", "returning" etc
        /// </summary>
        public string? TransportStatus { get; set; }

        public string DeliverTo(string Input)
        {
            if (Input != null)
            {
                return DeliverOrderByCountry(Input);
            }
            return "Entry your Country";
        }
        // Truck transport = new();
        // Deliver().DeliverOrderByCountry(country);
        //Default method to take an order and deliver to shipping adresse (just in norweay)
        //if Country == "Norway"--> genereat Mehtod to take order and delvire
        public bool _flag = false;

        public string DeliverOrderByCountry(string country)
        {
            string originalCountry = country;
            country = country.ToLower();
            if (country != "norway")
            {
                //Loading DeliverByAir()
                DeliverByAir("Air");
                _flag = true;

            }
            else
            {
                //loading DeliverByTruck()
                // if (zipCode[0] == "5" ) ---> Bergen  DeliverByTrain() if cipCode = 5568 --> cipCode[0] = 5
                // if(zipCode[0]== "0") ---> oslo DeliverByTruck()
                //if(zipCode[0] == "8")---> NordLandet (DeliverByTrain() DeliverByTruck())
                DeliverByTruck("Truck");
            }
            return originalCountry;

        }
        // Method to DeliverByAir 
        private void DeliverByAir(string text)
        {
            // Print 
            Print($"We get your order! we take care and deliver for you by {text}");

        }
        //Method to DeliverByTruck()
        private void DeliverByTruck(string text)
        {
            Print($"We get your order! we take care and deliver for you by {text}");
        }
        private void DeliverByTrain(string text)
        {
            //Print 
            Print($"We get your order! we take care and deliver for you by {text}");

        }
        private void Print(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}