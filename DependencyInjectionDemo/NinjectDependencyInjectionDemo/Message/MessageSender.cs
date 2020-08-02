using System;

namespace NinjectDependencyInjectionDemo.Message
{
    public class MessageSender
    {
        IConfirmationMessageSender messageSender = null;

        public MessageSender(IConfirmationMessageSender messageSender)
        {
            this.messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
        }

        public void SendMessage(string message, string recipient)
        {
            this.messageSender.Send(message, recipient);
        }
    }
}
