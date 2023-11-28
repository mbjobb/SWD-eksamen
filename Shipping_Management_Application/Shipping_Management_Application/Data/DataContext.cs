
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shipping_Management_Application.BuisnessLogic;
using Shipping_Management_Application.BuisnessLogic.User;
using Shipping_Management_Application.ViewPanel;

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
        //tabel for price module by distens
        public DbSet<PricingModule> PricingModules => Set<PricingModule>();



        //Override OnConfiguring from DbContextClass to get optionsBuilder object to create connection_string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=data.db");

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<UserEntity>()
        //        .HasIndex(u => u.UserName)
        //        .IsUnique();



        //    //Defines relationship between user and customer
        //    modelBuilder.Entity<Customer>().HasOne(c => c.User).WithOne(u => u.Customer).HasForeignKey<Customer>(c => c.CustomerId);

        //    //Defines relationship between customer and order
        //    modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders)
        //        .HasPrincipalKey(c => c.CustomerId);
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

       
        //}
        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(u => u.Id);
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId); // Assuming CustomerId is the primary key for Customer
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId); // Assuming OrderId is the primary key for Order

            modelBuilder.Entity<User>()
                .HasOne(u => u.Customer)
                .WithOne(c => c.User)
                .HasForeignKey<Customer>(c => c.CustomerId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders) // Assuming Orders is a navigation property in Customer pointing to a collection of orders
                .HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<PricingModule>().HasKey(p => p.Id);
                
            //modelBuilder.Entity<UserEntity>().HasKey(u => u.Id);
            //modelBuilder.Entity<Order>().HasKey(u => u.CustomerId);
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.Customer)
            //    .WithOne(c => c.User)
            //    .HasForeignKey<Customer>(c => c.CustomerId);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserEntity>().HasKey(u => u.Id);
        //    modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
        //    modelBuilder.Entity<Order>().HasKey(o => o.OrderId);

        //    modelBuilder.Entity<Order>()
        //        .HasOne(o => o.Customer)
        //        .WithMany(c => c.Orders)
        //        .HasForeignKey(o => o.CustomerId);
        //}





        //modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
        //modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany().HasForeignKey(o => o.CustomerId);

        //modelBuilder.Entity<Customer>()
        //    .HasOne(c => c.User)
        //    .WithOne(c => c.Customer)
        //    .HasForeignKey<User>(u => u.Id);

        //.HasOne(c => c.User)
        //.WithOne(u => u.Customer)
        //.HasForeignKey<User>(c => c.;






        //}

    }
    }//using Microsoft.EntityFrameworkCore;
//using Shipping_Management_Application.BuisnessLogic;
//using Shipping_Management_Application.BuisnessLogic.User;

//namespace Shipping_Management_Application.Data
//{
//    public class DataContext : DbContext
//    {
//        // Makes the db aware of the base class
//        public DbSet<UserEntity> UserEntities => Set<UserEntity>();
//        // Table for Admin
//        public DbSet<Admin> Admins => Set<Admin>();
//        // Table for users
//        public DbSet<User> Users => Set<User>();
//        // Table for orders
//        public DbSet<Order> Orders => Set<Order>();
//        public DbSet<Customer> Customers => Set<Customer>();

//        // Override OnConfiguring from DbContextClass to get optionsBuilder object to create connection_string
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlite(@"Data Source=data.db");
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<UserEntity>().HasKey(u => u.UserId);
//            modelBuilder.Entity<Order>().HasKey(o => o.CustomerId);

//            modelBuilder.Entity<User>().ToTable("User");
//            modelBuilder.Entity<Customer>().ToTable("Customer");
//            modelBuilder.Entity<Admin>().ToTable("Admin");
//            modelBuilder.Entity<Order>().ToTable("Order");

//            modelBuilder.Entity<User>()
//                        .HasOne(u => u.Customer)
//                        .WithOne(c => c.User)
//                        .HasForeignKey<Customer>(c => c.UserId);

//            modelBuilder.Entity<Order>()
//                .HasOne(o => o.Customer)
//                .WithMany(c => c.Orders)
//                .HasForeignKey(o => o.CustomerId);
//        }
//    }
//}





////using Microsoft.EntityFrameworkCore;
////using Shipping_Management_Application.BuisnessLogic;
////using Shipping_Management_Application.BuisnessLogic.User;

////namespace Shipping_Management_Application.Data
////{
////    public class DataContext : DbContext
////    {
////        //Makes the db aware of the base class
////        public DbSet<UserEntity> UserEntities => Set<UserEntity>();
////        //tabel for Admin
////        public DbSet<Admin> Admins => Set<Admin>();
////        //tabel for users
////        public DbSet<User> Users => Set<User>();
////        // tabel for orders
////        public DbSet<Order> Orders => Set<Order>();
////        public DbSet<Customer> Customers => Set<Customer>();



////        //Override OnConfiguring from DbContextClass to get optionsBuilder object to create connection_string
////        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
////        {
////            optionsBuilder.UseSqlite(@"Data Source=data.db");

////        }

////        protected override void OnModelCreating(ModelBuilder modelBuilder)
////        {

////            modelBuilder.Entity<UserEntity>().HasKey(u => u.Id);
////            modelBuilder.Entity<Order>().HasKey(u => u.CustomerId);
////            modelBuilder.Entity<User>()
////                .HasOne(u => u.Customer)
////                .WithOne(c => c.User)
////                .HasForeignKey<Customer>(c => c.CustomerId);



////            //modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
////            //modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany().HasForeignKey(o => o.CustomerId);

////            //modelBuilder.Entity<Customer>()
////            //    .HasOne(c => c.User)
////            //    .WithOne(c => c.Customer)
////            //    .HasForeignKey<User>(u => u.Id);

////            //.HasOne(c => c.User)
////            //.WithOne(u => u.Customer)
////            //.HasForeignKey<User>(c => c.;






////        }

////    }
////}
