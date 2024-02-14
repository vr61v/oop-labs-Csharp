using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Tests;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemChain.Entities;

public class FileSystemHandlerTree : BaseFileSystemHandler
{
    public override void Handle(FileSystem? fileSystem, Command? command)
    {
        if (fileSystem is null || command is null) return;

        IList<string> args = command.Args.ToList();
        switch (command.Name)
        {
            case "goto":
            {
                string? path = GetCommandArg(args);
                fileSystem.TreeGoTo(path);
                break;
            }

            case "list":
                if (int.TryParse(GetCommandArg(args), out int depth))
                {
                    if (GetCommandArg(args) == "test")
                    {
                        fileSystem.TreeList(depth, new DrawByGithubTests());
                    }
                    else
                    {
                        fileSystem.TreeList(depth);
                    }
                }
                else
                {
                    if (GetCommandArg(args) == "test")
                    {
                        fileSystem.TreeList(depth, new DrawByGithubTests());
                    }
                    else
                    {
                        fileSystem.TreeList();
                    }
                }

                break;
        }
    }
}