using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Draw;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class FileSystem : IFileSystem
{
    private const int DefaultDepth = 0;
    private const int FirstLevelTree = 0;
    private string? _root;

    public FileSystem()
        : this(string.Empty) { }

    public FileSystem(string root) { _root = root; }

    public void Connect(string? address) { _root = address; }

    public void Disconnect() { _root = string.Empty; }

    public void TreeGoTo(string? path) { _root = AbsolutePath(path); }

    public void TreeList(int depth = DefaultDepth, IDraw? draw = null, string fileSymbol = "-", string directorySymbol = ">")
    {
        draw ??= new DrawByConsole();
        draw.DrawTree(_root, FirstLevelTree, depth, fileSymbol, directorySymbol);
    }

    public void ShowFile(string? path, IFile? file = null, IDraw? draw = null)
    {
        if (path is null) return;

        string filePath = AbsolutePath(path);

        file ??= new FileBySystemIo();
        string fileText = file.ReadAllText(filePath);

        draw ??= new DrawByConsole();
        draw.DrawFile(fileText);
    }

    public void MoveFile(string? sourcePath, string? destinationPath, IFile? file = null)
    {
        if (sourcePath is null || destinationPath is null) return;

        string fileSourcePath = AbsolutePath(sourcePath);
        string fileDestinationPath = AbsolutePath(destinationPath);

        file ??= new FileBySystemIo();
        file.MoveTo(fileSourcePath, fileDestinationPath);
    }

    public void CopyFile(string? sourcePath, string? destinationPath, IFile? file = null)
    {
        if (sourcePath is null || destinationPath is null) return;

        string fileSourcePath = AbsolutePath(sourcePath);
        string fileDestinationPath = AbsolutePath(destinationPath);

        file ??= new FileBySystemIo();
        file.CopyTo(fileSourcePath, fileDestinationPath);
    }

    public void DeleteFile(string? path, IFile? file = null)
    {
        if (path is null) return;

        string filePath = AbsolutePath(path);
        file ??= new FileBySystemIo();
        file.Delete(filePath);
    }

    public void RenameFile(string? path, string? name, IFile? file = null)
    {
        if (path is null || name is null) return;

        var splitPath = path.Split('/').ToList();
        splitPath.RemoveAt(splitPath.Count - 1);
        splitPath.Add(name);

        string fileSourcePath = AbsolutePath(path);
        string fileDestinationPath = AbsolutePath(string.Join('/', splitPath));
        if (fileSourcePath == fileDestinationPath) return;

        file ??= new FileBySystemIo();
        file.CopyTo(fileSourcePath, fileDestinationPath);
        file.Delete(fileSourcePath);
    }

    private string AbsolutePath(string? path)
    {
        if (path is null || path.Length <= 0) return string.Empty;
        return path.IndexOf("/User", StringComparison.Ordinal) != 0 ? $"{_root}{path}" : path;
    }
}