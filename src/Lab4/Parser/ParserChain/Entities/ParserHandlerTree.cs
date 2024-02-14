using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.ParserChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParserChain.Entities;

public class ParserHandlerTree : BaseParserHandler
{
    public override Command.Command? Handle(IList<string>? commands, CommandBuilder? command)
    {
        if (commands is null || command is null) return null;

        string operation = commands.First();
        command.WithName(operation);
        commands.Remove(operation);

        ParseArgs(commands, command);

        return command.Build();
    }
}