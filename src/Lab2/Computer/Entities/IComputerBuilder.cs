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

public interface IComputerBuilder
{
    public ComputerBuilder WithMotherboard(Motherboard? motherboard);
    public ComputerBuilder WithCpu(Cpu? cpu);
    public ComputerBuilder WithCoolingSystem(CoolingSystem? coolingSystem);
    public ComputerBuilder WithGpu(Gpu? gpu);
    public ComputerBuilder WithSsd(IList<Ssd>? ssd);
    public ComputerBuilder WithHdd(IList<Hdd>? hdd);
    public ComputerBuilder WithComputerCase(ComputerCase? computerCase);
    public ComputerBuilder WithPowerUnit(PowerUnit? powerUnit);
    public ComputerBuilder WithRamMemory(IList<RamMemory>? ramMemory);
    public ComputerBuilder WithWiFiAdapter(WiFiAdapter? wiFiAdapter);

    public ComputerBuilder BaseOn(Computer? computer);
    public Computer Build();
}