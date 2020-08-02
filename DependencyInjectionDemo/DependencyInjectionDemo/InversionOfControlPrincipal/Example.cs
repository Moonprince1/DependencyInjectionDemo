#define IoCP

namespace DependencyInjectionDemo.InversionOfControlPrincipal
{
#if !IoCP
    class A
    {
        public void DoSomething()
        {
        }
    }

    class B
    {
        private A a;

        public B()
        {
            this.a = new A(); 
        }

        public void DoSomeWork()
        {
            this.a.DoSomething();
        }
    }
#else
    class A
    {
        public void DoSomething()
        {
        }
    }

    class B
    {
        private A a;

        public B(A a)
        {
            this.a = a;
        }

        public void DoSomeWork()
        {
            this.a.DoSomething();
        }
    }

    class Factory
    {
        public static B CreateB()
        {
            var a = new A();
            return new B(a);
        }
    }
#endif
}
