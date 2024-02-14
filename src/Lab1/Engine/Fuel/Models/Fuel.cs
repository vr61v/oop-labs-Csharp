namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.Fuel.Models;

public abstract class Fuel
{
    private int _value;

    public int Value
    {
        get => _value;
        set => _value = value >= 0 ? value : 0;
    }
}