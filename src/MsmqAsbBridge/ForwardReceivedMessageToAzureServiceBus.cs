using System;
using NServiceBus;
using NServiceBus.Azure.Transports.WindowsAzureServiceBus;
using NServiceBus.Pipeline;
using NServiceBus.Pipeline.Contexts;
using NServiceBus.Settings;

namespace MsmqAsbBridge
{
    class ForwardReceivedMessageToAzureServiceBus : IBehavior<ReceivePhysicalMessageContext>
    {
        public void Invoke(ReceivePhysicalMessageContext context, Action next)
        {
            var transportMessage = context.PhysicalMessage;

            //change reply to to the other half of the bridge
            transportMessage.ReplyToAddress = Address.Parse("AsbMsmqBridge@" + SettingsHolder.Get<string>("NServiceBus.Transport.ConnectionString"));

            var sender = new AzureServiceBusMessageQueueSender(new CreatesMessagingFactories());

            sender.Send(transportMessage, "AsbEndpoint");
        }
    }
}