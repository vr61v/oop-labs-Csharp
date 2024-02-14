using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class DirectoryByGithubTests : IDirectory
{
    public bool Exists(string path)
    {
        return true;
    }

    public IEnumerable<string> GetFiles(string path)
    {
        var files = new List<string> { "I am files" };
        return files;
    }

    public string[] GetDirectories(string path)
    {
        string[] derictory = { "I", "am", "derictory" };
        return derictory;
    }
}