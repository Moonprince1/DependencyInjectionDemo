using Ninject;
using NinjectDependencyInjectionDemo.MessageSender;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NinjectDependencyInjectionDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var messageSender = ObjectStore.Instance.Kernel.Get<MyMessageSender>();
            messageSender.SendMessage("Some text", "US:123456789");
        }
    }
}
