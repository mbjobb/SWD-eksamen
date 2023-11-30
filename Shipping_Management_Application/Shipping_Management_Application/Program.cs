using Shipping_Management_Application.UI;

namespace Shipping_Management_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //Wrapper for testing during development,
            //Technically a facade pattern
            //TestingThings.Testing();
            ///<see cref="TestingThings"/>

            /// <summary>
            /// 
            /// Referances are in the readme file
            /// 
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
            /// 
            /// 
            /// Known issues
            /// The following method sometimes produces buggy behaviour.
            /// <see cref="UIController.ReadAStringInput"/>
            /// The event dispatcher may break during debugging sessions with breakpoints.
            /// ShippingAdress seems to sometimes end up as null on the first try
            /// </summary>

            new InitializeApp();



        }
    }
}


