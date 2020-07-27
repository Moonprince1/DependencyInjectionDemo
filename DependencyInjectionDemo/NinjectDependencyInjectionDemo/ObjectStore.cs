using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDependencyInjectionDemo
{
    public class ObjectStore
    {
        private static object lockObjectStore = new object();
        private static ObjectStore instance;

        public static ObjectStore Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObjectStore)
                    {
                        if (instance == null)
                        {
                            IKernel kernel = new StandardKernel();
                            kernel.Load(Assembly.GetExecutingAssembly());

                            instance = new ObjectStore(kernel);
                        }
                    }
                }

                return instance;
            }
        }

        private ObjectStore(IKernel kernel)
        {
            this.Kernel = kernel;
        }

        private IKernel Kernel { get; }

        public T Get<T>(params IParameter[] parameters)
        {
            return this.Kernel.Get<T>(parameters);
        }

        public IBindingToSyntax<T> Rebind<T>()
        {
            return this.Kernel.Rebind<T>();
        }

        public void Reset()
        {
            lock (lockObjectStore)
            {
                instance = null;
            }
        }
    }
}
