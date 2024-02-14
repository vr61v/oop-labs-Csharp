using System;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Messenger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Adapters;

public class MessengerAdapter : IAddressee
{
    private readonly IMessenger _messenger;

    public MessengerAdapter(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void TakeMessage(BaseMessage? message)
    {
        if (message is null)
        {
            Logger.Logger.Instance.WriteLog(LoggerOperation.Take, null, false);
            throw new ArgumentNullException(typeof(BaseMessage).ToString());
        }

        MessengerMessage messengerMessage = new MessengerMessageBuilder()
            .WithTitle(message.Title)
            .WithBody(message.Body)
            .WithImportance(message.Importance)
            .Build();
        _messenger.TakeMassage(messengerMessage);
    }
}