using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shipping_Management_Application;
using Shipping_Management_Application.Factories.Logistics;
using Shipping_Management_Application.Factories.Transport;

namespace Shipping_Management_Application.UnitTests
{
    public class LogisticsTest
    {
        [Test]
        public void RoadLogistics_Should_Create_Truck()
        {
            //Arrange
            
            //Act
            var actual = new RoadLogistics().CreateTransport;
            //Assert
            Assert.IsNotNull(actual);
        }
    }
}
