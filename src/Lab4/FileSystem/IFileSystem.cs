using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Draw;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    public void Connect(string? address);
    public void Disconnect();
    public void TreeGoTo(string? path);
    public void TreeList(int depth, IDraw? draw, string fileSymbol = "-", string directorySymbol = ">");
    public void ShowFile(string? path, IFile? file,  IDraw? draw);
    public void MoveFile(string? sourcePath, string? destinationPath, IFile? file);
    public void CopyFile(string? sourcePath, string? destinationPath, IFile? file);
    public void DeleteFile(string? path, IFile? file);
    public void RenameFile(string? path, string? name, IFile? file);
}