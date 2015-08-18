using System;
using GoFishing.Domain.DTO;
using NServiceBus;

namespace GoFishing.NServicebusMessage
{
    [Serializable]
    public class EventMessage : IMessage
    {
        public Trip Trip { get; set; }

    }
}