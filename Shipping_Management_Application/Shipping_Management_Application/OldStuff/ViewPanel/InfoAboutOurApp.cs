using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.OldStuff.ViewPanel
{
    public class InfoAboutOurApp
    {
        //Method to HeaderComponent for Application
        public void HeaderComponent(string appName = "Shipping Management")
        {
            Console.WriteLine($"-------- {appName.ToUpper()}--------- Date : {"Year : " + DateTime.Now.Year + " Time: " + DateTime.Now.ToString("HH:mm:ss")} ---------");

        }

        public void WelcomeMesseag(string messeag = "Welcome to our Application")
        {
            Console.WriteLine(messeag);
        }
        public void About(string messeag = "Comming info about our App, Martin og Ifrem have to write about Application")
        {
            Console.WriteLine(messeag);
        }
        public void EndProgram(string messeag = "Martin og Ifrem have to write text")
        {
            Console.WriteLine(messeag);

        }

        public void GetInfoAboutOurApp()
        {
            WelcomeMesseag();
            Thread.Sleep(7000);
            About();
            Thread.Sleep(7000);
            EndProgram();
        }
    }
}
