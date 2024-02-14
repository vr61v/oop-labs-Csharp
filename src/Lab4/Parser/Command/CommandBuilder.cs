using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Command;

public class CommandBuilder
{
    private string _name = string.Empty;
    private string _entity = string.Empty;
    private IList<string> _args = new List<string>();

    public CommandBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CommandBuilder WithEntity(string entity)
    {
        _entity = entity;
        return this;
    }

    public CommandBuilder AddArg(string arg)
    {
        _args.Add(arg);
        return this;
    }

    public Lab4.Parser.Command.Command? Build()
    {
        return new Lab4.Parser.Command.Command(_name, _entity, _args);
    }
}