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
        //table for Order
        //public DbSet<Order> Orders => Set<Order>();

        //Override OnConfiguring from DbContextClass to get optionsBuilder object to create connection_string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=data.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(u => u.Id);
        }

    }
}
//foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
//{
//    MethodInfo? method = entityType.ClrType.GetMethod("OnModelCreating",
//    BindingFlags.Static | BindingFlags.NonPublic);
//    if (method is not null)
//    {
//        method.Invoke(null, new object[] { modelBuilder });
//    }
//}

//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{
//    modelBuilder.Entity<Admin>().HasKey(a => a.AdminId);
//    modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
//    modelBuilder.Entity<Order>()
//        .HasKey(o => o.OrderId)
//        .HasOne(o => o.Customer)  
//        .WithMany(c => c.Orders)  
//        .HasForeignKey(o => o.CustomerId);
//    // Add additional configurations for relationships or other constraints

//    base.OnModelCreating(modelBuilder);
//}