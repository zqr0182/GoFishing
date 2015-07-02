using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using GoFishing.Application.Services;

namespace GoFishing.Presentation.Controllers
{
    public class GoFishingAPIController : ApiController
    {
        private readonly IFishingService _fishingService;

        public GoFishingAPIController(IFishingService fishingService)
        {
            _fishingService = fishingService;
        }
        
        // GET api/values
        public IEnumerable<string> Get()
        {
            var result = _fishingService.GetTrips();
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}