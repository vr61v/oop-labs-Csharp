namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.File;

public interface IFile
{
    public string ReadAllText(string path);
    public bool Exists(string path);
    public void CopyTo(string sourcePath, string destinationPath);
    public void MoveTo(string sourcePath, string destinationPath);
    public void Delete(string path);
}