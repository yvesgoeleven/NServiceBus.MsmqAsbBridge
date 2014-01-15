using NServiceBus;

namespace Messages
{
    public class TestCommand : ICommand
    {
        public string Hello { get; set; }
        public string IAm { get; set; }
    }
}
