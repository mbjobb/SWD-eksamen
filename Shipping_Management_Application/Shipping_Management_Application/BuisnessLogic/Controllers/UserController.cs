﻿using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.BuisnessLogic.Controllers
{
    public class UserController : IUserController
    {
        public Customer CreateCustomer(long id, string? name, string? email, string? address, string? postCode)
        {
            Customer customer = new Customer(id, name, email, address, postCode);
            CrudOperations.CreateCustomer(customer);
            return customer;

        }

        public UserEntity CreateUser(string username, string password)
        {
            UserEntity user = new User(username, password);
            CrudOperations.CreateUser(user);
            return user;
        }
        public UserEntity GetUserEntityByUsernameAndPassword(string username, string password)
        {
            UserEntity user = CrudOperations.GetUserByUserNameAndPassword(username, password);
            return user;
        }
        public bool UsernameAndPasswordMatchFoundInDB(string username, string password)
        {
            bool matchFound = CrudOperations.CheckIfUserExists(username, password);
            return matchFound;
        }
        public UserEntity GetUserEntityById(long id)
        {
            return CrudOperations.GetUserById(id);
        }
        public void DeleteUserEntity(UserEntity user)
        {
            CrudOperations.DeleteUserEntity(user);
        }

        public UserEntity GetUserEntityByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
