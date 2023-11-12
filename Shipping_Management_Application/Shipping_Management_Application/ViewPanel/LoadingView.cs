using System;
using System.Threading;

namespace Shipping_Management_Application.ViewPanel
{
    public class LoadingView
    {
        public void Print(string text)
        {
            Console.Write($"{text}\n");
            Thread loadingThread = new(() =>
            {
                Thread.Sleep(3000);
                ClearLine(text);
            });

            loadingThread.Start();
            loadingThread.Join();
        }

        private void ClearLine(string text)
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.Write(new string(' ', text.Length));
            Console.SetCursorPosition(Console.CursorLeft - text.Length, Console.CursorTop);
        }
    }
}
