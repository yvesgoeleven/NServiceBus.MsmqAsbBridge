using System;
using Messages;
using NServiceBus;

namespace MsmqEndpoint
{
    public class HandleTestEvent : IHandleMessages<TestEvent>
    {
        public void Handle(TestEvent message)
        {
            Console.WriteLine("Received: " + message.Message);
        }
    }
}