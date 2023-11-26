﻿using Shipping_Management_Application.Data.Entities;

namespace Shipping_Management_Application.BuisnessLogic.Controllers
{
    public interface IUserController
    {
        /// <see cref="UserController"/>
        Customer CreateCustomer(long id, string? name, string? email, string? address, string? postCode);
        UserEntity CreateUser(string username, string password);
        UserEntity GetUserEntityByUsernameAndPassword(string username, string password);
        bool UsernameAndPasswordMatchFoundInDB(string username, string password);
        public UserEntity GetUserEntityByIdOrUsername(long id = 0, string? username = null);
        public void DeleteUserEntity(UserEntity user);

    }
}