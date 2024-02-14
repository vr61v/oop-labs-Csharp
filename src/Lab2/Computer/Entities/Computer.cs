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
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;

public class Computer : IComputer
{
    public Computer(Motherboard? motherboard, Cpu? cpu, CoolingSystem? coolingSystem, Gpu? gpu, IList<Ssd>? ssd, IList<Hdd>? hdd, ComputerCase? computerCase, PowerUnit? powerUnit, IList<RamMemory>? ramMemory, WiFiAdapter? wiFiAdapter)
    {
        Motherboard = motherboard;
        Cpu = cpu;
        CoolingSystem = coolingSystem;
        Gpu = gpu;
        Ssd = ssd;
        Hdd = hdd;
        ComputerCase = computerCase;
        PowerUnit = powerUnit;
        RamMemory = ramMemory;
        WiFiAdapter = wiFiAdapter;
    }

    public Motherboard? Motherboard { get; private set; }
    public Cpu? Cpu { get; private set; }
    public CoolingSystem? CoolingSystem { get; private set; }
    public Gpu? Gpu { get; private set; }
    public IList<Ssd>? Ssd { get; private set; }
    public IList<Hdd>? Hdd { get; private set; }
    public ComputerCase? ComputerCase { get; private set; }
    public PowerUnit? PowerUnit { get; private set; }
    public IList<RamMemory>? RamMemory { get; private set; }
    public WiFiAdapter? WiFiAdapter { get; private set; }

    public ComputerInfo GetComputerInfo()
    {
        return new ComputerInfo(
            $"Motherboard: {Motherboard?.Info()}\n\n" +
            $"Cpu: {Cpu?.Info()}\n\n" +
            $"Gpu: {Gpu?.Info()}\n\n" +
            $"Ssd: {Ssd?[0].Info()}\n\n" +
            $"Hdd: {Hdd?[0].Info()}\n\n" +
            $"ComputerCase: {ComputerCase?.Info()}\n\n" +
            $"PowerUnit: {PowerUnit?.Info()}\n\n" +
            $"RamMemory: {RamMemory?[0].Info()}\n\n" +
            $"WiFiAdapter: {WiFiAdapter?.Info()}\n\n");
    }
}