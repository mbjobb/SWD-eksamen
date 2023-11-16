using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.UI
{
    public static class FirstStart
    {
        
        public static void ChecksIfUserEntityTableIsEmpty()
        {
            /// Here be documentation

            bool IsUserEntitiesTableEmpty = CrudOperations.IsUserEntitiesTableEmpty();

            if (IsUserEntitiesTableEmpty)
            {
                Console.WriteLine("First start, checking if any accounts exist");
                Console.WriteLine("No users in database, creating admin account");
                Admin admin = CrudOperations.CreateFirstAdmin();
                Console.WriteLine("Admin created");
                Console.WriteLine($"Admin user name: {admin.UserName}");
                Console.WriteLine($"Admin user password: {admin.Password}");
                Console.WriteLine("please log in and change the password");
            }

            
        }
    }
}
