using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.UI
{
    public static class ConsoleController
    {
        /// <summary>
        /// Controller for console input and output
        /// </summary>
        
        public static void SetTitle( string title )
        {
            Console.Title = title;
        }
        public static void ClearConsole() 
        {
            Console.Clear();
        }


        public static char ReadASingleKeyPress(string? validInput = null)
        {
            char Input;
            
            do
            {
                validInput = validInput.ToLower();
                Input = Console.ReadKey().KeyChar;

            } while (validInput != null);

            return Input;
        }

        public static string ReadAStringInput(string? validInput = null) 
        {
            string Input = null;


            return Input;
        }
    }
}
