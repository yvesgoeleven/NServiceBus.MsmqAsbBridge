using System;
using NServiceBus;
using NServiceBus.Pipeline;
using NServiceBus.Pipeline.Contexts;
using NServiceBus.Transports.Msmq;
using NServiceBus.Transports.Msmq.Config;

namespace AsbMsmqBridge
{
    class ForwardReceivedMessageToMsmq : IBehavior<ReceivePhysicalMessageContext>
    {
        
        public void Invoke(ReceivePhysicalMessageContext context, Action next)
        {
            var transportMessage = context.PhysicalMessage;

            //change reply to to the other half of the bridge
            transportMessage.ReplyToAddress = Address.Parse("MsmqAsbBridge@" + Environment.MachineName);

            var sender = new MsmqMessageSender {Settings = new MsmqSettings(), UnitOfWork = new MsmqUnitOfWork()};

            sender.Send(transportMessage, Address.Parse("MsmqEndpoint@" + Environment.MachineName));
        }
    }
}