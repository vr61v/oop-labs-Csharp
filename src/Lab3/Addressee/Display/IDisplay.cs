using Itmo.ObjectOrientedProgramming.Lab3.Message.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Display;

public interface IDisplay
{
    public void TakeMessage(DisplayMessage? message);
    public void DrawMessage();
}