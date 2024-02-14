using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Gpu;

public class GpuBuilder : IGpuBuilder
{
    private int _countMemory;
    private int _coreFrequency;
    private int _voltage;
    private VersionPci? _versionPsi;
    private ComponentSize? _size;

    public GpuBuilder WithCountMemory(int countMemory)
    {
        _countMemory = countMemory;
        return this;
    }

    public GpuBuilder WithCoreFrequency(int coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public GpuBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public GpuBuilder WithVersionPsi(VersionPci? versionPsi)
    {
        _versionPsi = versionPsi;
        return this;
    }

    public GpuBuilder WithSize(ComponentSize? size)
    {
        _size = size;
        return this;
    }

    public GpuBuilder BaseOn(Gpu? component)
    {
        _countMemory = component?.CountMemory ?? 0;
        _coreFrequency = component?.CoreFrequency ?? 0;
        _voltage = component?.Voltage ?? 0;
        _versionPsi = component?.VersionPci;
        _size = component?.Size;
        return this;
    }

    public Gpu Build()
    {
        return new Gpu(
            _countMemory,
            _coreFrequency,
            _voltage,
            _versionPsi,
            _size);
    }
}