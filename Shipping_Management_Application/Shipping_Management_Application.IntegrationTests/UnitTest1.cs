
using FluentAssertions;
using FluentAssertions.Execution;
using Shipping_Management_Application.BuisnessLogic.AdminFolder;
using Shipping_Management_Application.Data;
using Shipping_Management_Application.Factories.Transport;
using Shipping_Management_Application.OldStuff;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;

namespace Shipping_Management_Application.IntegrationTests
{
    public class Tests
    {

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
        //    Customer minKunde = new("Saro", "Ismailzada", "Lørenveien 35", "Oslo","Løren" ,"0585","Norway", "0047 91285784", "sarosamall@yahoo.com");

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
        [Test]
        public void Deliver_MethodShouldReturn_DeliverByTruck_IfCountryIsEquelToNorway()
        {
            // Arrange
            Truck transport = new();
            string inputCountry = "tyskland";
           
            // Act
            var res = transport.DeliverOrderByCountry(inputCountry);

            // Assert
            res.Should().NotBeNull();
            Assert.IsTrue(res.Equals(inputCountry));
            


        }

        // test for DeliverTo() ----> string Input -->Country 
        [Test]

        public void ShouldDeliverTo_WorksWhenWeSendInAneCountry()
        {
            // Arrange
            Truck transport = new();

            // Act
            string inputCountry = "Norway"; // endret til "Norwa" for å matche kommentaren
            var res = transport.DeliverTo(inputCountry);
            var expectedOutput = $"{inputCountry}";

            // Assert
            res.Should().NotBeNull();
            res.Should().Be(expectedOutput);
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



    }
}