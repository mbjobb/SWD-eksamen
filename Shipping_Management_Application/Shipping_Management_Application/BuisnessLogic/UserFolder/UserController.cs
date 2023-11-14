using Shipping_Management_Application.Data;

namespace Shipping_Management_Application.BuisnessLogic.UserFolder
{
    public class UserController
    {
        //Database Connection
        DataContext2? dataContext;

        static void FindUserById(long id)
        {
            // User? user = DabaseContext.User.First(u => u.id == Id);
        }
        //Method to CURD 

        public Order PlaceOrder()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById()
        {
            throw new NotImplementedException();
        }

        public User CreateUser()
        {
            throw new NotImplementedException();
        }

        public void UpdateUserById()
        {
            throw new NotImplementedException();
        }

        public void DeleteUserById()
        {
            throw new NotImplementedException();
        }
    }
}