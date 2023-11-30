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

            new InitializeApp();
            /// <summary>
            /// 
            /// Referances are in the readme file
            /// could also be a good idea to reset the database
            /// 
            /// Facade pattern start. 1/2 <see cref="UI.InitializeApp"/>
            /// Used to define the flow of the program without
            /// dictating the actual implimentation
            /// 
            /// Refactoring start
            /// Refactoring documetnation, 
            /// too make it easier to see the 
            /// refactoring we've forked the project to show a pre-refactored
            /// version for comparison.
            /// The navigation link will guide the refactoring journey.
            /// <see cref="PreRefactorUserController"/>
            /// </summary>

            //Wrapper for testing during development,
            //Technically a facade pattern
            //TestingThings.Testing();
            ///<see cref="TestingThings"/>



        }
    }
}


