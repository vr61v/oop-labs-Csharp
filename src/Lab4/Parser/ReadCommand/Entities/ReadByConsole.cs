using System;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.ReadCommand.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ReadCommand.Entities;

public class ReadByConsole : IReadCommand
{
    public string? Read()
    {
        string? command = Console.ReadLine();
        return command;
    }
}