using System;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Message.Entities.Builders;

public class DisplayMessageBuilder
{
    private MessageTitle? _title;
    private MessageBody? _body;
    private MessageImportance _importance;
    private ConsoleColor _color;

    public DisplayMessageBuilder WithTitle(MessageTitle? title)
    {
        _title = title;
        return this;
    }

    public DisplayMessageBuilder WithBody(MessageBody? body)
    {
        _body = body;
        return this;
    }

    public DisplayMessageBuilder WithImportance(MessageImportance importance)
    {
        _importance = importance;
        return this;
    }

    public DisplayMessageBuilder WithColor(ConsoleColor color)
    {
        _color = color;
        return this;
    }

    public DisplayMessage? Build()
    {
        if (_title is null) throw new ArgumentNullException(typeof(MessageTitle).ToString());
        if (_body is null) throw new ArgumentNullException(typeof(MessageBody).ToString());

        return new DisplayMessage(_title, _body, _importance, _color);
    }
}