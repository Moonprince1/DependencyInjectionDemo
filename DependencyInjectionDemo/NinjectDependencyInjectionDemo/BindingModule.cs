using Ninject.Modules;
using NinjectDependencyInjectionDemo.MessageSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDependencyInjectionDemo
{
    public class BindingModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IConfirmationMessageSender>().To<SMSMessageSender>();
        }

        public override void Unload()
        {
            this.Unbind<IConfirmationMessageSender>();

            base.Unload();
        }
    }
}
