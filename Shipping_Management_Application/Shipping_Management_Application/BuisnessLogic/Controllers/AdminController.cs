using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;

namespace Shipping_Management_Application.BuisnessLogic.Controllers
{
    public class AdminController
    {
        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return CrudOperations.GetAllUserEntities();
        }

        public UserEntity CreateAdmin(string username, string password)
        {
            return CrudOperations.CreateAdmin(username, password);
        }
    }
}
