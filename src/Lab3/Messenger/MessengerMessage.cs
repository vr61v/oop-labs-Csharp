using System;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class MessengerMessage
{
    public MessengerMessage(MessageTitle? title, MessageBody? body, MessageImportance importance)
    {
        Title = title;
        Body = body;
        Importance = importance;
    }

    public MessageTitle? Title { get; protected set; }
    public MessageBody? Body { get; protected set; }
    public MessageImportance Importance { get; protected set; }

    public override bool Equals(object? obj)
    {
        var message = obj as MessengerMessage;
        return Equals(message);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Body, (int)Importance);
    }

    private bool Equals(MessengerMessage? other)
    {
        return other is not null &&
               Equals(Title, other.Title) &&
               Equals(Body, other.Body) &&
               Importance == other.Importance;
    }
}