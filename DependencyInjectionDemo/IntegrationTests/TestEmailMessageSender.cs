using NinjectDependencyInjectionDemo.Message;

namespace IntegrationTests
{
    public class TestEmailMessageSender : IConfirmationMessageSender
    {
        public void Send(string message, string recipient)
        {
            
        }
    }
}