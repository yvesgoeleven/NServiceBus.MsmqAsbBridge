using System;
using Messages;
using NServiceBus;

namespace MsmqEndpoint
{
    public class HandleTestReply : IHandleMessages<TestReply>
    {
        public void Handle(TestReply message)
        {
            Console.WriteLine("Received: " + message.Message);
        }
    }
}