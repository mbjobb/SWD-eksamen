using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.Data
{
    public class DataContext:DbContext
    {
        //tabel for Admin
        public DbSet<Admin> Admins { get; set; }
        //tabel for Customer
        public DbSet<Customer> Customers { get; set; }
        //table for Order
        public DbSet<Order> Orders { get; set; }

        //Override OnConfiguring from DbContextClass to get optionsBuilder object to create connection_string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=data.db");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasKey(a => a.AdminId);
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId)
                .HasOne(o => o.Customer)  
                .WithMany(c => c.Orders)  
                .HasForeignKey(o => o.CustomerId);
            // Add additional configurations for relationships or other constraints

            base.OnModelCreating(modelBuilder);
        }

    }
}
