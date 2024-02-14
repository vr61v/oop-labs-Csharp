using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Entities.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Adapters;

public class DisplayAdapter : IAddressee
{
    private readonly IDisplay _display;

    public DisplayAdapter(IDisplay display)
    {
        _display = display;
    }

    public void TakeMessage(BaseMessage? message)
    {
        if (message is null)
        {
            Logger.Logger.Instance.WriteLog(LoggerOperation.Take, null, false);
            throw new ArgumentNullException(typeof(BaseMessage).ToString());
        }

        if (message is DisplayMessage displayMessage1)
        {
            _display.TakeMessage(displayMessage1);
            return;
        }

        DisplayMessage? displayMessage = new DisplayMessageBuilder()
            .WithTitle(message.Title)
            .WithBody(message.Body)
            .WithImportance(message.Importance)
            .WithColor(ConsoleColor.White)
            .Build();
        _display.TakeMessage(displayMessage);
    }
}