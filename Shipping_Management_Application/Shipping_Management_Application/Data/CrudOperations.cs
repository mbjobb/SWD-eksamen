using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;

namespace Shipping_Management_Application.Data
{
    public static class CrudOperations
    {
        public static User GetUserByUserNmaeAndPassword(string? userName, string? password)
        {
            
            using  DataContext context = new ();

            if(userName is null || password is null)
            {
                return ArgumentNullException;

            } 
            User? user = context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            return user;

        }

    }
}
