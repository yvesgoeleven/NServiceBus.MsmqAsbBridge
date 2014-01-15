using NServiceBus;

namespace Messages
{
    public class TestReply : IMessage
    {
        public string Message;
    }
}