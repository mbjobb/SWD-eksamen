using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shipping_Management_Application.BuisnessLogic.Controllers;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Data.Entities;
using System.Data.Common;

namespace Shipping_Management_Application.IntegrationTests
{

    public class DbConnectionTest
    {
        private string? _dbConnectionString;

        [SetUp]
        public void Setup()
        {
            _dbConnectionString = "Data Source=data.db";
        }

        [Test]
        public void ConnectionToDatabase_ShouldConnectToDatabase()
        {
            SqliteConnection sqliteConnection = new("Data Source=data.db");
            try
            {
                sqliteConnection.Open();
                Console.WriteLine("Database connected!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to connect");
                Console.WriteLine(e.Message);

            }
        }
    }

    public class UserTest
    {
        private DataContext? _context;
        private AdminController _adminController;
        public static IUserController userController = new UserController();

        [SetUp]
        public void Setup()
        {
            _context = new();
            _adminController = new AdminController();
        }

        [Test]
        public void CreateAndAddUserToDb_ShouldCreateAndAddUserToDb()
        {
            User user = new("User", "User123");

            _context?.Users.Add(user);
            _context?.SaveChanges();

            try
            {
                User findUser = _context?.Users.FirstOrDefault(u => u.UserName == user.UserName)!;
                Assert.IsNotNull(findUser);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to add user " + e.Message);
            }
        }

        [Test]
        public void AdminGetsAllUsers_AdminShouldGetAllUsers()
        {

            User user = new("User1", "password123");
            CrudOperations.CreateUser(user);

            IEnumerable<UserEntity> userEntities = _adminController.GetAllUserEntities();

            Assert.IsNotNull(userEntities);
            Console.WriteLine(userEntities);
        }

        [Test]
        public void AddingDuplicatedUser_ShouldFail()
        {
            User user = new("User1", "password123");
            User user1 = new("User1", "password123");
            CrudOperations.CreateUser(user);

            Assert.Throws<DbUpdateException>(() => CrudOperations.CreateUser(user1));
        }

        [Test]
        public void CreatingDuplicateUser_ShouldFailAndThrowException()
        {
            Exception? exception = null;
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

    public class OrderTest
    {

        private OrderController _orderController;
        private DataContext _dataContext;

        [SetUp]
        public void Setup()
        {
            _dataContext = new DataContext();
            _orderController = new OrderController();
        }
        //TODO: make proper orders, dumbass
        [Test]
        public void CreatingOrder_ShouldCreateOrder()
        {
            User user = new("User1", "password123");
            CrudOperations.CreateUser(user);

            Customer customer = new(user.Id, "Customer1", "customer1@gmail.com", "customer1", "1111");
            CrudOperations.CreateCustomer(customer);

            Order order = new(customer.Id, "ehgrgbkegrbj 12", 27);
            CrudOperations.SaveOrder(order);

            Assert.IsNotNull(order);
        }

        [Test]
        public void ChangeOrderStatus_ShouldChangeOrderStatus()
        {
            User user = new("User2", "password123");
            CrudOperations.CreateUser(user);

            Customer customer = new(user.Id, "Customer2", "customer@gmail.com", "customer2", "2222");
            CrudOperations.CreateCustomer(customer);

            Order order = new(customer.Id, "ehgrgbkegrbj 12", 27);
            CrudOperations.SaveOrder(order);

            string shippingStatus = "Shipping";

            CrudOperations.UpdateOrderStatus(order, shippingStatus);


            var updatedOrder = _dataContext.Orders.Find(order.Id);
            Assert.IsNotNull(updatedOrder);
            Assert.That(updatedOrder?.OrderStatus, Is.EqualTo("Shipping"));
        }

        [Test]
        //Test to get all orders by user id for a specific user
        public void GetOrdersByUserId_ShouldGetOrdersByUserId()
        {
            //Arrange
            User user = new("User3", "password123");
            Customer customer = new(user.Id, "Customer3", "customer@gmail.com", "customer3", "111");
            Order order = new(customer.Id, "ehgrgbkegrbj 12", 27);
            //Act
            try
            {
                CrudOperations.CreateUser(user);
                CrudOperations.CreateCustomer(customer);
                CrudOperations.SaveOrder(order);
                IEnumerable<Order> orders = CrudOperations.GetOrdersByUserId(user.Id);
                //Assert
                Assert.IsNotNull(orders);
                Assert.That(orders, Is.Not.Empty);
                Assert.True(orders.Count() > 0 && orders.Count() < 2 && customer.Id == order.CustomerId);
                Console.WriteLine($"Orders by user id: {customer.Id} \n");
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Failed to get orders by user id");
            }
        }
        // we need to write more tests!
        //admin , user and order with controller 
        [Test]
        public void CreateAdmin_ShouldCreateAdmin()
        {
            //Arrange
            Admin admin = new("Admin", "Admin123");
            //Act
            try
            {
                CrudOperations.CreateAdmin(admin.UserName, admin.Password);
                //Assert
                Assert.IsNotNull(admin);
                Assert.That(admin.UserName, Is.EqualTo("Admin"));
                Assert.That(admin.Password, Is.EqualTo("Admin123"));
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Failed to create admin");
            }
        }

    }
}

