using NServiceBus;

namespace AsbEndpoint
{
    public class UseXmlSerializer : INeedInitialization
    {
        public void Init()
        {
            // The msmq transport uses xml by default, as the bridge just forwards, 
            // we will also just get xml messages.

            Configure.Serialization.Xml();
        }
    }
}