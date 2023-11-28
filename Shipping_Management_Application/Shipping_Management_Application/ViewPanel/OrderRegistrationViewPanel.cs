using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.Data;
using System;
using System.Diagnostics.Metrics;
using System.Linq;

namespace Shipping_Management_Application.ViewPanel
{
    public class PlaceOrderRegistrationViewPanel
    {
        private readonly DataContext _dbContext;

        public PlaceOrderRegistrationViewPanel(DataContext context)
        {
            _dbContext = context;
        }

        // OrderRegistration.cs and showing for Admin and Customer In Console
        public void CreateOrderPanel(User user)
        {
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("Please place your order by providing package details and delivery information!");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("Pleas enter your Full Name");
            string? SendetFullName = Console.ReadLine();
            Console.WriteLine("Type of Goods (e.g., electronics, perishabel, fragile items, Heavy Items)");
            string? typeOfGoods = Console.ReadLine();
            Console.WriteLine("Weight:");
            string? weightNumber = Console.ReadLine();
            int weight = Int32.Parse(weightNumber);
            //weight = pars .Int32(weight);
            Console.WriteLine("Dimensions (e.g., L x W):");
            string? stringDimensions = Console.ReadLine();
            double? dimensions = double.Parse(stringDimensions);
            Console.WriteLine("ReciverName: ( Add the reciver or company name! )");
            string? reciverName = Console.ReadLine();
            Console.WriteLine("Enter reciver address :");
            string? reciverAddress = Console.ReadLine();
            Console.WriteLine("Enter PostalCode:");
            string? postalCode = Console.ReadLine();
            Console.WriteLine("Country:");
            string? country = Console.ReadLine();
            Console.WriteLine("Region(e.g., Viken, Rogaland, Hordaland)");
            string? region = Console.ReadLine();
            

            

            try
            {
                Order _order = new Order(user.Id,SendetFullName, typeOfGoods, weight, dimensions, reciverName, reciverAddress, postalCode, country, region);
                _dbContext.Orders.Add(_order);
                _dbContext.SaveChanges();
                Console.WriteLine("Order registered successfully!");
                _order.PrintOrder(_order);
                Thread.Sleep(1000);
                CustomerViewPanel customerViewPanel = new();
                customerViewPanel.CustomerMainView(user);
            }
            catch (DbUpdateException ex)
            {
                Exception? innerException = ex.InnerException;
                Console.WriteLine($"Error Message: {innerException.Message}");
                Console.WriteLine($"Stack Trace: {innerException.StackTrace}");
            }
        }
        //method to genereat delivery
        public void GetDeliveryBytypeOfGoods(string typeOfGoods)
        {
            // truck.cs doing jobben , and we need one list of options 

        }
        //method to pricing by L * H = ...



        /*Requirment for weight*/
        //If weight is less than 100 kg- we dont accept
        //Pricing
        // Could be based on:_ Weight, and Dimention and postalcode
        //Base_price should be for e.g. 10% of the weight

        /******************************************/
        /*Model for pricing*/
        /*----------------------------------------*/
        /** base price Norway**/
        //10% of weight + Admin tax 25% av weight 

        /**Base price Eurpoe**/
        //15% of weight

        /**Base price Asia**/
        //20% of weight

        /**Base price Africa**/
        //25% of weight
        /******************************************/


        //For example: Let say customer want to send delivery of a 100 kg weight
        //base price based on that is: 10% of 100 . Which is 10 kr
        //final pricing will be : base_price + postalcode (distance) + 
        public string PriceDelivery(string w, string d, string postalCode)
        {
            string basePriceNorway = null;
            string basePriceo = null;
            string price = null;
            return null;
        } 
        // method tp pricing by country and state
        public string PricbyCountryAndState(string country, string state) {
            int norwayPrice = 50;
            int statePrice = 50;
            int sumPrice = norwayPrice + statePrice;
            
            if (country == null && state == null)
            {
                Console.WriteLine("country/state not found!");
            }
            else
            {
                if(state == "Oslo".ToLower())
                {
                    sumPrice = norwayPrice + statePrice;
                    return sumPrice.ToString();
                }
                else
                {
                    norwayPrice = 50;
                    statePrice += 100;
                    sumPrice = norwayPrice + statePrice;
                    return sumPrice.ToString();

                }          
            }
            return "pricee";
        }
    }
}
