using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Fuel.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.ImpulseEngine.Entities;

public class ImpulseEngineClassE : ImpulseEngine.Models.ImpulseEngine
{
    private const int DefaultFuelCapacity = 300000;
    private const int DefaultFuelConsumption = 3;
    private const int DefaultStartCost = 30;

    public ImpulseEngineClassE()
        : this(DefaultFuelCapacity) { }

    public ImpulseEngineClassE(int fuelCapacity)
    {
        FuelCapacity = new ActivePlasma(fuelCapacity);
        MaxFuelCapacity = new ActivePlasma(fuelCapacity);
        FuelConsumption = DefaultFuelConsumption;
        StartCost = DefaultStartCost;
        IsStart = false;
    }

    public override int Speed(int time)
    {
        return (int)Math.Exp(time);
    }
}