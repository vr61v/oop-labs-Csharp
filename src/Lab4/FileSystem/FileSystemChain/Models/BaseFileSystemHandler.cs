using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemChain.Models;

public abstract class BaseFileSystemHandler
{
    public abstract void Handle(FileSystem? fileSystem, Command? command);

    protected static string? GetCommandArg(IList<string>? args)
    {
        if (args is null) return null;
        if (args.Count == 0) return null;
        string arg = args.First();
        args.Remove(arg);
        return arg;
    }
}