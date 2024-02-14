namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Draw;

public interface IDraw
{
    public void DrawTree(string? root, int level, int depth, string fileSymbol, string directorySymbol);
    public void DrawFile(string text);
}