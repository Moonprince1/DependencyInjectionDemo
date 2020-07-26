namespace NinjectDependencyInjectionDemo.MessageSender
{
    public interface IConfirmationMessageSender
    {
        void Send(string message, string recipient);
    }
}
