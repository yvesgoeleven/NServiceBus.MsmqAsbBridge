using NServiceBus;

namespace Messages
{
    public class TestEvent : IEvent
    {
        public string Message;
    }
}