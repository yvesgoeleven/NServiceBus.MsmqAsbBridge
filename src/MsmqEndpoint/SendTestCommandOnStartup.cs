using System;
using Messages;
using NServiceBus;

namespace MsmqEndpoint
{
    public class SendTestCommandOnStartup : IWantToRunWhenBusStartsAndStops
    {
        private readonly IBus _bus;

        public SendTestCommandOnStartup(IBus bus)
        {
            _bus = bus;
        }

        public void Start()
        {
            Console.WriteLine("Saying hi to Azure");

            _bus.Send(new TestCommand { Hello = "Azure", IAm = "Msmq" });
        }

        public void Stop()
        {
        }
    }
}
