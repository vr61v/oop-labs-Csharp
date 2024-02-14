using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParserChain.Models;

public abstract class BaseParserHandler
{
    public abstract Command.Command? Handle(IList<string>? commands, CommandBuilder? command);

    protected static void ParseArgs(IList<string>? commands, CommandBuilder? command)
    {
        if (commands is null || command is null) return;
        foreach (string currentCommand in commands)
        {
            if ((currentCommand[0] is '-') && currentCommand is not ("-d" or "-m"))
                throw new ArgumentException("Invalid flag");
            if (currentCommand[0] is not '-')
                command.AddArg(currentCommand);
        }
    }
}