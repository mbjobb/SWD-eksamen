using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping_Management_Application.OldStuff
{
    internal class oldDbStuff
    {
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


        //modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
        //modelBuilder.Entity<User>().HasIndex(u => u.Password).IsUnique();
        //modelBuilder.Entity<Order>().HasKey(o => new { o.OrderId, o.CustomerId});
        //modelBuilder.Entity<Order>().HasKey(u => u.CustomerId);
    }
}
