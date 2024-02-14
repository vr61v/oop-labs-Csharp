using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Directory;

public interface IDirectory
{
    public bool Exists(string path);
    public IEnumerable<string> GetFiles(string path);
    public string[] GetDirectories(string path);
}