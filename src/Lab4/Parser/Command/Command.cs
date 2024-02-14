using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Command;

public class Command
{
    public Command(string name, string entity, IEnumerable<string> args)
    {
        Name = name;
        Args = args;
        Entity = entity;
    }

    public string Name { get; private set; }
    public string Entity { get; private set; }
    public IEnumerable<string> Args { get; private set; }
}