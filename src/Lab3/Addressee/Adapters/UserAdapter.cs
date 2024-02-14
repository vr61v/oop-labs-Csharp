using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.User;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Entities.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Adapters;

public class UserAdapter : IAddressee
{
    private readonly IUser _user;

    public UserAdapter(IUser user)
    {
        _user = user;
    }

    public void TakeMessage(BaseMessage? message)
    {
        if (message is null)
        {
            Logger.Logger.Instance.WriteLog(LoggerOperation.Take, null, false);
            throw new ArgumentNullException(typeof(BaseMessage).ToString());
        }

        if (message is UserMessage userMessage1)
        {
            _user.TakeMessage(userMessage1);
            return;
        }

        UserMessage userMessage = new UserMessageBuilder()
            .WithTitle(message.Title)
            .WithBody(message.Body)
            .WithImportance(message.Importance)
            .WithIsRead(false)
            .Build();
        _user.TakeMessage(userMessage);
    }
}