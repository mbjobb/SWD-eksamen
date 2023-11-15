using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.UI
{
    public static class DrawUI
    {
        public static void SetTitle( string title )
        {
            Console.Title = title;
        }
        public static void ClearConsole() 
        {
            Console.Clear();
        }

        public static void DisplayMessage(string message ) 
        {
            Console.WriteLine(message);
        }

        public static void ReadASingleKeyPress(char key)
        {
            char Input;
            Console.ReadKey();
        }
    }
}
