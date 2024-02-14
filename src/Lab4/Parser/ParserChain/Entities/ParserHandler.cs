using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.ParserChain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.ParserChain.Entities;

public class ParserHandler : BaseParserHandler
{
    private readonly BaseParserHandler _parserTreeHandler = new ParserHandlerTree();
    private readonly BaseParserHandler _parserFileHandler = new ParserHandlerFile();

    public override Command.Command? Handle(IList<string>? commands, CommandBuilder? command)
    {
        if (commands is null || command is null) return null;
        switch (commands[0])
        {
            case "connect":
                command.WithName("connect");
                commands.Remove("connect");
                ParseArgs(commands, command);
                return command.Build();
            case "disconnect":
                command.WithName("disconnect");
                commands.Remove("disconnect");
                ParseArgs(commands, command);
                return command.Build();
            case "tree":
                command.WithEntity("tree");
                commands.Remove("tree");
                return _parserTreeHandler.Handle(commands, command);
            case "file":
                command.WithEntity("file");
                commands.Remove("file");
                return _parserFileHandler.Handle(commands, command);
        }

        return null;
    }
}