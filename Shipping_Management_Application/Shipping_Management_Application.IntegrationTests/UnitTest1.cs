
using FluentAssertions;
using Shipping_Management_Application.BuisnessLogic.AdminFolder;

namespace Shipping_Management_Application.IntegrationTests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }
        public Admin Admin = new("derp", "derp123");

        public AdminController adminController = new();

        [Test]
        public void ShoudAdminsListSizeEquels2()
        {

            // Arrange   We Get our Variables
            List<Admin> admins = new();
            //Act
            admins.Add(new Admin("saro", "samall"));
            admins.Add(new Admin("henrik", "henrik"));
            //Assert
            Assert.IsTrue(admins.Count == 2);
        }

        [Test]
        public void IsAdminInAdminList()
        {
            // Arrange 
            List<Admin> admins = new();
            Admin admin = new("derp", "derp123");

            // Act
            admins.Add(new Admin("saro", "samall"));
            admins.Add(new Admin("henrik", "henrik"));

            var res = admins[0].UserName.Equals("saro");
            var createNewAdminResult = adminController.CreateAdmin("martin", "martin");


            // Assert
            Assert.IsTrue(res);
            Assert.That(createNewAdminResult, Is.EqualTo("martin"));

        }

        [Test]
        public void CkeckOutThisUserNameIsAdmin()
        {
            // Arrange 
            List<Admin> admins = new();
            Admin admin = new("derp", "derp123");

            // Act
            admins.Add(new Admin("saro", "samall"));
            admins.Add(new Admin("henrik", "henrik"));

            // Assert
            Assert.IsTrue(adminController.IsAdmin(admins, "saro"));
            Assert.IsFalse(adminController.IsAdmin(admins, "ahmaddd"));



        }

        [Test]   // I use fluentassertions -> C# library for test assertions
        public void ShouldAdminNameNotBeNull()
        {
            // Arrange 
            List<Admin> admins = new();
            Admin admin = new("derp", "derp123");

            // Act
            admins.Add(new Admin("saro", "samall"));
            admins.Add(new Admin("henrik", "henrik"));
            var firstAdmin = admins[0];


            // Assert
            firstAdmin.Should().NotBeNull();
            firstAdmin.UserName.Should().Be("saro");


        }
        [Test]
        public void DelateAdmin()
        {
            // Arrange 
            List<Admin> admins = new();
            Admin admin = new("derp", "derp123");

            // Act
            admins.Add(new Admin("saro", "samall"));
            admins.Add(new Admin("henrik", "henrik"));
            var delatedAdmin = adminController.RemoveAdmin(admins, "saro");
            var adminsSize = admins.Count();


            // Assert
            delatedAdmin.Should().NotBeNull();
            delatedAdmin.UserName.Should().Be("saro");
            adminsSize.Should().Be(1);


        }

        [Test]
        public void ShouldDefaultValueForUserNameBeAdminAndPasswordBeAdmin()
        {
            // Arrange 

            Admin admin = new("derp", "derp123");

            // Act
            var defaultUserName = admin.UserName;
            var defaultPassword = admin.Password;

            //Assert
            defaultUserName.Should().Be("admin");
            defaultPassword.Should().Be("admin");

        }
        [Test]
        public void ShouldUpdateAdminNameByUserName()
        {
            // Arrange 
            List<Admin> admins = new();
            Admin? admin = new("derp", "derp123");

            // Act
            admins.Add(new Admin("saro", "samall"));
            admins.Add(new Admin("henrik", "henrik"));
            var adminToUpdate = admins[0].UserName;
            Console.WriteLine($" Old AdminUserName was {adminToUpdate}");
            var updatedAdmin = adminController.UpdateAdminName(admins, adminToUpdate, "MARTIN");

            Console.WriteLine($"Updated Admin: {updatedAdmin}");

            // Assert
            updatedAdmin?.UserName.Should().Be("martin");
            //updatedAdmin?.UserName.Should().BeUpperCased();
            updatedAdmin?.UserName.Should().BeLowerCased();
            updatedAdmin?.Password.Should().Be("samall");
            updatedAdmin?.UserName.Should().StartWith("mar");
        }




    }


}