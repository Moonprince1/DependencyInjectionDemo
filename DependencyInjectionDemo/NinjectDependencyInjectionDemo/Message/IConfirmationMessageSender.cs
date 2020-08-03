namespace NinjectDependencyInjectionDemo.Message
{
    public interface IConfirmationMessageSender
    {
        void Send(string message, string recipient);
    }
}
