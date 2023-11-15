using System;
using System.Threading;

namespace Shipping_Management_Application.OldStuff.ViewPanel
{
    public class LoadingView
    {
        //method to write Loading.....
        public void Print(string text)
        {
            Console.Write($"{text}\n");
            Thread loadingThread = new(() =>
            {
                ClearLine(text);
                Thread.Sleep(3000);

            });

            loadingThread.Start();
            loadingThread.Join();
        }
        //mthedo to delate text.... buu this not warking
        private void ClearLine(string text)
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.Write(new string(' ', text.Length));
            Console.SetCursorPosition(Console.CursorLeft - text.Length, Console.CursorTop);
        }
    }
}
