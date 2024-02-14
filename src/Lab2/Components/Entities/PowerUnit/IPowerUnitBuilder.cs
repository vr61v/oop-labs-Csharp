namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.PowerUnit;

public interface IPowerUnitBuilder
{
    public PowerUnitBuilder WithMaximumVoltage(int maximumVoltage);
    public PowerUnitBuilder BaseOn(PowerUnit? component);
    public PowerUnit Build();
}