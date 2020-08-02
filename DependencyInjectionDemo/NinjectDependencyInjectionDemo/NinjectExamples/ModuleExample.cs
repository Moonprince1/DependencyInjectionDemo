using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDependencyInjectionDemo.NinjectExamples
{
    class A
    {
        private readonly ISomeImplementation someImplementation;

        public A([Named("CoolImplementation")] ISomeImplementation someImplementation)
        {
            this.someImplementation = someImplementation;
        }
    }

    interface ISomeImplementation
    {
        void SomeImplementation();
    }

    class B : ISomeImplementation
    {
        public void SomeImplementation()
        {
            // Do something...
        }
    }

    class C : ISomeImplementation
    {
        public void SomeImplementation()
        {
            // Do something...
        }
    }

    class ModuleExample : NinjectModule
    {
        public override string Name => "NinjectModuleExample";

        public override void Load()
        {
            this.Bind<ISomeImplementation>().To<B>().Named("BadImplementation");
            this.Bind<ISomeImplementation>().To<C>().Named("CoolImplementation");
        }

        public override void Unload()
        {
            this.Unbind<ISomeImplementation>();

            base.Unload();
        }
    }
}
