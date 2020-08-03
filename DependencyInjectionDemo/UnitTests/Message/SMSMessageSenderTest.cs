using NinjectDependencyInjectionDemo.Message;
using NUnit.Framework;
using System;

namespace UnitTests.Message
{
    [TestFixture]
    public class SMSMessageSenderTest
    {
        private SMSMessageSender target;

        [SetUp]
        public void Setup()
        {
            this.target = new SMSMessageSender();
        }

        [TestCase(null, "Cannot be null, empty or whitespaces string", Description = "Recipient is null")]
        [TestCase("", "Cannot be null, empty or whitespaces string", Description = "Recipient is empty")]
        [TestCase("        ", "Cannot be null, empty or whitespaces string", Description = "Recipient is white speaces only")]
        [TestCase(":", "Invalid format. Should be <COUNTRY_CODE>:<PHONE_NUMBER>. Ex: US:(123)456-7890", Description = "Recipient with wrong format")]
        [TestCase("US:", "Invalid format. Should be <COUNTRY_CODE>:<PHONE_NUMBER>. Ex: US:(123)456-7890", Description = "Recipient with country code only")]
        [TestCase(":1234567890", "Invalid format. Should be <COUNTRY_CODE>:<PHONE_NUMBER>. Ex: US:(123)456-7890", Description = "Recipient with phone number only")]
        public void Send_Throws_With_Invalid_Recipient(string recipient, string expectedErrorMessage)
        {
            // Assign
            var message = "Some message";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => this.target.Send(message, recipient));

            Assert.That(ex.ParamName, Is.EqualTo("recipient"));
            Assert.That(ex.Message, Does.StartWith(expectedErrorMessage));
        }

        [TestCase("XXX")]
        [TestCase("Z")]
        public void Send_Throws_With_Invalid_Region(string country)
        {
            // Assign
            var message = "Some message";
            var recipient = $"{country}:1234567890";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => this.target.Send(message, recipient));

            Assert.That(ex.ParamName, Is.EqualTo("recipient"));
            Assert.That(ex.Message, Does.StartWith($"1234567890 is not a valid phone number for country code {country}"));
        }

        [TestCase("ca", "+1(514)777-22-88")]
        [TestCase("ca", "15147772288")]
        [TestCase("CA", "+1(514)777-22-88")]
        [TestCase("ca", "(514)777-22-88")]
        [TestCase("US", "1234567890")]
        public void Send_Happy_Path(string country, string phoneNumber)
        {
            // Assign
            var recipient = $"{country}:{phoneNumber}";
            var message = "Hello!";

            // Act
            this.target.Send(message, recipient);

            // Assert
            Assert.Pass();
        }
    }
}
