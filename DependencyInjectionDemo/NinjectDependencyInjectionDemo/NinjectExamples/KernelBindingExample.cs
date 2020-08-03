using Ninject;
using System;

namespace NinjectDependencyInjectionDemo.NinjectExamples
{
    class KernelBindingExample
    {
        interface ISomeMethod
        {
            void DoIt();
        }

        class B : ISomeMethod
        {
            public void DoIt()
            {
                // Do something...
            }
        }

        class A
        {
            private readonly ISomeMethod someMethod;

            public A(ISomeMethod someMethod)
            {
                this.someMethod = someMethod;
            }

            public void CallSomeMethod()
            {
                this.someMethod.DoIt();
            }
        }

        public void CreateKernelAndGetInstance()
        {
            using (var kernal = new StandardKernel())
            {
                // le dice que use la implementación B cuando pida ISomMethod.
                kernal.Bind<ISomeMethod>().To<B>();

                // le dice a Ninject que auto detecte el constructor y las dependencias, esto es en realidad opcional ya que Ninject lo hace por defecto.
                kernal.Bind<A>().ToSelf();

                // instanciar A
                var instanceA = kernal.Get<A>();

                instanceA.CallSomeMethod();

                // instanciar A de nuevo
                var instanceA2 = kernal.Get<A>();

                // esto no debería suceder, ya que el scope no es singleton ni thread scope
                if (instanceA == instanceA2)
                {
                    throw new Exception("Oups... es la misma instancia de A!!!");
                }
            }
        }
    }
}
