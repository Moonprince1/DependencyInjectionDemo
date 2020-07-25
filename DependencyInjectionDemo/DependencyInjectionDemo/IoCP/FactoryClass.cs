namespace DependencyInjectionDemo.IoCP
{
    public class FactoryClass
    {
        public static ClassA CreateClassA()
        {
            return new ClassA();
        }
    }
}
