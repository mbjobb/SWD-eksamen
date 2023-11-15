using Shipping_Management_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.UI
{
    public static class FirstStart
    {
        public static void CheckIfUserEntityTableIsEmpty()
        {
            
            using DataContext context = new();

            

            if (context.UserEntities.Count() == 0)
            {
                Console.WriteLine("First start, checking if any accounts exist");
                Console.WriteLine("No users in database, creating admin account");
                FirstStart.CreateFirstAdmin();
            } 
            
        }

        public static void CreateFirstAdmin(){
            
            using DataContext context = new();
            
            Admin admin = new("Admin", "changeme");
            context.Add(admin);
            context.SaveChanges();
            Console.WriteLine("Admin created");
            Console.WriteLine($"Admin user name: {admin.UserName}");
            Console.WriteLine($"Admin user password: {admin.Password}");
            Console.WriteLine("please log in and change the password");
        }

    }
}
