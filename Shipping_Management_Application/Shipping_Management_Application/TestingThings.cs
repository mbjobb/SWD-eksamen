using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
using System;


namespace Shipping_Management_Application
{
    public static class TestingThings
    {/// <summary>
     /// Used for testing during development
     /// In hindsight, we should probably just have wtritten proper unit tests instead
     /// </summary>
        public static void Testing()
        {
            using DataContext context = new DataContext();
            List<User> users = new()
            {
                new User("derp1", "derp"),
                new User("derp2", "derp"),
                new User("derp3", "derp"),


            };
            User user = new("derp", "derp");
            users.Add(user);
            context.AddRange(users);
            context.SaveChanges();
            
            //Customer customer = new(user.Id, "derp");
            //context.Add(customer);
            context.SaveChanges();
            
            /*@
            OldOrder order = new(customer.CustomerId);
            context.Add(order);

            OldOrder order2 = new(customer.CustomerId);
            context.Add(order2);
            context.SaveChanges();
            Console.WriteLine("derp");
            Console.ReadLine();
            **/
            
        }
    }
}


    //        using (var dataContext = new DataContext())
    //        {
    //            var customers = new List<Customer>
    //            {
    //                new Customer
    //                {
    //                    FirstName = "John",
    //                    LastName = "Doe",
    //                    Address = "123 Main Street",
    //                    City = "Anytown",
    //                    Region = "Someregion",
    //                    PostalCode = "54321",
    //                    Country = "Somecountry",
    //                    Phone = "555-1234",
    //                    Email = "john@example.com"
    //                },
    //                new Customer
    //                {
    //                    FirstName = "Alice",
    //                    LastName = "Smith",
    //                    Address = "456 Oak Avenue",
    //                    City = "Sometown",
    //                    Region = "Anotherregion",
    //                    PostalCode = "12345",
    //                    Country = "Othercountry",
    //                    Phone = "555-5678",
    //                    Email = "alice@example.com"
    //                }
    //            };

    //            try
    //            {
    //                dataContext.AddRange(customers);
    //                Console.WriteLine("Added");
    //                int affectedRows = dataContext.SaveChanges();
    //                Console.WriteLine($"saved {affectedRows} changes");
    //                Console.WriteLine("Saved");

    //                IList<string?> customerNames = dataContext.Users.Select(s => s.FirstName).ToList();

    //                foreach (string customerName in customerNames)
    //                {
    //                    Console.WriteLine(customerName);
    //                }
    //            }
    //            catch (DbUpdateException ex)
    //            {
    //                Console.WriteLine($"Failed to save changes: {ex.InnerException?.Message}");
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.WriteLine($"An error occurred: {ex.Message}");
    //            }
    //        }
    /**  public class Program
  {
      static async Task Main(string[] args)
         {
         // await DataToDb();
          await DataFromDb();
       
          

      }
      //Get Data from Database
      static async Task DataFromDb()
      {
          DatabaseConnection db = new DatabaseConnection();

          using var dbContext = new DatabaseConnection();
          var admins = dbContext.Admins.ToList(); // Henter alle Admins fra databasen

          if (admins.Any())
          {
              Console.WriteLine("Admins hentet fra databasen:");
              foreach (var admin in admins)
              {
                  Console.WriteLine($"ID: {admin.AdminId}, Navn: {admin.UserName}, Passord: {admin.Password}");
              }
          }
          else
          {
              Console.WriteLine("Ingen Admins ble funnet i databasen.");
          }
          Console.ReadLine();
      }
      //push Data to Database
      static async Task DataToDb()
          {
              DatabaseConnection db = new DatabaseConnection();
              var dbName = "sqlitedb1.db";

              if (File.Exists(dbName))
              {
                  File.Delete(dbName);
              }

              await using var dbContext = new DatabaseConnection();
              await dbContext.Database.EnsureCreatedAsync();
              await dbContext.Admins.AddRangeAsync(new Admin[]
              {
              new Admin { UserName = "saro", Password = "1234" },
              new Admin { UserName = "henrik", Password = "123444" },
              });
              await dbContext.SaveChangesAsync();

              // Getting database data
              Console.WriteLine("Getting database data");
              dbContext.Admins?.ToList().ForEach(admin =>
              {
                  Console.WriteLine($"{admin.AdminId} {admin.UserName} {admin.Password}");
              });
          }
         
      }

  }**/
/**
 Admin admin = new("saro", "saro");
 Admin admin1 = new("henrik", "henrik");
 Admin admin2 = new("martin", "martin");
 AdminController adminController = new AdminController();
 List<Admin> admins = adminController.GetAllAdmins();

 admins.Add(admin);
 admins.Add(admin1);
 admins.Add(admin2);

 Console.WriteLine("Admins er opprettet og lagt til i listen.");

 var oldAdminUserName = admin.UserName;
 var updatedAdmin = adminController.UpdateAdminName(admins, oldAdminUserName, "Ahmad");
 if (updatedAdmin != null)
 {
     Console.WriteLine($"You updated {oldAdminUserName} to {updatedAdmin.UserName}");
 }

 foreach (Admin item in admins)
 {
     if (item != null)
     {
         Console.WriteLine(item);
     }
     else
     {
         Console.WriteLine("Admin-objektet er null.");
     }
 }

 if (admins.Count == 0)
 {
     Console.WriteLine("Ingen admin-objekter i listen.");
 }**/


    