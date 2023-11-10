using Shipping_Management_Application.BuisnessLogic.AdminFolder;
using Shipping_Management_Application.Data;

namespace Shipping_Management_Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            //////////////////////////////////////////////////////////////////////////////////ADMIN
            DbConfig config = new DbConfig("User.db");
            DatabaseHandler dbHandler = new DatabaseHandler(config);

            //Save super Admin username & password here
            string AdminUserName = "Admin";
            string AdminPassword = "Admin1234";

            Admin adminUserToCheck = new Admin(AdminUserName, AdminPassword);//Check if Admin exist in the database
            Admin adminUserToInsert = new Admin(AdminUserName, AdminPassword); //If Admin does not exist then add the Admin data in to the database
            string role = "Administrator";


            dbHandler.CheckAndInsertAdminToDb(adminUserToCheck, adminUserToInsert, role); // Check if admin already exist if not add admin to the Database
            dbHandler.CreateTables(); //Create the Database

            //////////////////////////////////////////////////////////////////////////////////ADMIN


            AdminController adminController = new AdminController();
            List<Admin> admins = adminController.GetAllAdmins();


        }
    }
}
