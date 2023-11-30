using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.Data.Entities;


namespace Shipping_Management_Application.Data
{
    /// <summary>
    /// Class that inherits from DbContext to create a database context object.
    /// and a DbSet for each entity class.
    ///  </summary>
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

            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.UserName)
                .IsUnique();



            //Defines relationship between user and customer
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithOne(u => u.Customer)
                .HasForeignKey<Customer>(c => c.Id);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasPrincipalKey(c => c.Id);

            //Defines relationship between customer and order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasPrincipalKey(c => c.Id);






        }

    }
}