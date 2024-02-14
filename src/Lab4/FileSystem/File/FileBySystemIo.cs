using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.File;

public class FileBySystemIo : IFile
{
    public string ReadAllText(string path)
    {
        return System.IO.File.ReadAllText(path);
    }

    public bool Exists(string path)
    {
        return System.IO.File.Exists(path);
    }

    public void CopyTo(string sourcePath, string destinationPath)
    {
        var file = new FileInfo(sourcePath);
        file.CopyTo(destinationPath);
    }

    public void MoveTo(string sourcePath, string destinationPath)
    {
        var file = new FileInfo(sourcePath);
        file.MoveTo(destinationPath);
    }

    public void Delete(string path)
    {
        System.IO.File.Delete(path);
    }
}