using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.UserFolder;

namespace Shipping_Management_Application.Data
{
    public class CrudOperations
    {
        //CURD opereation by Object type
        //method to create Object and send to database
        public void CreateObject(UserEntity user)
        {

        }
        //Method to read an object from database
        public List<UserEntity>? GetUsers(string role)
        {
            //GetUser by Role and add to different
            List<UserEntity> customers = new();
            List<UserEntity> admins = new();  // Add, save and print list
            return null; // for now
        }
        //Method to UpdateObject 
        public void UpdateObject(UserEntity user)
        {

        }
        //Method to deleteObject from database 
        public void DeleteObject(UserEntity user)
        {

        }

    }
}
