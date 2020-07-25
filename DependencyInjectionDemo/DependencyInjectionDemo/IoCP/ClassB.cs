namespace DependencyInjectionDemo.IoCP
{
    public class ClassB
    {
        private ClassA classA;

        public ClassB()
        {
            this.classA = new ClassA();
        }
    }

    #region IoCP_ClassB
    public class IoCP_ClassB
    {
        private ClassA classA;

        public IoCP_ClassB()
        {
            this.classA = FactoryClass.CreateClassA();
        }
    }
    #endregion
}
