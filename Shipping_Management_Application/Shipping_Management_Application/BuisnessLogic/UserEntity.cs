﻿namespace Shipping_Management_Application.BuisnessLogic
{
    public abstract class UserEntity
    {

        /// <summary>
        /// Base class for all user entities.
        /// This makkes easier to manage all users at the same time and 
        /// creates a baseline for all future user entities.
        /// </summary>
        
        //default constuctor
        protected UserEntity(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        protected UserEntity(string userName, string password, string role) : this(userName, password)
        {
            Role = role;
        }

        //constructor with role, used when making admins


        public long Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string Role { get; set; } = "Customer";//sets default value to "Customer"
    }
}