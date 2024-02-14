using Itmo.ObjectOrientedProgramming.Lab1.Engine.Fuel.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.ImpulseEngine.Entities;

public class ImpulseEngineClassC : ImpulseEngine.Models.ImpulseEngine
{
    private const int DefaultFuelCapacity = 100000;
    private const int DefaultSpeed = 15000;
    private const int DefaultFuelConsumption = 1;
    private const int DefaultStartCost = 10;

    public ImpulseEngineClassC()
        : this(DefaultFuelCapacity) { }

    public ImpulseEngineClassC(int fuelCapacity)
    {
        FuelCapacity = new ActivePlasma(fuelCapacity);
        MaxFuelCapacity = new ActivePlasma(fuelCapacity);
        FuelConsumption = DefaultFuelConsumption;
        StartCost = DefaultStartCost;
        IsStart = false;
    }

    public override int Speed(int time)
    {
        return DefaultSpeed;
    }
}