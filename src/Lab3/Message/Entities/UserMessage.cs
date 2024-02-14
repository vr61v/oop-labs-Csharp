using System;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Message.Entities;

public class UserMessage : BaseMessage
{
    private bool _isRead;

    public UserMessage(MessageTitle? title, MessageBody? body, MessageImportance importance, bool isRead)
    {
        Title = title;
        Body = body;
        Importance = importance;
        IsRead = isRead;
    }

    public bool IsRead
    {
        get => _isRead;
        set
        {
            if (_isRead) throw new ArgumentException("Message already is read");
            _isRead = value;
        }
    }

    public override string ToString()
    {
        return $"{Title?.Title}\n{Body?.Body}\nIsRead: {IsRead}";
    }

    public override bool Equals(object? obj)
    {
        var message = obj as UserMessage;

        return Equals(message);
    }

    public override int GetHashCode()
    {
        return _isRead.GetHashCode();
    }

    private bool Equals(UserMessage? other)
    {
        return other is not null &&
               Equals(Title, other.Title) &&
               Equals(Body, other.Body) &&
               Importance == other.Importance &&
               IsRead == other.IsRead;
    }
}