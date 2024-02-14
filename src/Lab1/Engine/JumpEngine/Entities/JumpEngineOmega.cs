using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Fuel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngine.Entities;

public class JumpEngineOmega : Models.JumpEngine
{
    private const int DefaultFuelCapacity = 30000;
    private const int DefaultSpeed = 50000;

    public JumpEngineOmega()
        : this(DefaultFuelCapacity) { }

    public JumpEngineOmega(int fuelCapacity)
    {
        FuelCapacity = new GravityMatter(fuelCapacity);
        Speed = DefaultSpeed;
    }

    public override GravityMatter FuelConsumption(int time)
    {
        return new GravityMatter((int)Math.Log(time));
    }
}