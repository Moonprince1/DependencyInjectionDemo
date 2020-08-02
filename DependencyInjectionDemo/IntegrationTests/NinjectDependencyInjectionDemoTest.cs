using Moq;
using NinjectDependencyInjectionDemo;
using NinjectDependencyInjectionDemo.Message;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class NinjectDependencyInjectionDemoTest
    {
        [TearDown]
        public void Teardown()
        {
            Program.Kernel = null;
        }

        [Test]
        public void Validate_Application_Happy_Path()
        {
            // Assign & Act
            Program.Main(null);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void Validate_Application_Sends_Expected_Message_And_Recipient()
        {
            // Assign
            var mockedConfirmationMessageSender = new Mock<IConfirmationMessageSender>();
            mockedConfirmationMessageSender.Setup(it => it.Send(It.IsAny<string>(), It.IsAny<string>()));

            Program.Kernel.Rebind<IConfirmationMessageSender>().ToConstant(mockedConfirmationMessageSender.Object);

            // Act
            Program.Main(null);

            // Assert
            mockedConfirmationMessageSender.Verify(it => it.Send("Some text", "US:123456789"), Times.Once);
        }
    }
}
