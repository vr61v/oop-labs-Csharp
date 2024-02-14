namespace Itmo.ObjectOrientedProgramming.Lab1.Result.Entities;

public class PathResult : Models.Result
{
    private const int DefaultTime = 0;
    private const int DefaultFuel = 0;

    public PathResult(string status)
        : this(DefaultTime, DefaultFuel, status) { }

    public PathResult(int time, int fuel, string status)
    {
        Time = time;
        Fuel = fuel;
        Status = status;
    }
}