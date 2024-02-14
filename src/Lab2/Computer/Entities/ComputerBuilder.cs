using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Gpu;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.RamMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Storage.Hdd;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Storage.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.WiFiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;

public class ComputerBuilder : IComputerBuilder
{
    private Motherboard? _motherboard;
    private Cpu? _cpu;
    private CoolingSystem? _coolingSystem;
    private Gpu? _gpu;
    private IList<Ssd>? _ssd;
    private IList<Hdd>? _hdd;
    private ComputerCase? _computerCase;
    private PowerUnit? _powerUnit;
    private IList<RamMemory>? _ramMemory;
    private WiFiAdapter? _wiFiAdapter;

    public ComputerBuilder WithMotherboard(Motherboard? motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public ComputerBuilder WithCpu(Cpu? cpu)
    {
        _cpu = cpu;
        return this;
    }

    public ComputerBuilder WithCoolingSystem(CoolingSystem? coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public ComputerBuilder WithGpu(Gpu? gpu)
    {
        _gpu = gpu;
        return this;
    }

    public ComputerBuilder WithSsd(IList<Ssd>? ssd)
    {
        _ssd = ssd;
        return this;
    }

    public ComputerBuilder WithHdd(IList<Hdd>? hdd)
    {
        _hdd = hdd;
        return this;
    }

    public ComputerBuilder WithComputerCase(ComputerCase? computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public ComputerBuilder WithPowerUnit(PowerUnit? powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public ComputerBuilder WithRamMemory(IList<RamMemory>? ramMemory)
    {
        _ramMemory = ramMemory;
        return this;
    }

    public ComputerBuilder WithWiFiAdapter(WiFiAdapter? wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }

    public ComputerBuilder BaseOn(Computer? computer)
    {
        _motherboard = computer?.Motherboard;
        _cpu = computer?.Cpu;
        _coolingSystem = computer?.CoolingSystem;
        _gpu = computer?.Gpu;
        _ssd = computer?.Ssd;
        _hdd = computer?.Hdd;
        _computerCase = computer?.ComputerCase;
        _powerUnit = computer?.PowerUnit;
        _ramMemory = computer?.RamMemory;
        _wiFiAdapter = computer?.WiFiAdapter;
        return this;
    }

    public Computer Build()
    {
        return new Computer(
            _motherboard,
            _cpu,
            _coolingSystem,
            _gpu,
            _ssd,
            _hdd,
            _computerCase,
            _powerUnit,
            _ramMemory,
            _wiFiAdapter);
    }
}