﻿using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;

namespace Shipping_Management_Application.Data
{
    public class DataContext : DbContext
    {

        public DbSet<UserEntity> UserEntities => Set<UserEntity>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Customer> Customers => Set<Customer>();


        
        //Override OnConfiguring from DbContextClass to get optionsBuilder object to create connection_string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=data.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserEntity>().HasKey(u => u.Id);

            //Defines relationship between user and customer
            modelBuilder.Entity<Customer>().HasOne(c => c.User).WithOne(u => u.Customer).HasForeignKey<Customer>(c => c.CustomerId);

            //Defines relationship between customer and order
            modelBuilder.Entity<Order>().HasOne(o =>  o.Customer).WithMany(c => c.Orders)
                //.HasForeignKey(c => c.OrderId)
                .HasPrincipalKey(c => c.CustomerId);






        }

    }
}