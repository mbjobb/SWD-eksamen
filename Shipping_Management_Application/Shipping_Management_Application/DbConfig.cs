namespace Shipping_Management_Application
{


    public class DbConfig // Make this public
    {
        public string DatabasePath { get; }

        public DbConfig(string databasePath = "UserDb.db")
        {
            DatabasePath = databasePath;
        }
    }

}
