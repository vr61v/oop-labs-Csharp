using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Hdd;

public class HddBuilder : IHddBuilder
{
    private ConnectionSlot? _slot;
    private int _volume;
    private int _workSpeed;
    private int _voltage;

    public HddBuilder WithSlot(ConnectionSlot? slot)
    {
        _slot = slot;
        return this;
    }

    public HddBuilder WithVolume(int volume)
    {
        _volume = volume;
        return this;
    }

    public HddBuilder WithWorkSpeed(int workSpeed)
    {
        _workSpeed = workSpeed;
        return this;
    }

    public HddBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public HddBuilder BaseOn(Storage.Hdd.Hdd? component)
    {
        _slot = component?.Slot;
        _volume = component?.Volume ?? 0;
        _workSpeed = component?.WorkSpeed ?? 0;
        _voltage = component?.Voltage ?? 0;
        return this;
    }

    public Storage.Hdd.Hdd Build()
    {
        return new Storage.Hdd.Hdd(
            _slot,
            _volume,
            _workSpeed,
            _voltage);
    }
}