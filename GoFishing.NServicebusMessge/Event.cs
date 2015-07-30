using GoFishing.Domain.DTO;
using NServiceBus;

namespace GoFishing.NServicebusMessage
{
    public class Event : IMessage
    {
        public Trip Trip { get; set; }

    }
}