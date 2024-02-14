using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Draw;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Command;
using Itmo.ObjectOrientedProgramming.Lab4.Tests;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemChain.Entities;

public class FileParserHandlerFile : BaseFileSystemHandler
{
    public override void Handle(FileSystem? fileSystem, Command? command)
    {
        if (fileSystem is null || command is null) return;

        IList<string> args = command.Args.ToList();
        switch (command.Name)
        {
            case "show":
            {
                string? path = GetCommandArg(args);
                string? mode = GetCommandArg(args);
                if (mode is null or "console")
                    fileSystem.ShowFile(path);
                else
                    fileSystem.ShowFile(path, new FileByGithubTests(), new DrawByConsole());
                break;
            }

            case "move":
            {
                string? sourcePath = GetCommandArg(args);
                string? destinationPath = GetCommandArg(args);
                string? mode = GetCommandArg(args);
                if (mode is null or "console")
                    fileSystem.MoveFile(sourcePath, destinationPath);
                else
                    fileSystem.MoveFile(sourcePath, destinationPath, new FileByGithubTests());
                break;
            }

            case "copy":
            {
                string? sourcePath = GetCommandArg(args);
                string? destinationPath = GetCommandArg(args);
                string? mode = GetCommandArg(args);
                if (mode is null or "console")
                    fileSystem.CopyFile(sourcePath, destinationPath);
                else
                    fileSystem.CopyFile(sourcePath, destinationPath, new FileByGithubTests());
                break;
            }

            case "delete":
            {
                string? path = GetCommandArg(args);
                string? mode = GetCommandArg(args);
                if (mode is null or "console")
                    fileSystem.DeleteFile(path);
                else
                    fileSystem.DeleteFile(path, new FileByGithubTests());
                break;
            }

            case "rename":
            {
                string? path = GetCommandArg(args);
                string? name = GetCommandArg(args);
                string? mode = GetCommandArg(args);
                if (mode is null or "console")
                    fileSystem.RenameFile(path, name);
                else
                    fileSystem.RenameFile(path, name, new FileByGithubTests());
                break;
            }
        }
    }
}