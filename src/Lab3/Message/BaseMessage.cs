using Itmo.ObjectOrientedProgramming.Lab3.Message.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public abstract class BaseMessage
{
    public MessageTitle? Title { get; protected set; }
    public MessageBody? Body { get; protected set; }
    public MessageImportance Importance { get; protected set; }
}