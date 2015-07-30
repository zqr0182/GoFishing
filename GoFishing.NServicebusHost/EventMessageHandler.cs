using GoFishing.NServicebusMessage;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFishing.NServicebusHost
{
    public class EventMessageHandler : IHandleMessages<Event>
    {
        public void Handle(Event message)
        {
            Console.WriteLine("Event received: trip name: " + message.Trip.BoatName);
        }
    }
}
