using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NinjectDependencyInjectionDemo.MessageSender;

namespace UnitTest
{
    [TestClass]
    public class MyMessageSenderTest
    {
        private Mock<IConfirmationMessageSender> mockedConfirmationMessageSender;

        private MyMessageSender target;

        [TestInitialize]
        public void Setup()
        {
            this.mockedConfirmationMessageSender = new Mock<IConfirmationMessageSender>();
            this.target = new MyMessageSender(this.mockedConfirmationMessageSender.Object);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Only needed if we need to release resources
        }

        [TestMethod]
        public void Constructor_Throws_With_Invalid_Parameter()
        {
            // Assign, Act & Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() => new MyMessageSender(null));

            Assert.AreEqual(ex.ParamName, "messageSender");
        }

        [TestMethod]
        public void Validate_MessageSender_Calls_IConfirmationMessageSender_When_Sending_Message()
        {
            // Assing
            this.mockedConfirmationMessageSender.Setup(it => it.Send(It.IsAny<string>(), It.IsAny<string>()));

            // Act
            this.target.SendMessage("Some message", "Some recipient");

            // Assert
            this.mockedConfirmationMessageSender.Verify(it => it.Send("Some message", "Some recipient"), Times.Once);
        }
    }
}
