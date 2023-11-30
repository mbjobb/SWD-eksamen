using Shipping_Management_Application.Data;

namespace Shipping_Management_Application.UI
{
    /// <summary>
    /// Class for the FirstStart class with the methods that are used in the UI.
    /// </summary>
    public static class FirstStart
    {
        //in theory this would be done when setting up the cloud infrastructure.
        //and when users open the application they would connect to an already existing database,
        ///so they would never see this
        // checks if the user entity table is empty and creates an admin account if it is
        public static void ChecksIfUserEntityTableIsEmpty()
        {


            bool IsUserEntitiesTableEmpty = CrudOperations.IsUserEntitiesTableEmpty();

            if (IsUserEntitiesTableEmpty)
            {
                Console.WriteLine("First launch, checking if any accounts exist");
                Console.WriteLine("No users in database, creating admin account");
                Admin admin = CrudOperations.CreateFirstAdmin();
                Console.WriteLine("Admin created");
                Console.WriteLine($"Admin username: {admin.UserName}");
                Console.WriteLine($"Admin user password: {admin.Password}");
                Console.WriteLine("Please log in and change the password");
            }


        }
    }
}
