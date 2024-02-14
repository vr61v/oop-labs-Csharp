using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileByGithubTests : IFile
{
    public string ReadAllText(string path)
    {
        return "I am text";
    }

    public bool Exists(string path)
    {
        return true;
    }

    public void CopyTo(string sourcePath, string destinationPath)
    {
        _ = "I am work";
    }

    public void MoveTo(string sourcePath, string destinationPath)
    {
        _ = "I am work";
    }

    public void Delete(string path)
    {
        _ = "I am work";
    }
}