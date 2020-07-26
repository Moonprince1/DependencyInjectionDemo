using System;

namespace NinjectDependencyInjectionDemo.MessageSender
{
    public class SMSMessageSender : IConfirmationMessageSender
    {
        public void Send(string message, string recipient)
        {
            Console.WriteLine("SMS recipient={0} : data={1}", recipient, message);
        }
    }
}
