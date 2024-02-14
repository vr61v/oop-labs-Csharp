namespace Itmo.ObjectOrientedProgramming.Lab1.Result.Entities;

public class RouteResult : Result.Models.Result
{
    private const int DefaultTime = 0;
    private const int DefaultActivePlasmaFuel = 0;
    private const int DefaultGravityMatterFuel = 0;

    public RouteResult(string status)
        : this(DefaultTime, DefaultActivePlasmaFuel, DefaultGravityMatterFuel, status) { }
    public RouteResult(int time, int activePlasmaFuel, int gravityMatterFuel, string status)
    {
        Time = time;
        Fuel = activePlasmaFuel + gravityMatterFuel;
        ActivePlasmaFuel = activePlasmaFuel;
        GravityMatterFuel = gravityMatterFuel;
        Status = status;
    }

    public int ActivePlasmaFuel { get; set; }
    public int GravityMatterFuel { get; set; }
}