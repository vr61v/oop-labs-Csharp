using Itmo.ObjectOrientedProgramming.Lab3.Message.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class MessengerMessageBuilder
{
    private MessageTitle? _title;
    private MessageBody? _body;
    private MessageImportance _importance;

    public MessengerMessageBuilder WithTitle(MessageTitle? title)
    {
        _title = title;
        return this;
    }

    public MessengerMessageBuilder WithBody(MessageBody? body)
    {
        _body = body;
        return this;
    }

    public MessengerMessageBuilder WithImportance(MessageImportance importance)
    {
        _importance = importance;
        return this;
    }

    public MessengerMessage Build()
    {
        return new MessengerMessage(_title, _body, _importance);
    }
}