using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.UserFolder;
using System.Reflection;

namespace Shipping_Management_Application.Data
{
    public class DataContext : DbContext
    {

        public DbSet<User> users => Set<User>();
        public DbSet<UserEntity> userEntities => Set<UserEntity>();
        public DbSet<Order> orders => Set<Order>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = data.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                MethodInfo? method = entityType.ClrType.GetMethod("OnModelCreating",
                BindingFlags.Static | BindingFlags.NonPublic);
                if (method is not null)
                {
                    method.Invoke(null, new object[] { modelBuilder });
                }
            }
        }
    }
}