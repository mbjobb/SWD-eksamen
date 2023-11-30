using Shipping_Management_Application.Data.Entities;
using Shipping_Management_Application.Factories.Transport;

namespace Shipping_Management_Application.Factories.Logistics
{
    /// <summary>
    ///    Abstract class for the LogisticsFactory class with the methods that are used in the UI.
    /// </summary>
    public abstract class LogisticsFactory{
        public abstract ITransport CreateTransport(Order order);
        
        // Calculates the delivery cost based on the address and returns the price, this was an easy way to simulate
        // variable cost
        public int DeliveryCost(string address){
            
            if (string.IsNullOrEmpty(address)){
                throw new ArgumentException("You need an address to calculate the delivery price");
            }

            string numbersInString = FetchNumberFromAddress(address);

            if (string.IsNullOrEmpty(numbersInString)){
                throw new InvalidOperationException("There are no numbers in your address");
            }

            int convertAddressNumber = int.Parse(numbersInString);
            int price = 100;
            return convertAddressNumber * price;
        }
        // Fetches the numbers from the address and takes the number from address and returns it as a string
        public string FetchNumberFromAddress(string address){
            string number = "";

            foreach (char c in address){
                if (char.IsDigit(c)){
                    number += c;
                }
                else if (number != ""){
                    break;
                }
            }
            return number;
        }
    }
}