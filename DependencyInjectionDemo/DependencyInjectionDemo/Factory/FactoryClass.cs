using DependencyInjectionDemo.DIP;
using DependencyInjectionDemo.IoCP;

namespace DependencyInjectionDemo.Factory
{
    public class FactoryClass
    {
        #region IoCP
        public static ClassA CreateClassA()
        {
            return new ClassA();
        }
        #endregion

        #region DIP
        public static IDoSomething CreateDoSomething()
        {
            return new ClassD();
        }
        #endregion
    }
}
