using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;

namespace Shipping_Management_Application.OldStuff
{
    public class CustomerDataContext // DbContext
    {
        ////Makes the db aware of the base class
        //public DbSet<UserEntity> UserEntities => Set<UserEntity>();
        ////tabel for users
        //public DbSet<User> Users => Set<User>();
        ////table for Order
        //public DbSet<Order> Orders => Set<Order>();

        ////Override OnConfiguring from DbContextClass to get optionsBuilder object to create connection_string
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=Customerdata.db");

        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserEntity>().HasKey(u => u.Id);
        //    //modelBuilder.Entity<UserEntity>().;
        //    //modelBuilder.Entity<User>().HasMany<Order>(o)
        //    modelBuilder.Entity<Order>().HasKey(o => o.OrderId);


        //}

    }
}
