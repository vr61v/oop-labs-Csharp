using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Group;

public interface IGroup
{
    public void TakeMessage(BaseMessage? message);
}