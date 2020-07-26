using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDependencyInjectionDemo.MessageSender
{
    public class MyMessageSender
    {
        IConfirmationMessageSender _messageSender = null;

        public MyMessageSender(IConfirmationMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public void SendMessage(string message, string recipient)
        {
            _messageSender.Send(message, recipient);
        }
    }
}
