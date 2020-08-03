using Ninject.Modules;
using NinjectDependencyInjectionDemo.Message;

namespace NinjectDependencyInjectionDemo
{
    public class ApplicationBindingModule : NinjectModule
    {
        public override string Name => nameof(ApplicationBindingModule);

        public override void Load()
        {
            this.Bind<MessageSender>().ToSelf().InSingletonScope();
            this.Bind<IConfirmationMessageSender>().To<SMSMessageSender>();
        }

        public override void Unload()
        {
            this.Unbind<MessageSender>();
            this.Unbind<IConfirmationMessageSender>();

            base.Unload();
        }
    }
}
