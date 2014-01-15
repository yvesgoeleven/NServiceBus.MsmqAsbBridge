using NServiceBus;
using NServiceBus.Settings;
using NServiceBus.Transports;

namespace AsbMsmqBridge
{
    public class SubscribeToAllEvents : IWantToRunWhenBusStartsAndStops
    {
        private readonly IManageSubscriptions _subscriptionManager;

        public SubscribeToAllEvents(IManageSubscriptions subscriptionManager)
        {
            _subscriptionManager = subscriptionManager;
        }

        public void Start()
        {
            _subscriptionManager.Subscribe(null, Address.Parse("AsbEndpoint@" + SettingsHolder.Get<string>("NServiceBus.Transport.ConnectionString")));
        }

        public void Stop()
        {
        }
    }
}