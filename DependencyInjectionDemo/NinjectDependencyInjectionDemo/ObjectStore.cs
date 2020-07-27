using Ninject;
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

        public IKernel Kernel { get; private set; }

        public void Reset()
        {
            lock (lockObjectStore)
            {
                if (instance != null)
                {
                    var kernel = instance.Kernel;
                    instance = null;
                    kernel.Dispose();
                }
            }
        }
    }
}
