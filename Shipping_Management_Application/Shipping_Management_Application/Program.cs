using Microsoft.Data.Sqlite;
using NUnit.Framework;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
using Shipping_Management_Application.UI;
using System;
using EventDispatcher;
using Shipping_Management_Application.Factories.Transport;

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
            /// 
            /// Facade pattern start. 1/2 <see cref="UI.InitializeApp"/>
            /// Used to define the flow of the program without
            /// dictating the actual implimentation
            /// 
            /// Refactoring start 1/x <see cref="UI.UIController.MenuFacade"/>
            /// 
            /// </summary>

            new InitializeApp();

            

        }
    }
}


