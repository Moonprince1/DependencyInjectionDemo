using DependencyInjectionDemo.Factory;

namespace DependencyInjectionDemo.DIP
{
    public class ClassC
    {
        private IDoSomething doSomething;

        public ClassC()
        {
            this.doSomething = FactoryClass.CreateDoSomething();
        }
    }
}
