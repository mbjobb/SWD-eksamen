namespace Shipping_Management_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread.Sleep(1000);

                MainViewPanel mainViewPanel = new();
                mainViewPanel.MainView();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


