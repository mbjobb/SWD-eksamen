using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;

namespace Shipping_Management_Application.Data
{
    public class DataContext : DbContext
    {
        //Makes the db aware of the base class
        public DbSet<UserEntity> UserEntities => Set<UserEntity>();
        //tabel for Admin
        public DbSet<Admin> Admins => Set<Admin>();
        //tabel for users
        public DbSet<User> Users => Set<User>();
        // tabel for orders
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
            
            

            modelBuilder.Entity<Customer>().HasOne(c => c.User).WithOne(u => u.Customer).HasForeignKey<Customer>(c => c.CustomerId);

            modelBuilder.Entity<Order>().HasOne(o =>  o.Customer).WithMany(c => c.Orders)
                //.HasForeignKey(c => c.OrderId)
                .HasPrincipalKey(c => c.CustomerId);






        }

    }
}