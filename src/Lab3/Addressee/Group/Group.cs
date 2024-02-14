using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Group;

public class Group : IGroup
{
    public Group(IList<IAddressee> addressees, MessageImportance importance)
    {
        Addressees = addressees;
        Importance = importance;
    }

    public IList<IAddressee> Addressees { get; private set; }
    public MessageImportance Importance { get; private set; }
    public void TakeMessage(BaseMessage? message)
    {
        if (message is null)
        {
            Logger.Logger.Instance.WriteLog(LoggerOperation.Take, null, false);
            throw new ArgumentNullException(typeof(UserMessage).ToString());
        }

        if (message.Importance <= Importance)
        {
            Logger.Logger.Instance.WriteLog(LoggerOperation.Take, message, false);
            return;
        }

        Logger.Logger.Instance.WriteLog(LoggerOperation.Take, message, true);
        foreach (IAddressee addressee in Addressees)
            addressee.TakeMessage(message);
    }
}