using Ninject;
using NinjectDependencyInjectionDemo.MessageSender;
using System;
using System.Reflection;

namespace NinjectDependencyInjectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            IConfirmationMessageSender confirmationMessage = kernel.Get<IConfirmationMessageSender>();
            var messageSender = new MyMessageSender(confirmationMessage);
            messageSender.SendMessage("Some text", "123456789");
            Console.ReadKey();
        }
    }
}
