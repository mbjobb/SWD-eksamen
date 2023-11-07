using Shipping_Management_Application.Models;

namespace Shipping_Management_Application.Repositories{
    public interface IUserRepository{
        void AddUser(User user);
        User? GetUser(string email);
    }
}