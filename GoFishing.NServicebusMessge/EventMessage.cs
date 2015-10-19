using System;
using GoFishing.Domain.Models;
using NServiceBus;

namespace GoFishing.NServicebusMessage
{
    [Serializable]
    public class EventMessage : IMessage
    {
        public Trip Trip { get; set; }

    }
}