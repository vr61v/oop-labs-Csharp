using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemChain.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.FileSystemChain.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Command;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class FileSystemService
{
    private readonly FileSystem _fileSystem = new FileSystem();

    public void DoCommand(Command? command)
    {
        BaseFileSystemHandler handler = new FileSystemHandler();
        handler.Handle(_fileSystem, command);
    }
}