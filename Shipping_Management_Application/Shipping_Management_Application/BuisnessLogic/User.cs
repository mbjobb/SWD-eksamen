using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shipping_Management_Application.BuisnessLogic
{
    public class User
    {
        public readonly int _userId;
        public double UserBalance { get; private set; }
        public string UserEmail { get; set; }
        internal string UserName { get; set; }

        public List<Order> Orders { get; private set; }


    }
}