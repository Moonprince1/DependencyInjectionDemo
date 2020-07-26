using DependencyInjectionDemo.Factory;
using System;

namespace DependencyInjectionDemo.DIP
{
    public class ClassC
    {
        private IDoSomething doSomething;

        public ClassC()
        {
            this.doSomething = FactoryClass.CreateDoSomething();
        }

        public void PerformAction()
        {
            Console.WriteLine($"ClassC.PerformAction - Calling {nameof(this.doSomething)} to perform some work!");
            this.doSomething.DoSomething();
            Console.WriteLine("ClassC.PerformAction - Done!");
        }
    }
}
