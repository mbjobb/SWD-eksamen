using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.ViewPanel
{
    public class PricingModule
    {


        //Fields 
        
        public long Id { get; set; }
        public string from_region { get; set; }
        public string to_region{ get; set; }
        public int distance_km { get; set; }
        public int price { get; set; }

        // Connection for db
        private readonly DataContext _dbContext;

        public PricingModule(DataContext context)
        {
            _dbContext = context;
        }

//Geting Km from  norway_cities_delivery.db and multipl. with 5 to calculate a price -> based on diatance.
        public string GetDistans(string startPoint, string endPoint)
        {
            startPoint = from_region.ToLower();
            endPoint = to_region.ToLower();
            //var distan
            
            //return distans;
            return "connected to db";
        }

    }
}
