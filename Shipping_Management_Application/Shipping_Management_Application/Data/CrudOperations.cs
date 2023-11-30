﻿using Microsoft.EntityFrameworkCore.Diagnostics;
using Shipping_Management_Application.Data.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Shipping_Management_Application.Data{
    /// <summary>
    /// Class with the methods that are used to create, read, update and delete data from the database.
    /// </summary>
    
    public static class CrudOperations
    {
        public static UserEntity? GetUserByUserNameAndPassword(string? userName, string? password){

            using DataContext context = new DataContext();
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password)){
                throw new ArgumentNullException("userName");
            }

            UserEntity? user = context.UserEntities.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            
            return user;
        }
       

        public static bool IsUserEntitiesTableEmpty()
        {
            using DataContext context = new DataContext();
            if (context.UserEntities.Count() == 0)
            {
                return true;
            } else return false;
        }

        public static Admin CreateFirstAdmin(){

            using DataContext context = new();

            Admin admin = new("Admin", "changeme");
            context.Add(admin);
            context.SaveChanges();
            return admin;
        }

        public static Admin CreateAdmin(string username, string password){

            using DataContext context = new();

            Admin admin = new(username, password);
            context.Add(admin);
            context.SaveChanges();
            return admin;
        }

        public static UserEntity GetUserEntityById(long id){
            using DataContext context = new DataContext();
            
            UserEntity? user = context.UserEntities.FirstOrDefault(u => (u.Id == id));
            return user ?? throw new Exception();
            
        }

        public static UserEntity GetUserEntityByUsername(string username){
            using DataContext context = new DataContext();
            
            UserEntity? user = context.UserEntities.FirstOrDefault(u => (u.UserName == username));
            return user ?? throw new Exception();
            
        }

        public static Customer? GetCustomerById(long id){
            using DataContext context = new DataContext();
            
            Customer? customer = context.Customers.FirstOrDefault(c => c.Id == id);
            return customer?? null;
            
        }

        public static bool CheckIfUserExists(string? username, string? password){
            DataContext context = new();
            return context.UserEntities.Any(u => u.UserName == username && u.Password == password);
        }

        public static IEnumerable<Order> GetOrdersByUserId(long id) 
        {
            DataContext context = new();
            IEnumerable<Order> OrderQuery = context.Orders
                .Where(o => o.CustomerId == id);
            return OrderQuery;
        }
        public static Order SaveOrder(Order order)
        {
            using DataContext context = new DataContext();
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }
        public static Order UpdateOrderStatus(Order order, string status){
            using DataContext context = new DataContext();
            order.OrderStatus = status;
            context.Orders.Update(order);
            context.SaveChanges();
            return order;
        }

        public static Customer UdateCustomer(Customer customer)
        {
            using DataContext context = new DataContext();
            context.Customers.Update(customer);
            context.SaveChanges();
            return context.Customers.First(c => c.Id == customer.Id);

        }
        public static void CreateCustomer(Customer customer)
        {
            using DataContext context = new DataContext();
            context.Customers.Add(customer);
            context.SaveChanges();
        }
        public static void CreateUser(UserEntity user){
            using DataContext context = new DataContext();
            context.UserEntities.Add(user);
            context.SaveChanges();
        }
        
        public static IEnumerable<UserEntity> GetAllUserEntities()
        {
            using DataContext context = new DataContext();
            IEnumerable<UserEntity> userEntities = context.UserEntities.ToList();
            return userEntities;
        }

        public static IEnumerable<Order> GetAllOrders()
        {
            using DataContext context = new DataContext();
            IEnumerable<Order> orders = context.Orders.ToList();
            return orders;
        }
        public static void DeleteCustomer(Customer customer) { throw new NotImplementedException(); }
        /// <summary>
        /// refactoring end
        /// here the database update happens, in the data layer as it should be
        /// </summary>
        /// <param name="user"></param>
        public static void DeleteUserEntity(UserEntity user) 
        {
            using DataContext context = new DataContext();
            context.UserEntities.Remove(user);
            context.SaveChanges();
        }
        public static void UpdateUserentity(UserEntity user)
        {
            using DataContext context = new DataContext();
            context.UserEntities.Update(user);
        }

    }
}
