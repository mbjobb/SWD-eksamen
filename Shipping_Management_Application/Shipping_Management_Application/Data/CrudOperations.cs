using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;

namespace Shipping_Management_Application.Data
{
    public static class CrudOperations
    {
        public static User? GetUserByUserNameAndPassword(string? userName, string? password){

            using DataContext context = new DataContext();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)){
                throw new ArgumentNullException("userName");
            }
            
            User? user = context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            Console.WriteLine($"Welcome {user?.UserName}");
            return user;
        }

        public static bool IsUserEntitiesTableEmpty()
        {
            using DataContext context = new DataContext();
            if (context.UserEntities.Count() == 0)
            {
                return true;
            } else return false;
        }

        public static Admin CreateFirstAdmin()
        {

            using DataContext context = new();

            Admin admin = new("Admin", "changeme");
            context.Add(admin);
            context.SaveChanges();
            return admin;
        }

        public static User GetUserById(long id) 
        {
            using DataContext context = new DataContext();
            User? user = context.Users.FirstOrDefault(u => (u.Id == id));
            return user;
        }
    }
}
