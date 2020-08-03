using Ninject;
using NinjectDependencyInjectionDemo.Message;
using System.Reflection;
using System.Threading.Tasks;

namespace NinjectDependencyInjectionDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var messageSender = Kernel.Get<MessageSender>();
            messageSender.SendMessage("Some text", "US:123456789");

            Task.Delay(3000).Wait();
        }

        private static IKernel kernel;
        public static IKernel Kernel
        {
            get
            {
                if (kernel == null)
                {
                    kernel = new StandardKernel();
                    kernel.Load(Assembly.GetExecutingAssembly());
                }

                return kernel;
            }
            set
            {
                kernel = value;
            }
        }
    }
}
