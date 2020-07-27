using NinjectDependencyInjectionDemo.MessageSender;

namespace IntegrationTests
{
    public class TestEmailMessageSender : IConfirmationMessageSender
    {
        public void Send(string message, string recipient)
        {
            
        }
    }
}