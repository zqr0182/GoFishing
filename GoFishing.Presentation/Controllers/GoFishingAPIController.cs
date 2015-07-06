using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using GoFishing.Application.Services;
using GoFishing.Domain.DTO;
using NLog;

namespace GoFishing.Presentation.Controllers
{
    public class GoFishingAPIController : ApiController
    {
        private readonly IFishingService _fishingService;
        public static Logger Logger = LogManager.GetCurrentClassLogger();

        public GoFishingAPIController(IFishingService fishingService)
        {
            _fishingService = fishingService;
        }

        [System.Web.Http.ActionName("ListAllTrips")]
        public HttpResponseMessage GetListAllProjects()
        {
            
            try
            {

                var result = _fishingService.GetTrips();


                return Request.CreateResponse(HttpStatusCode.OK, result);

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
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
                Logger.Error(ex.Message);
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