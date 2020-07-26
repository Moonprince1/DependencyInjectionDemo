﻿using Moq;
using NinjectDependencyInjectionDemo.MessageSender;
using NUnit.Framework;
using System;

namespace UnitTests.MessageSender
{
    [TestFixture]
    public class MyMessageSenderTest
    {
        [Test]
        public void Constructor_Throws_With_Invalid_Parameters()
        {
            // Assign, Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => new MyMessageSender(null));

            Assert.That(ex.ParamName, Is.EqualTo("messageSender"));
        }

        [Test]
        public void SendMessage_Sends_A_Message()
        {
            // Assign
            var confirmationMessageSender = new Mock<IConfirmationMessageSender>();
            confirmationMessageSender.Setup(it => it.Send(It.IsAny<string>(), It.IsAny<string>()));

            var myMessageSender = new MyMessageSender(confirmationMessageSender.Object);

            // Act
            myMessageSender.SendMessage("Some Message", "Some Recipient");

            // Assert
            confirmationMessageSender.Verify(it => it.Send(It.IsAny<string>(), It.IsAny<string>()), Times.Once, "Send was called more times than expected");
            confirmationMessageSender.Verify(it => it.Send("Some Message", "Some Recipient"), Times.Once, "Send was not called with expected parameters");
        }
    }
}
