using System;
using Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver;

public class DisplayDriver : IDrawText, IClearText, ISetColorText
{
    public void DrawText(string text)
    {
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public void ClearText()
    {
        Console.Clear();
    }

    public void SetColorText(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }
}