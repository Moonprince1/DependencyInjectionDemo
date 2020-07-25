using System;
using System.Threading;

namespace DependencyInjectionDemo.DIP
{
    public class ClassD : IDoSomething
    {
        public void DoSomething()
        {
            Console.WriteLine("Performing something...");
            Thread.Sleep(1000);
            Console.WriteLine("Done!");
        }
    }
}
