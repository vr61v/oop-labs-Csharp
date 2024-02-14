using System;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Message.Entities;

public class DisplayMessage : BaseMessage
{
    public DisplayMessage(MessageTitle? title, MessageBody? body, MessageImportance importance, ConsoleColor color)
    {
        Title = title;
        Body = body;
        Importance = importance;
        Color = color;
    }

    public ConsoleColor Color { get; set; }

    public override string ToString()
    {
        return $"{Title?.Title}\n{Body?.Body}\nColor: {Color}";
    }

    public override bool Equals(object? obj)
    {
        var message = obj as DisplayMessage;

        return Equals(message);
    }

    public override int GetHashCode()
    {
        return (int)Color;
    }

    private bool Equals(DisplayMessage? other)
    {
        return other is not null &&
               Equals(Title, other.Title) &&
               Equals(Body, other.Body) &&
               Importance == other.Importance &&
               Color == other.Color;
    }
}