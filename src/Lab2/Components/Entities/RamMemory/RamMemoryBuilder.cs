using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.RamMemory;

public class RamMemoryBuilder : IRamMemoryBuilder
{
    private int _volume;
    private int _voltage;
    private IList<Jedec>? _availableJedec;
    private Xmp? _availableXmp;
    private TypeDdr? _typeDdr;

    public RamMemoryBuilder WithVolume(int volume)
    {
        _volume = volume;
        return this;
    }

    public RamMemoryBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public RamMemoryBuilder WithAvailableJedec(IList<Jedec>? availableJedec)
    {
        _availableJedec = availableJedec;
        return this;
    }

    public RamMemoryBuilder WithAvailableXmp(Xmp? availableXmp)
    {
        _availableXmp = availableXmp;
        return this;
    }

    public RamMemoryBuilder WithTypeDdr(TypeDdr? typeDdr)
    {
        _typeDdr = typeDdr;
        return this;
    }

    public RamMemoryBuilder BaseOn(RamMemory? component)
    {
        _volume = component?.Volume ?? 0;
        _voltage = component?.Voltage ?? 0;
        _availableJedec = component?.AvailableJedec;
        _availableXmp = component?.AvailableXmp;
        _typeDdr = component?.TypeDdr;
        return this;
    }

    public RamMemory Build()
    {
        return new RamMemory(
            _volume,
            _voltage,
            _availableJedec,
            _availableXmp,
            _typeDdr);
    }
}