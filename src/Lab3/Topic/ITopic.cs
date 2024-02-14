using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public interface ITopic
{
    public void SendMassage(BaseMessage? message);
}