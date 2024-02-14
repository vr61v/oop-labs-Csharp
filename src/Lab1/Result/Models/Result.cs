namespace Itmo.ObjectOrientedProgramming.Lab1.Result.Models;

public abstract class Result
{
    public string? Status { get; set; }
    public int Time { get; set; }
    public int Fuel { get; set; }
}