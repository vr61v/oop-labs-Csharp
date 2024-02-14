using Itmo.ObjectOrientedProgramming.Lab1.Engine.Fuel.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.ImpulseEngine.Models;

public abstract class ImpulseEngine
{
    public int FuelConsumption { get; protected init; }
    protected ActivePlasma? FuelCapacity { get; set; }
    protected ActivePlasma? MaxFuelCapacity { get; init; }
    protected int StartCost { get; init; }
    protected bool IsStart { get; set; }

    public void StartEngine()
    {
        if (FuelCapacity is null) return;

        if (IsStart) return;
        FuelCapacity.Value -= StartCost;
        IsStart = true;
    }

    public void StopEngine()
    {
        if (!IsStart) return;
        IsStart = false;
    }

    public void Refuel(int fuelCapacity)
    {
        if (FuelCapacity is null || MaxFuelCapacity is null) return;

        if (FuelCapacity.Value + fuelCapacity > MaxFuelCapacity.Value) FuelCapacity = MaxFuelCapacity;
        else FuelCapacity.Value += fuelCapacity;
    }

    public abstract int Speed(int time);
}