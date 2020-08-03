using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocking
{
    public class A
    {
        public bool NonVirtualFunctionCannotBeMocked(string someData)
        {
            if (someData == "Bye")
            {
                return true;
            }

            return false;
        }

        public virtual bool VirtualFunctionsCanBeMocked(string someData)
        {
            if (someData == "Hello")
            {
                return true;
            }

            return false;
        }
    }

    public interface IInterfacesCanBeMocked
    {
        bool SomeFunction(bool b, string s);
        void SomeOtherFunction(bool b);
    }

    [TestFixture]
    public class MockExamples
    {
        [Test]
        public void SetupAndReturnValue()
        {
            var mock = new Mock<IInterfacesCanBeMocked>();
            mock.Setup(it => it.SomeFunction(It.IsAny<bool>(), It.IsAny<string>())).Returns(true);

            var val1 = mock.Object.SomeFunction(true, "test"); // val1 will be true
            var val2 = mock.Object.SomeFunction(true, "another test"); // val2 will be true

            Assert.That(val1, Is.True);
            Assert.That(val2, Is.True);
        }

        [Test]
        public void SetupAndReturnSequenceValue()
        {
            var mock = new Mock<IInterfacesCanBeMocked>();
            mock.SetupSequence(it => it.SomeFunction(It.IsAny<bool>(), It.IsAny<string>())).Returns(true).Returns(false);

            var val1 = mock.Object.SomeFunction(true, "test"); // val1 will be true
            var val2 = mock.Object.SomeFunction(true, "another test"); // val2 will be false

            Assert.That(val1, Is.True);
            Assert.That(val2, Is.False);
        }

        [Test]
        public void SetupAndCapturePassedParameters()
        {
            var mock = new Mock<IInterfacesCanBeMocked>();
            bool someOtherFunctionParamValue = false;
            mock.Setup(it => it.SomeOtherFunction(It.IsAny<bool>())).Callback<bool>(b=> someOtherFunctionParamValue = b);

            mock.Object.SomeOtherFunction(true); // someOtherFunctionParamValue should now be true

            Assert.That(someOtherFunctionParamValue, Is.True);

            mock.Object.SomeOtherFunction(false); // someOtherFunctionParamValue should now be false

            Assert.That(someOtherFunctionParamValue, Is.False);
        }

        [Test]
        public void SetupAndThrowAnException()
        {
            var mock = new Mock<IInterfacesCanBeMocked>();
            mock.Setup(it => it.SomeOtherFunction(true)).Throws(new Exception("Oups")); // Throw when true
            mock.Setup(it => it.SomeOtherFunction(false)); // False is OK

            Assert.Throws<Exception>(() => mock.Object.SomeOtherFunction(true), "Oups");

            mock.Object.SomeOtherFunction(false); // Will not throw
        }

        [Test]
        public void CannotMockNonVirtualFunctionsFromConcreteClasses()
        {
            var mock = new Mock<A>();

            // Trying to setup non overridable function of concrete class will throw
            Assert.Throws<NotSupportedException>(() => mock.Setup(it => it.NonVirtualFunctionCannotBeMocked(It.IsAny<string>())).Returns(true));

            // But we can setup virtual and abstract functions
            mock.Setup(it => it.VirtualFunctionsCanBeMocked(It.IsAny<string>())).Returns(true);

            var val = mock.Object.VirtualFunctionsCanBeMocked("Test");

            Assert.That(val, Is.True);
        }

        [Test]
        public void VerifyThatMockWasCalled()
        {
            var mock = new Mock<A>();
            mock.Setup(it => it.VirtualFunctionsCanBeMocked(It.IsAny<string>())); // We need to setup if we want to verify

            var val = mock.Object.VirtualFunctionsCanBeMocked("Test1"); // If we comment, code below will fail

            mock.Verify(it => it.VirtualFunctionsCanBeMocked("Test1"), Times.Once);

            // We can also validate that a call with specific parameters was never done
            mock.Verify(it => it.VirtualFunctionsCanBeMocked("Test2"), Times.Never);
        }
    }
}
