using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemChain.Entities;

public class FileSystemHandler : BaseFileSystemHandler
{
    private readonly BaseFileSystemHandler _fileSystemHandlerTree = new FileSystemHandlerTree();
    private readonly BaseFileSystemHandler _fileParserHandlerFile = new FileParserHandlerFile();

    public override void Handle(FileSystem? fileSystem, Command? command)
    {
        if (fileSystem is null || command is null) return;
        switch (command.Name)
        {
            case "connect":
                fileSystem.Connect(command.Args.First());
                break;
            case "disconnect":
                fileSystem.Disconnect();
                break;
        }

        switch (command.Entity)
        {
            case "tree":
                _fileSystemHandlerTree.Handle(fileSystem, command);
                break;
            case "file":
                _fileParserHandlerFile.Handle(fileSystem, command);
                break;
        }
    }
}