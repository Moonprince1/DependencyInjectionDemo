using NinjectDependencyInjectionDemo.MessageSender;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.MessageSender
{
    [TestFixture]
    public class EmailMessageSenderTest
    {
        private EmailMessageSender target;

        [SetUp]
        public void Setup()
        {
            this.target = new EmailMessageSender(); 
        }

        [TestCase(null, Description = "Recipient is null")]
        [TestCase("", Description = "Recipient is empty")]
        [TestCase("        ", Description = "Recipient is white speaces only")]
        public void Send_Throws_With_Invalid_Recipient(string recipient)
        {
            // Assign
            var message = "Some message";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => this.target.Send(message, recipient));

            Assert.That(ex.ParamName, Is.EqualTo("recipient"));
            Assert.That(ex.Message, Does.StartWith("Cannot be null, empty or whitespaces string"));
        }

        [TestCase("InvalidEmail.com")]
        [TestCase("InvalidEmail@")]
        [TestCase("@InvalidEmail.com")]
        public void Send_Throws_With_Invalid_Email(string recipient)
        {
            // Assign
            var message = "Some message";

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => this.target.Send(message, recipient));

            Assert.That(ex.ParamName, Is.EqualTo("recipient"));
            Assert.That(ex.Message, Does.StartWith($"{recipient} is not a valid email address"));
        }

        [TestCase("carlos.mejia@ubisoft.com")]
        [TestCase("testUser123@SomeOrganization.org")]
        public void Send_Happy_Path(string recipient)
        {
            // Assign
            var message = "Hello!";

            // Act
            this.target.Send(message, recipient);

            // Assert
            Assert.Pass();
        }
    }
}
