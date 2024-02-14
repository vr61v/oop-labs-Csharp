using System;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Message.Entities.Builders;

public class UserMessageBuilder
{
    private MessageTitle? _title;
    private MessageBody? _body;
    private MessageImportance _importance;
    private bool _isRead;

    public UserMessageBuilder WithTitle(MessageTitle? title)
    {
        _title = title;
        return this;
    }

    public UserMessageBuilder WithBody(MessageBody? body)
    {
        _body = body;
        return this;
    }

    public UserMessageBuilder WithImportance(MessageImportance importance)
    {
        _importance = importance;
        return this;
    }

    public UserMessageBuilder WithIsRead(bool isRead)
    {
        _isRead = isRead;
        return this;
    }

    public UserMessage Build()
    {
        if (_title is null) throw new ArgumentNullException(typeof(MessageTitle).ToString());
        if (_body is null) throw new ArgumentNullException(typeof(MessageBody).ToString());

        return new UserMessage(_title, _body, _importance, _isRead);
    }
}