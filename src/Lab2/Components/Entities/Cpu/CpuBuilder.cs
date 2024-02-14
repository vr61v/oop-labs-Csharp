using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Cpu;

public class CpuBuilder : ICpuBuilder
{
    private int _coreFrequency;
    private int _coreCount;
    private int _tdp;
    private int _voltage;
    private bool _isGraphicCore;
    private Socket? _socket;
    private IList<int>? _memoryFrequency;

    public CpuBuilder WithCoreFrequency(int coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public CpuBuilder WithCoreCount(int coreCount)
    {
        _coreCount = coreCount;
        return this;
    }

    public CpuBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public CpuBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public CpuBuilder WithIsGraphicCore(bool isGraphicCore)
    {
        _isGraphicCore = isGraphicCore;
        return this;
    }

    public CpuBuilder WithSocket(Socket? socket)
    {
        _socket = socket;
        return this;
    }

    public CpuBuilder WithMemoryFrequency(IList<int>? memoryFrequency)
    {
        _memoryFrequency = memoryFrequency;
        return this;
    }

    public CpuBuilder BaseOn(Cpu? component)
    {
        _coreFrequency = component?.CoreFrequency ?? 0;
        _coreCount = component?.CoreCount ?? 0;
        _tdp = component?.Tdp ?? 0;
        _voltage = component?.Voltage ?? 0;
        _isGraphicCore = component?.IsGraphicCore ?? false;
        _socket = component?.Socket;
        _memoryFrequency = component?.MemoryFrequency;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _coreFrequency,
            _coreCount,
            _tdp,
            _voltage,
            _isGraphicCore,
            _socket,
            _memoryFrequency);
    }
}