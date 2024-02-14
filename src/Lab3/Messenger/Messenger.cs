using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

public class Messenger : IMessenger
{
    public Messenger(IList<MessengerMessage>? massages)
    {
        Massages = massages;
    }

    public IList<MessengerMessage>? Massages { get; private set; }

    public void TakeMassage(MessengerMessage? massage)
    {
        if (massage != null) Massages?.Add(massage);
    }
}