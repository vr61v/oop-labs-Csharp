using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.PowerUnit;

public class PowerUnit : IComponent
{
    public PowerUnit(int maximumVoltage)
    {
        MaximumVoltage = maximumVoltage;
    }

    public int MaximumVoltage { get; private set; }
    public ComponentType ComponentType()
    {
        return Models.ComponentType.PowerUnit;
    }

    public ComponentInfo Info()
    {
        return new ComponentInfo(
            $"\nPOWER UNIT INFO:\n" +
            $"\tMaximum voltage: {MaximumVoltage}W\n");
    }
}