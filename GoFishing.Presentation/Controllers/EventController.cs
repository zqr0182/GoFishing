using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NServiceBus;

using GoFishing.Domain.Models;
using GoFishing.NServicebusMessage;

namespace GoFishing.Presentation.Controllers
{
    public class EventController : ApiController
    {

        public EventMessage Get()
        {
            var msg = new EventMessage
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
