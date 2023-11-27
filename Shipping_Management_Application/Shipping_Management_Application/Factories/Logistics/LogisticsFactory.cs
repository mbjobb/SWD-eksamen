using Shipping_Management_Application.Factories.Transport;

namespace Shipping_Management_Application.Factories.Logistics
{
    public abstract class LogisticsFactory{
        public abstract ITransport CreateTransport();
        
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