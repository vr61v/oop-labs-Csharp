using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Fuel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngine.Entities;

public class JumpEngineGamma : Models.JumpEngine
{
    private const int DefaultFuelCapacity = 50000;
    private const int DefaultSpeed = 100000;

    public JumpEngineGamma()
        : this(DefaultFuelCapacity) { }

    public JumpEngineGamma(int fuelCapacity)
    {
        FuelCapacity = new GravityMatter(fuelCapacity);
        Speed = DefaultSpeed;
    }

    public override GravityMatter FuelConsumption(int time)
    {
        return new GravityMatter((int)Math.Pow(time, 2));
    }
}