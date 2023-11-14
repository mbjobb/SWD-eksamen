namespace Shipping_Management_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {


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


