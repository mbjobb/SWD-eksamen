
using FluentAssertions;
using FluentAssertions.Execution;

using Shipping_Management_Application.Data;
using Shipping_Management_Application.Factories.Transport;
using Shipping_Management_Application.OldStuff;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using System.Security.AccessControl;
using System.Threading.Channels;
using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.UI;
using Shipping_Management_Application.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Shipping_Management_Application.IntegrationTests{
    
    public class DbConnectionTest{
        private string? _dbConnectionString;

        [SetUp]
        public void Setup(){
            _dbConnectionString = "Data Source=data.db";
        }
        
        [Test]
        public void ConnectionToDatabase_ShouldConnectToDatabase(){ 
            SqliteConnection sqliteConnection = new("Data Source=data.db"); 
            try{ 
                sqliteConnection.Open();
                Console.WriteLine("Database connected!");
                Assert.IsTrue(true); 
            }
            catch (Exception e){ 
                Console.WriteLine("Failed to connect"); 
                Assert.IsTrue(false);
            }
        }
    }

    public class UserTest{
        private DataContext? _context;
        private AdminController _adminController;
        public static IUserController userController = new UserController();
        
        [SetUp]
        public void Setup(){
            _context = new();
            _adminController = new AdminController();
    }

        [Test]
        public void CreateAndAddUserToDb_ShouldCreateAndAddUserToDb(){
            User user = new("User", "User123");

            _context?.Users.Add(user);
            _context?.SaveChanges();

            try{
                User findUser = _context?.Users.FirstOrDefault(u => u.UserName == user.UserName)!;
                Assert.IsNotNull(findUser);
            }
            catch (Exception e){
                Console.WriteLine("Failed to add user " + e.Message);
            }
        }
        
        [Test]
        public void AdminGetsAllUsers_AdminShouldGetAllUsers(){

            User user = new User("User1", "password123");
            CrudOperations.CreateUser(user);
            
            IEnumerable<UserEntity> userEntities = _adminController.GetAllUserEntities();
            
            Assert.IsNotNull(userEntities);
            Console.WriteLine(userEntities);
        }
        
        [Test]
        public void AddingDuplicatedUser_ShouldFail(){
            User user = new User("User1", "password123");
            User user1 = new User("User1", "password123"); 
            CrudOperations.CreateUser(user);
            
            Assert.Throws<DbUpdateException>(() => CrudOperations.CreateUser(user1));
        }
        
        [Test]
        public void CreatingDuplicateUser_ShouldFailAndThrowException()
        {
            Exception exception = null;
            try
            {
                string username = "username";
                string password = "password";
                var user1 = userController.CreateUser(username, password);
                var user2 = userController.CreateUser(username, password);


            }
            catch (Exception e)
            {

                exception = e;
            }
            finally
            {
                Assert.IsNotNull(exception);
                Assert.IsInstanceOf<DbUpdateException>(exception);
            }
        }
    }

    public class OrderTest{
        
        private OrderController _orderController;
        private DataContext _dataContext;
        
        [SetUp]
        public void Setup(){
            _dataContext = new DataContext();
            _orderController = new OrderController();
        }
        
        [Test]
        public void CreatingOrder_ShouldCreateOrder(){
            User user = new("User1", "password123");
            CrudOperations.CreateUser(user);
            
            Customer customer = new(user.Id, "Customer1", "customer1@gmail.com", "customer1", "1111");
            CrudOperations.CreateCustomer(customer);
            
            Order order = new(customer.CustomerId, "Urtegata 17");
            CrudOperations.SaveOrder(order);
            
            Assert.IsNotNull(order);
        }
        
        [Test]
        public void ChangeOrderStatus_ShouldChangeOrderStatus(){
            User user = new("User2", "password123");
            CrudOperations.CreateUser(user);
            
            Customer customer = new(user.Id, "Customer2", "customer@gmail.com", "customer2", "2222");
            CrudOperations.CreateCustomer(customer);

            Order order = new(customer.CustomerId, "Urtegata 17");
            CrudOperations.SaveOrder(order);
            
            string shippingStatus = "Shipping";

            CrudOperations.UpdateOrderStatus(order, shippingStatus);
            
            
            var updatedOrder = _dataContext.Orders.Find(order.OrderId);
            Assert.IsNotNull(updatedOrder);
            Assert.That(updatedOrder?.OrderStatus, Is.EqualTo("Shipping"));
        }
    }
}

      
    public class Tests{

        //[SetUp]
        //public void Setup()
        //{
        //}
        //public Admin Admin = new("derp", "derp123");

        //public AdminController adminController = new();

        //[Test]
        //public void ShoudAdminsListSizeEquels2()
        //{

        //    // Arrange   We Get our Variables
        //    List<Admin> admins = new();
        //    //Act
        //    admins.Add(new Admin("saro", "samall"));
        //    admins.Add(new Admin("henrik", "henrik"));
        //    //Assert
        //    Assert.IsTrue(admins.Count == 2);
        //}

        //[Test]
        //public void IsAdminInAdminList()
        //{
        //    // Arrange 
        //    List<Admin> admins = new();
        //    Admin admin = new("derp", "derp123");

        //    // Act
        //    admins.Add(new Admin("saro", "samall"));
        //    admins.Add(new Admin("henrik", "henrik"));

        //    var res = admins[0].UserName.Equals("saro");
        //    //var createNewAdminResult = adminController.CreateAdmin("martin", "martin");


        //    // Assert
        //    Assert.IsTrue(res);
        //    //Assert.That(createNewAdminResult, Is.EqualTo("martin"));

        //}

        //[Test]
        //public void CkeckOutThisUserNameIsAdmin()
        //{
        //    // Arrange 
        //    List<Admin> admins = new();
        //    Admin admin = new("derp", "derp123");

        //    // Act
        //    admins.Add(new Admin("saro", "samall"));
        //    admins.Add(new Admin("henrik", "henrik"));

        //    // Assert
        //    //Assert.IsTrue(adminController.IsAdmin(admins, "saro"));
        //    //Assert.IsFalse(adminController.IsAdmin(admins, "ahmaddd"));



        //}

        //[Test]   // I use fluentassertions -> C# library for test assertions
        //public void ShouldAdminNameNotBeNull()
        //{
        //    // Arrange 
        //    List<Admin> admins = new();
        //    Admin admin = new("derp", "derp123");

        //    // Act
        //    admins.Add(new Admin("saro", "samall"));
        //    admins.Add(new Admin("henrik", "henrik"));
        //    var firstAdmin = admins[0];


        //    // Assert
        //    firstAdmin.Should().NotBeNull();
        //    firstAdmin.UserName.Should().Be("saro");


        //}
        //[Test]
        //public void DelateAdmin()
        //{
        //    // Arrange 
        //    List<Admin> admins = new();
        //    Admin admin = new("derp", "derp123");

        //    // Act
        //    admins.Add(new Admin("saro", "samall"));
        //    admins.Add(new Admin("henrik", "henrik"));
        //    // var delatedAdmin = adminController.RemoveAdmin(admins, "saro");
        //    var adminsSize = admins.Count();


        //    // Assert
        //    //delatedAdmin.Should().NotBeNull();
        //    //delatedAdmin.UserName.Should().Be("saro");
        //    adminsSize.Should().Be(1);


        //}

        //[Test]
        //public void ShouldDefaultValueForUserNameBeAdminAndPasswordBeAdmin()
        //{
        //    // Arrange 

        //    Admin admin = new("derp", "derp123");

        //    // Act
        //    var defaultUserName = admin.UserName;
        //    var defaultPassword = admin.Password;

        //    //Assert
        //    defaultUserName.Should().Be("admin");
        //    defaultPassword.Should().Be("admin");

        //}
        //[Test]
        //public void ShouldUpdateAdminNameByUserName()
        //{
        //    // Arrange 
        //    List<Admin> admins = new();
        //    Admin? admin = new("derp", "derp123");

        //    // Act
        //    admins.Add(new Admin("saro", "samall"));
        //    admins.Add(new Admin("henrik", "henrik"));
        //    var adminToUpdate = admins[0].UserName;
        //    Console.WriteLine($" Old AdminUserName was {adminToUpdate}");
        //    //var updatedAdmin = adminController.UpdateAdminName(admins, adminToUpdate, "MARTIN");

        //    //    Console.WriteLine($"Updated Admin: {updatedAdmin}");

        //    //    // Assert
        //    //    updatedAdmin?.UserName.Should().Be("martin");
        //    //    //updatedAdmin?.UserName.Should().BeUpperCased();
        //    //    updatedAdmin?.UserName.Should().BeLowerCased();
        //    //    updatedAdmin?.Password.Should().Be("samall");
        //    //    updatedAdmin?.UserName.Should().StartWith("mar");
        //    //




        //}
        ////Method to test PrintOrder is working
        //[Test]
        //public void ShouldPrintOrderMethodWork()
        //{
        //    // Arrange 
        //    Customer minKunde = new("Saro", "Ismailzada", "L�renveien 35", "Oslo","L�ren" ,"0585","Norway", "0047 91285784", "sarosamall@yahoo.com");

        //    // Act
        //    Order minOrdre = new(1,"Urtegata 9", minKunde.CustomerId = 1);
        //    minOrdre.Customer = minKunde;
        //    minOrdre.PrintOrder();

        //    // Assert
        //    minOrdre.Should().NotBeNull();
        //    minKunde.Should().NotBeNull();
        //    minKunde.Should().Be(minKunde.CustomerId = 1);

        //}
        
        [Test]
        public void ProccessOrder_WithAddressAndAddressNumber_ReturnsCorrectPrice(){
            
            // Arrange
            Order order = new Order(2){
                ShippingAddress = "Urtegata 9"
            };
            int expectedPriceToDeliver = 900;
            
            // Act
            OrderControllerUI.ProcessOrder(order);
            
            //Assert
            Assert.That(order.Price, Is.EqualTo(expectedPriceToDeliver));
        }

        [Test]
        //Test to check out serialnumber is not duplicate
        public void GenereateSerialNumbeShoudBeUniqe()
        {
            // Arrange
            OldOrder order = new OldOrder(1, "Urtegata 9", 1);
            var generatedSerialNumbers = new HashSet<string>();

            // Act
            for (int i = 0; i < 10; i++)
            {
                string newstring = order.GenerateSerialNumberToOrder(4);
                if (generatedSerialNumbers.Add(newstring))
                {
                    Console.WriteLine("NOT Duplicate serial number found");
                }
    
                else
                {
                    Console.WriteLine("Duplicate serial number found");
                }
            }

            // Assert
           //generatedSerialNumbers.Count().Should().Be(9999);
           
        }

        //[Test]
        ////Test to check out serialnumber is not duplicate
        //public void GenerateUniqueSerial_ShouldCreateUniqueSerialNumbers()
        //{
        //    Order order = new(1, "Urtegata 9", 1);
        //    var generatedSerialNumbers = new HashSet<string>();
        //    int totalSerialNumbersToGenerate = 1000;

        //    for (int i = 0; i < totalSerialNumbersToGenerate; i++)
        //    {
        //        string serialNumber = order.GenerateSerialNumberToOrder(3);

        //        // Assert that the serial number is unique
        //        Assert.IsTrue(generatedSerialNumbers.Add(serialNumber), $"Duplicate serial number found: {serialNumber}");


        //    }
        //    Console.Write("Passed test");
        //}

        // Test Method DeliverOrderByCountry()

        // test for DeliverTo() ----> string Input -->Country 
        
            //    // Arrange
            //    Truck transport = new();

            //    // Act
            //    string _object = "Norwa";
            //    var res = transport.DeliverTo(_object);
            //    var OutPut = $"{_object}";

            //    // Assert
            //    res.Should().NotBeNull();
            //    res.Should().Be(OutPut);
        }



    