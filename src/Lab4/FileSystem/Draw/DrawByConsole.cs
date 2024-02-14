using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Directory;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Draw;

public class DrawByConsole : IDraw
{
    public void DrawTree(string? root,  int level, int depth, string fileSymbol = "-", string directorySymbol = ">")
    {
        if (level > depth || root is null) return;
        var directoryFacade = new DirectoryBySystemIo();
        var directories = directoryFacade.GetDirectories(root).ToList();

        foreach (string directoryPath in directories)
        {
            string directory = directoryPath.Split('/').Last();
            Console.WriteLine($"{new string('\t', level)}{directorySymbol}{directory}");
            DrawTree(directoryPath, level + 1, depth);
        }

        var files = directoryFacade.GetFiles(root).ToList();
        foreach (string filePath in files)
        {
            string file = filePath.Split('/').Last();
            Console.WriteLine($"{new string('\t', level)}{fileSymbol}{file}");
        }
    }

    public void DrawFile(string text)
    {
        Console.WriteLine(text);
    }
}