
namespace Shipping_Management_Application.Factories.Transport
{
    public class Truck //ITransportFactory
    {
        private readonly int _truckId;
        public string TransportStatus { get; set; }
        public void Deliver(){
        }

        public string DeliverOrderByCountry(string country)
        {
            country = country.ToLower();
            if (country != "norway")
            {
                DeliverByAir("Plane");
            }
            else
            {
                DeliverByTruck("Truck");
            }

            return null!;
        }

        public void DeliverByAir(string text){
            Print($"We get your order! We will take care and deliver for you by {text}");
        }

        public void DeliverByTruck(string text){
            Print($"We get your order! We will take care and deliver for you by {text}");
        }

        public void DeliverByTrain(string text){
            Print($"We get your order! We will take care and deliver for you by {text}");
        }

        public void Print(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}


/**
namespace Shipping_Management_Application.Factories.Transport
{
    public class Truck //ITransportFactory
    {
        private readonly int _truckId;
        /// <summary>
        /// status of vehicle, ie "ready", "in transit", "returning" etc
        /// </summary>
        public string TransportStatus { get; set; }

        public void Deliver()
        {
            // Truck transport = new();
            // Deliver().DeliverOrderByCountry(country);
            //Default method to take an order and deliver to shipping adresse (just in norweay)
            //if Country == "Norway"--> genereat Mehtod to take order and delvire
             void DeliverOrderByCountry(string Country){
                Country = Country.ToLower();
                if (Country != "norway")
                {
                    //Loading DeliverByAir()
                    DeliverByAir("Plane");
                }
                else
                {
                    //loading DeliverByTruck()
                    // if (zipCode[0] == "5" ) ---> Bergen  DeliverByTrain() if cipCode = 5568 --> cipCode[0] = 5
                    // if(zipCode[0]== "0") ---> oslo DeliverByTruck()
                    //if(zipCode[0] == "8")---> NordLandet (DeliverByTrain() DeliverByTruck())
                    DeliverByTruck("Truck");
                }
            }
            // Method to DeliverByAir 
            void DeliverByAir(string text){
                // Print 
                Print($"We get your order! we take care and deliver for you by {text}");

            }
            //Method to DeliverByTruck()
             void DeliverByTruck(string text){
                Print($"We get your order! we take care and deliver for you by {text}");
            }
            void DeliverByTrain(string text){
                //Print 
                Print($"We get your order! we take care and deliver for you by {text}");

            }
            void Print(string message)
            {
                Console.WriteLine($"{message}");
            }


        }
    }
}
**/