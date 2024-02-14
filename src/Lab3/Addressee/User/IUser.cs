using Itmo.ObjectOrientedProgramming.Lab3.Message.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.User;

public interface IUser
{
    public int CountMessages();
    public void ReadAllMessages();
    public void ReadMessage(UserMessage message);
    public void TakeMessage(UserMessage? message);
}