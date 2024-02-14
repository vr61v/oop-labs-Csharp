namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.PowerUnit;

public class PowerUnitBuilder : IPowerUnitBuilder
{
    private int _maximumVoltage;
    public PowerUnitBuilder WithMaximumVoltage(int maximumVoltage)
    {
        _maximumVoltage = maximumVoltage;
        return this;
    }

    public PowerUnitBuilder BaseOn(PowerUnit? component)
    {
        _maximumVoltage = component?.MaximumVoltage ?? 0;
        return this;
    }

    public PowerUnit Build()
    {
        return new PowerUnit(
            _maximumVoltage);
    }
}