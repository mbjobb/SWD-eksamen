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
    }
}
