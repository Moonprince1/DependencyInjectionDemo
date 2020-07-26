using System;

namespace NinjectDependencyInjectionDemo.MessageSender
{
    public class MyMessageSender
    {
        IConfirmationMessageSender messageSender = null;

        public MyMessageSender(IConfirmationMessageSender messageSender)
        {
            this.messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
        }

        public void SendMessage(string message, string recipient)
        {
            this.messageSender.Send(message, recipient);
        }
    }
}
