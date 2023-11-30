using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;

namespace Shipping_Management_Application.BuisnessLogic.Controllers
{
    /// <summary>
    /// UserController class with the methods that are used in the UI.
    /// </summary>
    public class UserController : IUserController
    {
        public Customer CreateCustomer(long id, string? name, string? email, string? address, string? postCode)
        {
            Customer customer = new(id, name, email, address, postCode);
            CrudOperations.CreateCustomer(customer);
            return customer;
        }

        public UserEntity CreateUser(string username, string password)
        {
            UserEntity user = new User(username, password);
            CrudOperations.CreateUser(user);
            return user;
        }

        public UserEntity? GetUserEntityByUsernameAndPassword(string username, string password)
        {
            UserEntity? user = CrudOperations.GetUserByUserNameAndPassword(username, password);
            return user ?? null;
        }

        public bool UsernameAndPasswordMatchFoundInDB(string username, string password)
        {
            bool matchFound = CrudOperations.CheckIfUserExists(username, password);
            return matchFound;
        }

        public UserEntity? GetUserEntityByIdOrUsername(long id = 0, string? username = null)
        {
            if (id != 0) { return CrudOperations.GetUserEntityById((long)id); }
            if (username is not null) { return CrudOperations.GetUserEntityByUsername(username); }
            return null;
        }

        public void DeleteUserEntity(UserEntity user)
        {
            CrudOperations.DeleteUserEntity(user);
        }

        public Customer GetCustomer(UserEntity user)
        {
            return CrudOperations.GetCustomerById(user.Id);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            return CrudOperations.UdateCustomer(customer);
        }

        /// <summary>
        /// after refactorin cont.
        /// the business logic layer has seperated update customer and update userentity
        /// this lets us reuse the update userentity method for admin and any future userentities
        /// <see cref="CrudOperations.UpdateUserentity"/>
        /// </summary>

        public void UpdateCustomerWithValues(Customer customer, string option, string value)
        {
            switch (option.ToLower())
            {

                case "email":
                    {
                        customer.Email = value;
                        break;
                    }
                case "address":
                    {
                        customer.Adress = value;
                        break;
                    }
                case "postcode":
                    {
                        customer.PostCode = value;
                        break;
                    }
            }
            UpdateCustomer(customer);
        }

        public void UpdateUserEntityPassword(UserEntity user, string value)
        {
            user.Password = value;
            CrudOperations.UpdateUserentity(user);
        }

    }
}
