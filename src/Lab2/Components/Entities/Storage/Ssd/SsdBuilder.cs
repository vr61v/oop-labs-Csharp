using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Ssd;

public class SsdBuilder
{
    private ConnectionSlot? _slot;
    private int _volume;
    private int _workSpeed;
    private int _voltage;

    public SsdBuilder WithSlot(ConnectionSlot? slot)
    {
        _slot = slot;
        return this;
    }

    public SsdBuilder WithVolume(int volume)
    {
        _volume = volume;
        return this;
    }

    public SsdBuilder WithWorkSpeed(int workSpeed)
    {
        _workSpeed = workSpeed;
        return this;
    }

    public SsdBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public SsdBuilder BaseOn(Storage.Ssd.Ssd? component)
    {
        _slot = component?.Slot;
        _volume = component?.Volume ?? 0;
        _workSpeed = component?.WorkSpeed ?? 0;
        _voltage = component?.Voltage ?? 0;
        return this;
    }

    public Storage.Ssd.Ssd Build()
    {
        return new Storage.Ssd.Ssd(
            _slot,
            _volume,
            _workSpeed,
            _voltage);
    }
}