using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topic;

public class Topic : ITopic
{
    public Topic(string title, IAddressee addressee)
    {
        Title = title;
        Addressee = addressee;
    }

    public string Title { get; private set; }
    private IAddressee Addressee { get; set; }

    public void SendMassage(BaseMessage? message)
    {
        Logger.Logger.Instance.WriteLog(LoggerOperation.Send, message ?? null, true);
        Addressee.TakeMessage(message);
    }
}