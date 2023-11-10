using Shipping_Management_Application.BuisnessLogic.AdminFolder;

namespace Shipping_Management_Application
{
    public class Program
    {
        static void Main(string[] args){

            AdminController adminController = new();
            //adminController.CreateAdmin("Henrik", "1234");
            adminController.CreateAdmin("Saro", "12345");
            //adminController.GetAllAdmins();
            adminController.GetAdminByUserName("Saro");

            adminController.UpdateAdminName("Saro", "Martin");
            Console.WriteLine(adminController.CreateAdmin("Henrik", "Henrik"));



















            /**
            Admin admin = new("saro", "saro");
            Admin admin1 = new("henrik", "henrik");
            Admin admin2 = new("martin", "martin");
            AdminController adminController = new AdminController();
            List<Admin> admins = adminController.GetAllAdmins();

            admins.Add(admin);
            admins.Add(admin1);
            admins.Add(admin2);

            Console.WriteLine("Admins er opprettet og lagt til i listen.");

            string oldAdminUserName = admin.UserName;
            Admin? updatedAdmin = adminController.UpdateAdminName(admins, oldAdminUserName, "Ahmad");
            if (updatedAdmin != null){
                Console.WriteLine($"You updated {oldAdminUserName} to {updatedAdmin.UserName}");
            }

            foreach (Admin item in admins){
                if (true){
                    Console.WriteLine(item);
                }
                throw new ArgumentNullException();
            }

            if (admins.Count == 0)
            {
                Console.WriteLine("Ingen admin-objekter i listen.");
            }**/
        }
    }
}
