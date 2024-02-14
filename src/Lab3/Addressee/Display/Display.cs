using System;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Display;

public class Display : IDisplay
{
    public Display(DisplayMessage? message, MessageImportance importance)
    {
        Message = message;
        Importance = importance;
    }

    public MessageImportance Importance { get; set; }
    public DisplayMessage? Message { get; private set; }

    public void TakeMessage(DisplayMessage? message)
    {
        if (message is null)
        {
            Logger.Logger.Instance.WriteLog(LoggerOperation.Take, null, false);
            throw new ArgumentNullException(typeof(UserMessage).ToString());
        }

        if (message.Importance <= Importance)
        {
            Logger.Logger.Instance.WriteLog(LoggerOperation.Take, message, false);
            return;
        }

        Logger.Logger.Instance.WriteLog(LoggerOperation.Take, message, true);
        Message = message;
    }

    public void DrawMessage()
    {
        if (Message is null) throw new ArgumentNullException(typeof(DisplayMessage).ToString());
        string text = Message.ToString();
        var driver = new DisplayDriver.DisplayDriver();

        driver.ClearText();
        driver.SetColorText(Message.Color);
        driver.DrawText(text);
    }
}