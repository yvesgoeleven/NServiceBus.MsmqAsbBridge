using NServiceBus.Pipeline;
using NServiceBus.Pipeline.Contexts;
using NServiceBus.Unicast.Messages;

namespace MsmqAsbBridge
{
    public class PipelineOverride : IPipelineOverride
    {
        public void Override(BehaviorList<HandlerInvocationContext> behaviorList)
        {
            
        }

        public void Override(BehaviorList<ReceiveLogicalMessageContext> behaviorList)
        {
        }

        public void Override(BehaviorList<ReceivePhysicalMessageContext> behaviorList)
        {
            behaviorList.Replace<ExtractLogicalMessagesBehavior, ForwardReceivedMessageToAzureServiceBus>();
        }

        public void Override(BehaviorList<SendLogicalMessageContext> behaviorList)
        {
        }

        public void Override(BehaviorList<SendLogicalMessagesContext> behaviorList)
        {
        }

        public void Override(BehaviorList<SendPhysicalMessageContext> behaviorList)
        {
        }
    }
}