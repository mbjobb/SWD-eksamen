using Shipping_Management_Application.BuisnessLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Shipping_Management_Application.Factories.Transportt;


public class Truck //ITransportFactory 
{
    private readonly int _truckId;
    Order _order = new();
    /// <summary>
    /// status of vehicle, ie "ready", "in transit", "returning" etc
    /// </summary>
    public string TransportStatus { get; set; }

    public string DeliverTo(string ShippingCountry)
    {
        if (ShippingCountry != null)
        {
            return DeliverOrderByCountry(ShippingCountry);
        }
        return "Entry your Country";
    }
    // Truck transport = new();
    // Deliver().DeliverOrderByCountry(country);
    //Default method to take an order and deliver to shipping adresse (just in norweay)
    //if Country == "Norway"--> genereat Mehtod to take order and delvire
   

    public string DeliverOrderByCountry(string country, string Adress_PostalCode = "0")
    {
        string originalCountry = country;
        country = country.ToLower();
        if (country != "norway")
        {
            //Loading DeliverByAir()
            DeliverByAir("Air");
        }
        else
        {
            //loading DeliverByTruck()
            // if (zipCode[0] == "5" ) ---> Bergen  DeliverByTrain() if cipCode = 5568 --> cipCode[0] = 5
            // if(zipCode[0]== "0") ---> oslo DeliverByTruck()
            //if(zipCode[0] == "8")---> NordLandet (DeliverByTrain() DeliverByTruck())
            //Hashtable<string, string> cityes = new(); 
            //if (Adress_PostalCode[0].Equals())
            //{

            //}
           
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
    //Method to DeliverByTrain()
    private void DeliverByTrain(string text)
    {
        //Print 
        Print($"We get your order! we take care and deliver for you by {text}");

    }
    // Method to DeliverByPostalCode()
    private string DeliverByPostalCode(string _postalCode)
    {
        //loading DeliverByTruck()
        // if (zipCode[0] == "5" ) ---> Bergen  DeliverByTrain() if cipCode = 5568 --> cipCode[0] = 5
        // if(zipCode[0]== "0") ---> oslo DeliverByTruck()
        //if(zipCode[0] == "8")---> NordLandet (DeliverByTrain() DeliverByTruck())
        //if (Adrees_PostalCode)
        //{

        //}
        //loading DeliverByTruck()
        // if (zipCode[0] == "5" ) ---> Bergen  DeliverByTrain() if cipCode = 5568 --> cipCode[0] = 5
        // if(zipCode[0]== "0") ---> oslo DeliverByTruck()
        //if(zipCode[0] == "8")---> NordLandet (DeliverByTrain() DeliverByTruck())
        //Hashtable<string, string> cityes = new();
        //if (Adress_PostalCode[0].Equals())
        //{

        //}

        return "ok";
    }
    private void Print(string message)
    {
        Console.WriteLine($"{message}");
    }
}