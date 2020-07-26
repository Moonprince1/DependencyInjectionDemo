using System;
using System.Threading;

namespace DependencyInjectionDemo.DIP
{
    public class ClassD : IDoSomething
    {
        public void DoSomething()
        {
            Console.WriteLine($"ClassD.DoSomething - Performing something...");
            Thread.Sleep(1000); // Sleeping... :)
            Console.WriteLine("ClassD.DoSomething - Done!");
        }
    }
}
