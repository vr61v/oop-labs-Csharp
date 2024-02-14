using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Command;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Tests
{
    [Fact]
    public void TestTreeGoTo()
    {
        var fileSystemService = new FileSystemService();
        var parser = new Parser.Parser();

        Command? connectCommand = parser.Parse("connect /Users/vr61v/Desktop/TestC#");
        fileSystemService.DoCommand(connectCommand);
        Command? gotoCommand = parser.Parse("tree goto /платина");
        fileSystemService.DoCommand(gotoCommand);
    }

    [Fact]
    public void TestTreeList()
    {
        var fileSystemService = new FileSystemService();
        var parser = new Parser.Parser();

        Command? connectCommand = parser.Parse("connect /Users/vr61v/Desktop/TestC#");
        fileSystemService.DoCommand(connectCommand);
        Command? list = parser.Parse("tree list 2 test");
        fileSystemService.DoCommand(list);
    }

    [Fact]
    public void TestFileShow()
    {
        var fileSystemService = new FileSystemService();
        var parser = new Parser.Parser();

        Command? connectCommand = parser.Parse("connect /Users/vr61v/Desktop/TestC#");
        fileSystemService.DoCommand(connectCommand);
        Command? fileShowCommand = parser.Parse("file show /платина/бандана.txt test");
        fileSystemService.DoCommand(fileShowCommand);
    }

    [Fact]
    public void TestFileMove()
    {
        var fileSystemService = new FileSystemService();
        var parser = new Parser.Parser();

        Command? connectCommand = parser.Parse("connect /Users/vr61v/Desktop/TestC#");
        fileSystemService.DoCommand(connectCommand);
        Command? fileMoveCommand = parser.Parse("file move /платина/санта_move.txt /иит/санта_move.txt test");
        fileSystemService.DoCommand(fileMoveCommand);
    }

    [Fact]
    public void TestFileCopy()
    {
        var fileSystemService = new FileSystemService();
        var parser = new Parser.Parser();

        Command? connectCommand = parser.Parse("connect /Users/vr61v/Desktop/TestC#");
        fileSystemService.DoCommand(connectCommand);
        Command? fileCopyCommand = parser.Parse("file copy /платина/санта.txt /платина/санта_copy.txt test");
        fileSystemService.DoCommand(fileCopyCommand);
    }

    [Fact]
    public void TestFileDelete()
    {
        var fileSystemService = new FileSystemService();
        var parser = new Parser.Parser();

        Command? connectCommand = parser.Parse("connect /Users/vr61v/Desktop/TestC#");
        fileSystemService.DoCommand(connectCommand);
        Command? fileDeleteCommand = parser.Parse("file delete /платина/бандана_delete.txt test");
        fileSystemService.DoCommand(fileDeleteCommand);
    }

    [Fact]
    public void TestFileRename()
    {
        var fileSystemService = new FileSystemService();
        var parser = new Parser.Parser();

        Command? connectCommand = parser.Parse("connect /Users/vr61v/Desktop/TestC#");
        fileSystemService.DoCommand(connectCommand);
        Command? fileRenameCommand = parser.Parse("file rename /иит/мани_соу_биг_rename.txt money_so_big_.txt test");
        fileSystemService.DoCommand(fileRenameCommand);
    }
}