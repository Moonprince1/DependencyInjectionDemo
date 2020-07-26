using System;

namespace NinjectDependencyInjectionDemo.MessageSender
{
    public class EmailMessageSender : IConfirmationMessageSender
    {
        public void Send(string message, string recipient)
        {
            if (string.IsNullOrWhiteSpace(recipient))
            {
                throw new ArgumentException("Cannot be null or empty string", nameof(recipient));
            }

            Console.WriteLine("Email recipient={0} : data={1}", recipient, message);
        }
    }
}
