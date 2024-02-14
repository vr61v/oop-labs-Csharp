using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.ParserChain.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class Parser
{
    private readonly ParserHandler _parserHandler = new ParserHandler();

    public Command.Command? Parse(string? command)
    {
        if (command is null) return null;
        var commands = command.Split(' ').ToList();
        var commandBuilder = new CommandBuilder();
        return _parserHandler.Handle(commands, commandBuilder);
    }
}