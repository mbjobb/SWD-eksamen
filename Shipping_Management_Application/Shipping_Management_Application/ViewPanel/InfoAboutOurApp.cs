using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.ViewPanel
{
    public class InfoAboutOurApp
    {
        public void WelcomeMesseag()
        {
            System.Console.WriteLine("Welcome to our Application");
        }
        public void About()
        {
            System.Console.WriteLine("Martin og Ifrem have to write about Application");
        }
        public void EndProgram()
        {
            System.Console.WriteLine("Martin og Ifrem have to write text");

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
