using System;

namespace NinjectDependencyInjectionDemo.MessageSender
{
    public class SMSMessageSender : IConfirmationMessageSender
    {
        public void Send(string message, string recipient)
        {
            if (string.IsNullOrWhiteSpace(recipient))
            {
                throw new ArgumentException("Cannot be null or empty string", nameof(recipient));
            }

            Console.WriteLine("SMS recipient={0} : data={1}", recipient, message);
        }
    }
}
