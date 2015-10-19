using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Castle.Core.Logging;
using GoFishing.Application.Services;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using GoFishing.Domain.Models;

namespace GoFishing.Presentation.Controllers
{
    [Authorize]
    public class GoFishingAPIController : ApiController
    {
        private readonly IFishingService _fishingService;
        private readonly ILogger _logger;

        public GoFishingAPIController(IFishingService fishingService, ILogger logger)
        {
            _fishingService = fishingService;
            _logger = logger;
        }

        [AllowAnonymous]
        [ActionName("ListAllTrips")]
        [HttpGet]
        public async Task<IEnumerable<Trip>> ListAllTrips()
        {

            try
            {

                var result = _fishingService.GetTrips();

                _logger.Info(result.Count.ToString());

                return result;

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);

                return null;
            }
        }
        [AllowAnonymous]
        [ActionName("TripDetail")]
        [HttpGet]
        public async Task<HttpResponseMessage> TripDetail([FromUri] Trip tripParameters)
        {

            try
            {

                var result = _fishingService.GetTripDetail(tripParameters.Id);

                 return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [AllowAnonymous]
        [ActionName("AddTrip")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddTrip([FromBody] Trip tripParameters)
        {

            try
            {
                tripParameters.Date = DateTime.Now;
                tripParameters.CreationDate = DateTime.Now;
                
                _fishingService.AddTrip(tripParameters);

                return Request.CreateResponse(HttpStatusCode.OK, new Result { Message = "New trip added" });

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    var result = _fishingService.GetTrips();
            
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }

    public class Result
    {
        public string Message { get; set; }
    }

}