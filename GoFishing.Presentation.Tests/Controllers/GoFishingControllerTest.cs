using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using GoFishing.Application.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Castle.Core.Logging;
using GoFishing.Presentation;
using GoFishing.Presentation.Controllers;
using GoFishing.Domain.Models;

namespace GoFishing.Presentation.Tests.Controllers
{
    
    [TestClass]
    public class GoFishingControllerTest
    {
        
        private readonly GoFishingAPIController _goFishingApiController;
        private readonly Mock<IFishingService> _fishingServiceMock;
        private readonly Mock<ILogger> _loggerMock;

        public GoFishingControllerTest()
        {
            _fishingServiceMock = new Mock<IFishingService>();
            _loggerMock = new Mock<ILogger>();
            _goFishingApiController = new GoFishingAPIController(_fishingServiceMock.Object, _loggerMock.Object);
        }
        
        [TestMethod]
        public void Can_Get_All_Trips()
        {
            _fishingServiceMock.Setup(f => f.GetTrips()).Returns(SetupTrips());

            var result = _goFishingApiController.GetListAllTrips();

            Assert.AreEqual("abcd", result[0].BoatName);
            Assert.AreEqual(new DateTime(), result[0].Date);
           
        }

        [TestMethod]
        public void Can_Write_Log_When_Get_All_Trips()
        {
            _loggerMock.Setup(l => l.Info("Logged"));
          
            _fishingServiceMock.Setup(f => f.GetTrips()).Returns(SetupTrips());

            _goFishingApiController.GetListAllTrips();


        }

        public List<Trip> SetupTrips()
        {
            var trips = new List<Trip>();
            var trip = new Trip()
            {
                BoatName = "abcd",
                Date = new DateTime()
            };
            trips.Add(trip);

            return trips;
        }
    }
}
