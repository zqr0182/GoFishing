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
        
        private  GoFishingAPIController _goFishingApiController;
        private  Mock<IFishingService> _fishingServiceMock;
        private Mock<ILogger> _loggerMock;
        const string ExceptionMessage = "exception message";

        [TestInitialize]
        public void Init()
        {
            _fishingServiceMock = new Mock<IFishingService>();
            _loggerMock = new Mock<ILogger>();
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
        public void GetListAllTrips_Write_Info_To_Log()
        {

            _fishingServiceMock.Setup(f => f.GetTrips()).Returns(SetupTrips());

            _goFishingApiController.GetListAllTrips();

            _loggerMock.Verify(l => l.Info(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetListAllTrips_GetTrips_ThrowException()
        {
            _fishingServiceMock.Setup(f => f.GetTrips()).Throws(new Exception(ExceptionMessage));

            _goFishingApiController.GetListAllTrips();

            AssertException.Throws<Exception>(() => _fishingServiceMock.Object.GetTrips());
        }

        [TestMethod]
        public void GetListAllTrips_GetTrips_Write_Error_To_Log()
        {
            _fishingServiceMock.Setup(f => f.GetTrips()).Throws(new Exception(ExceptionMessage));

            _goFishingApiController.GetListAllTrips();

            _loggerMock.Verify(l => l.Error(It.IsAny<string>()), Times.Once);

        }

        #region Helper methods

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

        #endregion
    }
}
