using libphonenumber;
using System;

namespace NinjectDependencyInjectionDemo.Message
{
    public class SMSMessageSender : IConfirmationMessageSender
    {
        public void Send(string message, string recipient)
        {
            if (string.IsNullOrWhiteSpace(recipient))
            {
                throw new ArgumentException("Cannot be null, empty or whitespaces string", nameof(recipient));
            }

            var splited = recipient.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (splited.Length != 2)
            {
                throw new ArgumentException("Invalid format. Should be <COUNTRY_CODE>:<PHONE_NUMBER>. Ex: US:(123)456-7890", nameof(recipient)); 
            }

            string countryCode = splited[0].ToUpperInvariant();
            string phoneNumber = splited[1];
            
            PhoneNumber phone;
            try
            {
                phone = PhoneNumberUtil.Instance.ParseAndKeepRawInput(phoneNumber, countryCode);
            }
            catch (NumberParseException ex)
            {
                throw new ArgumentException($"{phoneNumber} is not a valid phone number for country code {countryCode}", nameof(recipient), ex);
            }

            Console.WriteLine("SMS recipient={0} : data={1}", phone.RawInput, message);
        }
    }
}
