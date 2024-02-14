using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.User.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.User;

public class User : IUser
{
    public User(UserName name, UserPhoto photo, DateTime dateOfBirth, MessageImportance importance, IList<UserMessage>? messages)
    {
        Name = name;
        Photo = photo;
        DateOfBirth = dateOfBirth;
        Importance = importance;
        Messages = messages;
    }

    public UserName Name { get; private set; }
    public UserPhoto Photo { get; private set; }
    public MessageImportance Importance { get; private set; }
    public DateTime DateOfBirth { get; private set; }

    public IList<UserMessage>? Messages { get; private set; }
    public int CountMessages()
    {
        return Messages?.Count ?? 0;
    }

    public void ReadAllMessages()
    {
        if (Messages is null)
        {
            Logger.Logger.Instance.WriteLog(LoggerOperation.Read, null, false);
            throw new ArgumentNullException(typeof(UserMessage).ToString());
        }

        foreach (UserMessage message in Messages)
        {
            if (message.IsRead) continue;
            message.IsRead = true;
            Logger.Logger.Instance.WriteLog(LoggerOperation.Read, message, true);
        }
    }

    public void ReadMessage(UserMessage message)
    {
        IList<UserMessage>? current = Messages?
            .Where(x => x.Title == message.Title && x.Body == message.Body).ToList();

        if (message is null || current is null)
        {
            Logger.Logger.Instance.WriteLog(LoggerOperation.Read, null, false);
            throw new ArgumentNullException(typeof(UserMessage).ToString());
        }

        current.First().IsRead = true;
        Logger.Logger.Instance.WriteLog(LoggerOperation.Read, current.First(), true);
    }

    public void TakeMessage(UserMessage? message)
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

        Messages?.Add(message);
        Logger.Logger.Instance.WriteLog(LoggerOperation.Take, message, true);
    }
}