using System;

namespace NinjectDependencyInjectionDemo.MessageSender
{
    public class EmailMessageSender : IConfirmationMessageSender
    {
        public void Send(string message, string recipient)
        {
            Console.WriteLine("Email recipient={0} : data={1}", recipient, message);
        }
    }
}
