using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Messages;
using NServiceBus;

namespace AsbEndpoint
{
    public class HandleTestCommand : IHandleMessages<TestCommand>
    {
        private readonly IBus _bus;

        public HandleTestCommand(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(TestCommand message)
        {
            Console.WriteLine("Hello there " + message.IAm);

            _bus.Send(new TestReply { Message = "Send from asb to msmq" });

            _bus.Reply(new TestReply { Message = "Reply from asb to msmq" });

            _bus.Publish(new TestEvent { Message = "Pubsub from asb to msmq" });
        }
    }
}
