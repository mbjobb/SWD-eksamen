using Shipping_Management_Application.BuisnessLogic.AdminFolder;

namespace Shipping_Management_Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new("saro", "saro");
            Admin admin1 = new("henrik", "henrik");
            Admin admin2 = new("martin", "martin");
            AdminController adminController = new AdminController();
            List<Admin> admins = adminController.GetAllAdmins();

            admins.Add(admin);
            admins.Add(admin1);
            admins.Add(admin2);

            Console.WriteLine("Admins er opprettet og lagt til i listen.");

            var oldAdminUserName = admin.UserName;
            var updatedAdmin = adminController.UpdateAdminName(admins, oldAdminUserName, "Ahmad");
            if (updatedAdmin != null)
            {
                Console.WriteLine($"You updated {oldAdminUserName} to {updatedAdmin.UserName}");
            }

            foreach (Admin item in admins)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                }
                else
                {
                    Console.WriteLine("Admin-objektet er null.");
                }
            }

            if (admins.Count == 0)
            {
                Console.WriteLine("Ingen admin-objekter i listen.");
            }
        }
    }
}
