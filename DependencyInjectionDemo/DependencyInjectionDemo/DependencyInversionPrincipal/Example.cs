#define DIP

using System;

namespace DependencyInjectionDemo.DependencyInversionPrincipal
{
#if !DIP
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
#else
    interface IDoSomething
    {
        void DoSomething();
    }

    class A : IDoSomething
    {
        public void DoSomething()
        {
            // Do something here...
        }
    }

    class B
    {
        private IDoSomething task;
        public B(IDoSomething task)
        {
            this.task = task;
        }

        public void DoSomeWork()
        {
            this.task.DoSomething();
        }
    }
#endif
}
