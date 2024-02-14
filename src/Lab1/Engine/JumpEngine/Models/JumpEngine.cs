using Itmo.ObjectOrientedProgramming.Lab1.Engine.Fuel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngine.Models;

public abstract class JumpEngine
{
    public GravityMatter? FuelCapacity { get; protected init; }
    public int Speed { get; protected init; }

    public abstract GravityMatter FuelConsumption(int time);
}