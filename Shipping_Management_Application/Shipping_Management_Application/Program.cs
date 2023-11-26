using Microsoft.Data.Sqlite;
using NUnit.Framework;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
using Shipping_Management_Application.UI;
using System;

namespace Shipping_Management_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //Wrapper for testing during development,
            //should be removed in final version.
            //Technically a facade pattern
            //TestingThings.Testing();

            /// <summary>
            /// Facade pattern start.
            /// Used to define the flow of the program without
            /// dictating the actual implimentation
            /// </summary>
            
            new InitializeApp();
            
        }

        
    }
}


