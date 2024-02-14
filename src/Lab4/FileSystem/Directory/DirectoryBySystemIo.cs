using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Directory;

public class DirectoryBySystemIo : IDirectory
{
    public bool Exists(string path)
    {
        return System.IO.Directory.Exists(path);
    }

    public IEnumerable<string> GetFiles(string path)
    {
        return System.IO.Directory.GetFiles(path);
    }

    public string[] GetDirectories(string path)
    {
        return System.IO.Directory.GetDirectories(path);
    }
}