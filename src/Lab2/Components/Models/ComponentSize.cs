namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

public class ComponentSize
{
    public ComponentSize(int width, int height, int length)
    {
        Width = width;
        Height = height;
        Length = length;
    }

    public int Width { get; private set; }
    public int Height { get; private set; }
    public int Length { get; private set; }

    public static bool operator <(ComponentSize? component1, ComponentSize? component2)
    {
        return component1 is not null &&
               component2 is not null &&
               component1.Width < component2.Width &&
               component1.Height < component2.Height &&
               component1.Length < component2.Length;
    }

    public static bool operator >(ComponentSize? component1, ComponentSize? component2)
    {
        return component1 is not null &&
               component2 is not null &&
               component1.Width > component2.Width &&
               component1.Height > component2.Height &&
               component1.Length > component2.Length;
    }

    public static bool operator <=(ComponentSize? component1, ComponentSize? component2)
    {
        return component1 is not null &&
               component2 is not null &&
               component1.Width <= component2.Width &&
               component1.Height <= component2.Height &&
               component1.Length <= component2.Length;
    }

    public static bool operator >=(ComponentSize? component1, ComponentSize? component2)
    {
        return component1 is not null &&
               component2 is not null &&
               component1.Width >= component2.Width &&
               component1.Height >= component2.Height &&
               component1.Length >= component2.Length;
    }

    public int CompareTo(ComponentSize other)
    {
        throw new System.NotImplementedException();
    }
}