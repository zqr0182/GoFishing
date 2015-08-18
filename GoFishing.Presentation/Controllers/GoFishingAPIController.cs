using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Castle.Core.Logging;
using GoFishing.Application.Services;
using GoFishing.Domain.DTO;

namespace GoFishing.Presentation.Controllers
{
    public class GoFishingAPIController : ApiController
    {
        private readonly IFishingService _fishingService;
        private readonly ILogger _logger;

        public GoFishingAPIController(IFishingService fishingService, ILogger logger)
        {
            _fishingService = fishingService;
            _logger = logger;
        }

        [System.Web.Http.ActionName("ListAllTrips")]
        public List<Domain.Models.Trip> GetListAllTrips()
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

        [System.Web.Http.ActionName("TripDetail")]
        public HttpResponseMessage GetTripDetail([FromUri] Trip tripParameters)
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
}