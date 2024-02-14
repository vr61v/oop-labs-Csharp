using Itmo.ObjectOrientedProgramming.Lab1.Engine.Fuel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngine.Entities;

public class JumpEngineAlpha : Models.JumpEngine
{
    private const int DefaultFuelCapacity = 20000;
    private const int DefaultSpeed = 25000;

    public JumpEngineAlpha()
        : this(DefaultFuelCapacity) { }

    public JumpEngineAlpha(int fuelCapacity)
    {
        FuelCapacity = new GravityMatter(fuelCapacity);
        Speed = DefaultSpeed;
    }

    public override GravityMatter FuelConsumption(int time)
    {
        return new GravityMatter(time);
    }
}