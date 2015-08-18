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
    public interface IMockLogger : ILogger
    {
        string Message {get; set;}

    }
 
    [TestClass]
    public class GoFishingControllerTest
    {
        
        private readonly GoFishingAPIController _goFishingApiController;
        private readonly Mock<IFishingService> _fishingServiceMock;
        private readonly Mock<IMockLogger> _loggerMock;
        const string ExpectedMessage = "message to log";
        const string ExceptionMessage = "exception message to log";


        public GoFishingControllerTest()
        {
            _fishingServiceMock = new Mock<IFishingService>();
            _loggerMock = new Mock<IMockLogger>();
            _goFishingApiController = new GoFishingAPIController(_fishingServiceMock.Object, _loggerMock.Object);
        }
        
        [TestMethod]
        public void GetListAllTrips_GetTrips()
        {
            _fishingServiceMock.Setup(f => f.GetTrips()).Returns(SetupTrips());

            var result = _goFishingApiController.GetListAllTrips();

            Assert.AreEqual("abcd", result[0].BoatName);
            Assert.AreEqual(new DateTime(), result[0].Date);
           
        }

        [TestMethod]
        public void GetListAllTrips_Write_To_Log()
        {

            _loggerMock.SetupProperty(l => l.Message, ExpectedMessage);

            _fishingServiceMock.Object.GetTrips();

            Assert.AreEqual(ExpectedMessage, _loggerMock.Object.Message);
        }

        [TestMethod]
        public void GetListAllTrips_GetTrips_ThrowException()
        {
            _fishingServiceMock.Setup(f => f.GetTrips()).Throws(new Exception(ExceptionMessage));

            AssertException.Throws<Exception>(() => _fishingServiceMock.Object.GetTrips());
        }


        [TestMethod]
        public void GetListAllTrips_GetTrips_ThrowException_Write_Log()
        {
            _loggerMock.SetupProperty(l => l.Message, ExceptionMessage);
            
            _fishingServiceMock.Setup(f => f.GetTrips()).Throws(new Exception(ExceptionMessage));

            Assert.AreEqual(ExceptionMessage, _loggerMock.Object.Message);
        }

        public static class AssertException
        {
            public static T Throws<T>(Action action) where T : Exception
            {
                try
                {
                    action();
                }
                catch (T ex)
                {
                    return ex;
                }

                Assert.Fail("Expected exception of type {0}.", typeof(T));

                return null;
            }
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
