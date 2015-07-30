using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NServiceBus;

using GoFishing.Domain.DTO;
using GoFishing.NServicebusMessage;

namespace GoFishing.Presentation.Controllers
{
    public class EventController : ApiController
    {

        public Event Get()
        {
            var msg = new Event
                {
                    Trip = new Trip
                    {
                        BoatName = "Brooklyn6"
                    }
                };

            Global.Bus.Send(msg);

            return msg;
        }
    }
}
