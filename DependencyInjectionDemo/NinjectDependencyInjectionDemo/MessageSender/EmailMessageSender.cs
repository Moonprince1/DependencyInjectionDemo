using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace NinjectDependencyInjectionDemo.MessageSender
{
    public class EmailMessageSender : IConfirmationMessageSender
    {
        public void Send(string message, string recipient)
        {
            if (string.IsNullOrWhiteSpace(recipient))
            {
                throw new ArgumentException("Cannot be null, empty or whitespaces string", nameof(recipient));
            }

            MailAddress email;
            try
            {
                email = new MailAddress(recipient);
            }
            catch (FormatException ex)
            {
                throw new ArgumentException($"{recipient} is not a valid email address", nameof(recipient), ex);
            }

            Console.WriteLine("Email recipient={0} : data={1}", email.Address, message);
        }
    }
}
