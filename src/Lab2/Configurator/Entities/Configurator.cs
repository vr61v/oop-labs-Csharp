using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
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
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Configurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Configurator.Entities;

public class Configurator : IConfigurator
{
    private Motherboard? _configureMotherboard;
    private Cpu? _configureCpu;
    private CoolingSystem? _configureCoolingSystem;
    private IList<RamMemory>? _configureRamMemory;
    private Gpu? _configureGpu;
    private WiFiAdapter? _configureWiFiAdapter;
    private IList<Ssd>? _configureSsd;
    private IList<Hdd>? _configureHdd;
    private ComputerCase? _configureComputerCase;
    private PowerUnit? _configurePowerUnit;

    public Computer.Entities.Computer Configure(Computer.Entities.Computer? computer)
    {
        if (computer is null) return new ComputerBuilder().Build();

        var newComputer = new ComputerBuilder();
        Repository.Entities.Repository repository = Repository.Entities.Repository.Instance;
        _configureMotherboard = computer.Motherboard;
        _configureCpu = computer.Cpu;
        _configureCoolingSystem = computer.CoolingSystem;
        _configureRamMemory = computer.RamMemory;
        _configureGpu = computer.Gpu;
        _configureWiFiAdapter = computer.WiFiAdapter;
        _configureSsd = computer.Ssd;
        _configureHdd = computer.Hdd;
        _configureComputerCase = computer.ComputerCase;
        _configurePowerUnit = computer.PowerUnit;

        _configureMotherboard = ConfigureMotherboard(repository.GetCurrentTypeData(ComponentType.Motherboard)?.ToList());
        _configureCpu = ConfigureCpu(repository.GetCurrentTypeData(ComponentType.Cpu)?.ToList());
        _configureCoolingSystem = ConfigureCoolingSystem(repository.GetCurrentTypeData(ComponentType.CoolingSystem)?.ToList());

        _configureRamMemory = ConfigureRamMemory(repository.GetCurrentTypeData(ComponentType.RamMemory)?.ToList());

        _configureGpu = ConfigureGpu(repository.GetCurrentTypeData(ComponentType.Gpu)?.ToList());
        _configureWiFiAdapter = ConfigureWiFiAdapter(repository.GetCurrentTypeData(ComponentType.WiFiAdapter)?.ToList());

        _configureSsd = ConfigureSsd(repository.GetCurrentTypeData(ComponentType.Ssd)?.ToList());
        _configureHdd = ConfigureHdd(repository.GetCurrentTypeData(ComponentType.Hdd)?.ToList());

        _configureComputerCase = ConfigureComputerCase(repository.GetCurrentTypeData(ComponentType.ComputerCase)?.ToList());
        _configurePowerUnit = ConfigurePowerUnit(repository.GetCurrentTypeData(ComponentType.PowerUnit)?.ToList());

        Computer.Entities.Computer computerBuild = newComputer
            .WithMotherboard(_configureMotherboard)
            .WithCpu(_configureCpu)
            .WithCoolingSystem(_configureCoolingSystem)
            .WithRamMemory(_configureRamMemory)
            .WithGpu(_configureGpu)
            .WithWiFiAdapter(_configureWiFiAdapter)
            .WithSsd(_configureSsd)
            .WithHdd(_configureHdd)
            .WithComputerCase(_configureComputerCase)
            .WithPowerUnit(_configurePowerUnit)
            .Build();

        return computerBuild;
    }

    public ConfigureResult Validation(Computer.Entities.Computer? computer)
    {
        if (computer is null) return new ConfigureResult(null, false, "Computer is null", false);
        ComputerInfo computerInfo = computer.GetComputerInfo();
        bool isResultSuccess = !(computer.Motherboard is null || computer.Cpu is null ||
                                computer.CoolingSystem is null ||
                                computer.RamMemory is null || (computer.Gpu is null && !computer.Cpu.IsGraphicCore) ||
                                computer.WiFiAdapter is null || (computer.Hdd is null && computer.Ssd is null) ||
                                computer.ComputerCase is null || computer.PowerUnit is null);

        bool isPowerUnitLimit = computer.PowerUnit?.MaximumVoltage < CalculateComputerVoltage();
        bool isCoolingSystemLimit = computer.CoolingSystem?.LimitTdp < computer.Cpu?.Tdp;
        string comment = string.Empty;
        if (isPowerUnitLimit) comment += "The computer's power unit is fire!\n";
        if (isCoolingSystemLimit) comment += "The computer's cpu is fire!\n";

        bool isWarranty = !(isPowerUnitLimit || isCoolingSystemLimit);

        return new ConfigureResult(computerInfo, isResultSuccess, comment, isWarranty);
    }

    private Motherboard? ConfigureMotherboard(IList<IComponent>? motherboards)
    {
        if (motherboards is null) return null;
        if (_configureMotherboard is not null) return _configureMotherboard;

        var result = new List<Motherboard>() { };
        result.AddRange(motherboards.Cast<Motherboard>());

        if (_configureCpu is not null)
        {
            result = result.Where(x => x.Socket == _configureCpu.Socket).ToList();
        }

        if (_configureComputerCase?.AvailableFromFactor != null)
        {
            result = result.Where(x => _configureComputerCase.AvailableFromFactor.Contains(x.FormFactor)).ToList();
        }

        if (_configureRamMemory is not null)
        {
            TypeDdr? typeDdr = _configureRamMemory[0].TypeDdr;
            int countDdr = _configureRamMemory.Count;
            result = result.Where(x => x.TypeDdr == typeDdr && x.CountDdr == countDdr).ToList();
        }

        int countPci = 0;
        int countSata = 0;
        if (_configureHdd is not null)
        {
            foreach (Hdd hdd in _configureHdd)
            {
                if (hdd.Slot == ConnectionSlot.Pci) countPci += 1;
                else countSata += 1;
            }
        }

        if (_configureSsd is not null)
        {
            foreach (Ssd ssd in _configureSsd)
            {
                if (ssd.Slot == ConnectionSlot.Pci) countPci += 1;
                else countSata += 1;
            }
        }

        if (_configureGpu is not null)
        {
            countPci += 1;
        }

        result = result.Where(x => x.CountSata >= countSata && x.CountPci >= countPci).ToList();

        return result.Count > 0 ? result[0] : null;
    }

    private Cpu? ConfigureCpu(IList<IComponent>? cpus)
    {
        if (_configureCpu is not null) return _configureCpu;
        if (cpus is null) return null;

        var result = new List<Cpu>() { };
        result.AddRange(cpus.Cast<Cpu>());

        if (_configureMotherboard is not null)
        {
            result = result.Where(x => x.Socket == _configureMotherboard.Socket).ToList();
        }

        if (_configureGpu is not null)
        {
            result = result.Where(x => !x.IsGraphicCore).ToList();
        }

        if (_configureCoolingSystem is not null)
        {
            result = result.Where(x => x.Tdp < _configureCoolingSystem.LimitTdp).ToList();
        }

        if (_configureRamMemory is not null)
        {
            const int maxFrequency = 10000;
            RamMemory? ramMemory = _configureRamMemory.MinBy(x => x.AvailableXmp?.Frequency ?? maxFrequency);
            result = result.Where(x => CompareRamMemoryAndCpu(ramMemory, x)).ToList();
        }

        return result.Count > 0 ? result[0] : null;
    }

    private CoolingSystem? ConfigureCoolingSystem(IList<IComponent>? coolingSystems)
    {
        if (_configureCoolingSystem is not null) return _configureCoolingSystem;
        if (coolingSystems is null) return null;

        var result = new List<CoolingSystem>() { };
        result.AddRange(coolingSystems.Cast<CoolingSystem>());

        if (_configureMotherboard is not null)
        {
            result = result.Where(x =>
                x.AvailableSocket != null &&
                x.AvailableSocket.Contains(_configureMotherboard.Socket)).ToList();
        }

        if (_configureCpu is not null)
        {
            result = result.Where(x => x.LimitTdp >= _configureCpu.Tdp - 20).ToList();
            result = result.Where(x =>
                x.AvailableSocket != null &&
                x.AvailableSocket.Contains(_configureCpu.Socket)).ToList();
        }

        if (_configureComputerCase is not null)
        {
            result = result.Where(x => x.Size?.Height <= _configureComputerCase?.Size?.Width).ToList();
        }

        return result.Count > 0 ? result[0] : null;
    }

    private Gpu? ConfigureGpu(IList<IComponent>? gpus)
    {
        if (_configureGpu is not null) return _configureGpu;
        if (_configureCpu?.IsGraphicCore ?? false) return null;
        if (gpus is null) return null;

        var result = new List<Gpu>() { };
        result.AddRange(gpus.Cast<Gpu>());

        if (_configureComputerCase is not null)
        {
            result = result.Where(x => x.Size <= _configureComputerCase.MaximumSizeGpu).ToList();
        }

        return result.Count > 0 ? result[0] : null;
    }

    private IList<Ssd>? ConfigureSsd(IList<IComponent>? ssds)
    {
        if (_configureSsd is not null) return _configureSsd;
        if (ssds is null) return null;

        var result = new List<Ssd>() { };
        result.AddRange(ssds.Cast<Ssd>());

        bool isFreeSata = false;
        if (_configureHdd is not null)
        {
            int countHdd = _configureHdd.Count;
            if (_configureMotherboard?.CountSata > countHdd) isFreeSata = true;
        }
        else if (_configureMotherboard?.CountSata > 0)
        {
            isFreeSata = true;
        }

        if (isFreeSata)
        {
            Ssd? firstSsdSata = result.Find(x => x.Slot == ConnectionSlot.Sata);
            if (firstSsdSata != null) return new List<Ssd>() { firstSsdSata };
        }

        Ssd? firstSsdPci = result.Find(x => x.Slot == ConnectionSlot.Pci);
        return firstSsdPci is not null ? new List<Ssd>() { firstSsdPci } : null;
    }

    private IList<Hdd>? ConfigureHdd(IList<IComponent>? hdds)
    {
        if (_configureHdd is not null) return _configureHdd;
        if (hdds is null) return null;

        var result = new List<Hdd>() { };
        result.AddRange(hdds.Cast<Hdd>());

        bool isFreeSata = false;
        if (_configureSsd != null)
        {
            int countSataSdd = _configureSsd.Where(x => x.Slot == ConnectionSlot.Sata).ToList().Count;
            if (_configureMotherboard?.CountSata > countSataSdd) isFreeSata = true;
        }
        else if (_configureMotherboard?.CountSata > 0)
        {
            isFreeSata = true;
        }

        return isFreeSata ? new List<Hdd>() { result[0] } : null;
    }

    private ComputerCase? ConfigureComputerCase(IList<IComponent>? computerCases)
    {
        if (_configureComputerCase is not null) return _configureComputerCase;
        if (computerCases is null) return null;

        var result = new List<ComputerCase>() { };
        result.AddRange(computerCases.Cast<ComputerCase>());

        if (_configureMotherboard is not null)
        {
            result = result.Where(x =>
                x.AvailableFromFactor != null &&
                x.AvailableFromFactor
                    .Contains(_configureMotherboard.FormFactor)).ToList();
        }

        if (_configureGpu is not null)
        {
            result = result.Where(x => _configureGpu.Size <= x.MaximumSizeGpu).ToList();
        }

        if (_configureCoolingSystem is not null)
        {
            result = result.Where(x => _configureCoolingSystem?.Size?.Height <= x.Size?.Height).ToList();
        }

        return result.Count > 0 ? result[0] : null;
    }

    private IList<RamMemory>? ConfigureRamMemory(IList<IComponent>? ramMemories)
    {
        if (_configureRamMemory is not null) return _configureRamMemory;
        if (ramMemories is null) return null;

        var result = new List<RamMemory>() { };
        result.AddRange(ramMemories.Cast<RamMemory>());

        if (_configureMotherboard is not null)
        {
            result = result.Where(x => x.TypeDdr == _configureMotherboard.TypeDdr).ToList();
        }

        if (_configureCpu is not null)
        {
            result = result.Where(x => CompareRamMemoryAndCpu(x, _configureCpu)).ToList();
        }

        if (_configureMotherboard?.CountDdr is not null && _configureMotherboard.CountDdr >= result.Count && result.Count > 0)
        {
            return new List<RamMemory>() { result[0] };
        }

        return null;
    }

    private WiFiAdapter? ConfigureWiFiAdapter(IList<IComponent>? wiFiAdapters)
    {
        if (_configureWiFiAdapter is not null) return _configureWiFiAdapter;
        if (wiFiAdapters is null) return null;

        var result = new List<WiFiAdapter>() { };
        result.AddRange(wiFiAdapters.Cast<WiFiAdapter>());

        bool isFreePci = _configureMotherboard is not null &&
                         ((_configureGpu is not null && _configureMotherboard.CountPci > 1) ||
                          (_configureGpu is null && _configureMotherboard.CountPci > 0));
        if (isFreePci) return result.Count > 0 ? result[0] : null;

        return null;
    }

    private PowerUnit? ConfigurePowerUnit(IList<IComponent>? powerUnits)
    {
        if (_configurePowerUnit is not null) return _configurePowerUnit;
        if (powerUnits is null) return null;

        var result = new List<PowerUnit>() { };
        result.AddRange(powerUnits.Cast<PowerUnit>());
        int computerVoltage = CalculateComputerVoltage();

        result = result.Where(x => x.MaximumVoltage + 100 >= computerVoltage).ToList();
        return result.Count > 0 ? result[0] : null;
    }

    private bool CompareRamMemoryAndCpu(RamMemory? ramMemory, Cpu? cpu)
    {
        _ = _configureMotherboard;
        if (ramMemory?.AvailableXmp?.Frequency is null || cpu?.MemoryFrequency is null) return false;
        int minimumFrequencyRam = ramMemory.AvailableXmp.Frequency;
        int minimumFrequencyCpu = cpu.MemoryFrequency.Max();
        return minimumFrequencyCpu >= minimumFrequencyRam;
    }

    private int CalculateComputerVoltage()
    {
        int cpuVoltage = _configureCpu?.Voltage ?? 0;
        int gpuVoltage = _configureGpu?.Voltage ?? 0;
        int ssdVoltage = _configureSsd?.Sum(x => x.Voltage) ?? 0;
        int hddVoltage = _configureHdd?.Sum(x => x.Voltage) ?? 0;
        int ramVoltage = _configureRamMemory?.Sum(x => x.Voltage) ?? 0;
        int wifiVoltage = _configureWiFiAdapter?.Voltage ?? 0;
        return cpuVoltage + gpuVoltage + ssdVoltage + hddVoltage + ramVoltage + wifiVoltage;
    }
}