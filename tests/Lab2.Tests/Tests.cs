using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.ComputerCase;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Gpu;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Hdd;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.RamMemory;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Storage.Hdd;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Storage.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Computer.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Configurator.Models;
using Xunit;
using Xunit.Abstractions;
using Socket = Itmo.ObjectOrientedProgramming.Lab2.Components.Models.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Tests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void SuccessSetup()
    {
        // Arrange
        Repository.Entities.Repository repository = Repository.Entities.Repository.Instance;
        repository.Clear();

        // CPU
        const Socket cpuSocket = Socket.Amuda4;
        const int cpuVoltage = 65;
        const int cpuTdp = 65;
        const int cpuCoreCount = 6;
        const int cpuCoreFrequency = 3900;
        const bool cpuGraphicCore = true;
        var cpuMemoryFrequency = new List<int>() { 3600 };
        Cpu amdCpu = new CpuBuilder()
            .WithSocket(cpuSocket)
            .WithVoltage(cpuVoltage)
            .WithTdp(cpuTdp)
            .WithCoreCount(cpuCoreCount)
            .WithCoreFrequency(cpuCoreFrequency)
            .WithIsGraphicCore(cpuGraphicCore)
            .WithMemoryFrequency(cpuMemoryFrequency)
            .Build();

        // GPU
        const int gpuVoltage = 170;
        const int gpuCoreFrequency = 1837;
        const int gpuCountMemory = 12000;
        const VersionPci gpuVersionPci = VersionPci.PciX;
        var sizeGpu = new ComponentSize(41, 117, 282);

        Gpu nVidiaGpu = new GpuBuilder()
            .WithVoltage(gpuVoltage)
            .WithCoreFrequency(gpuCoreFrequency)
            .WithCountMemory(gpuCountMemory)
            .WithVersionPsi(gpuVersionPci)
            .WithSize(sizeGpu)
            .Build();

        // Ram memory
        const int ramVolume = 16000;
        const int ramFrequency = 3600;
        const int ramVoltage = 1;
        const TypeDdr ramTypeDdr = TypeDdr.Ddr4;
        var ramLatency = new Latency(19, 23, 23, 23);
        var ramXmp = new Xmp(ramLatency,  ramVoltage, ramFrequency);
        var ramJedec = new List<Jedec>() { new Jedec(ramFrequency, ramVoltage) };

        RamMemory hyperXRamMemory = new RamMemoryBuilder()
            .WithVolume(ramVolume)
            .WithVoltage(ramVoltage)
            .WithAvailableXmp(ramXmp)
            .WithAvailableJedec(ramJedec)
            .WithTypeDdr(ramTypeDdr)
            .Build();

        // Computer case
        var computerCaseSize = new ComponentSize(230, 491, 386);
        var computerCaseMaximumSizeGpu = new ComponentSize(50, 150, 330);
        var computerCaseFromFactors = new List<FormFactor?>()
            { FormFactor.StandardAtx, FormFactor.MicroAtx, FormFactor.MiniItx, FormFactor.NanoItx };

        ComputerCase cougarComputerCase = new ComputerCaseBuilder()
            .WithSize(computerCaseSize)
            .WithMaximumSizeGpu(computerCaseMaximumSizeGpu)
            .WithAvailableFromFactor(computerCaseFromFactors).Build();

        // HDD
        const ConnectionSlot hddSlot = ConnectionSlot.Sata;
        const int hddWorkSpeed = 150;
        const int hddVoltage = 7;
        const int hddVolume = 1000;

        Hdd wdBlueHdd = new HddBuilder()
            .WithSlot(hddSlot)
            .WithWorkSpeed(hddWorkSpeed)
            .WithVoltage(hddVoltage)
            .WithVolume(hddVolume)
            .Build();

        // SSD
        const ConnectionSlot ssdSlot = ConnectionSlot.Sata;
        const int ssdWorkSpeed = 520;
        const int ssdVoltage = 2;
        const int ssdVolume = 512;

        Ssd samsungSsd = new SsdBuilder()
            .WithSlot(ssdSlot)
            .WithWorkSpeed(ssdWorkSpeed)
            .WithVoltage(ssdVoltage)
            .WithVolume(ssdVolume)
            .Build();

        // Motherboard
        const Socket motherboardSocket = Socket.Amuda4;
        const TypeDdr motherboardTypeDdr = TypeDdr.Ddr4;
        const int motherboardCountDdr = 4;
        const int motherboardCountPsi = 2;
        const int motherboardCountSata = 4;
        const FormFactor motherboardFromFactor = FormFactor.StandardAtx;
        var motherboardAvailableFrequency = new List<int>() { 1600, 1800, 2400, 2600, 3000, 3200, 3600 };
        var motherboardXmp = new Xmp(ramLatency,  ramVoltage, ramFrequency);
        var motherboardBios = new Bios("Bios1", 1, new List<Cpu>() { amdCpu });
        var motherboardChipset = new Chipset(motherboardAvailableFrequency, motherboardXmp);

        Motherboard asusMotherboard = new MotherboardBuilder()
            .WithSocket(motherboardSocket)
            .WithTypeDdr(motherboardTypeDdr)
            .WithCountDdr(motherboardCountDdr)
            .WithCountPsi(motherboardCountPsi)
            .WithCountSata(motherboardCountSata)
            .WithFromFactor(motherboardFromFactor)
            .WithTypeBios(motherboardBios)
            .WithTypeChipset(motherboardChipset)
            .Build();

        // Wi-Fi Adapter
        const int wifiAdapterVoltage = 1;
        const VersionPci wifiAVersionPci = VersionPci.Pci2;
        const VersionWiFi wifiVersionWiFi = VersionWiFi.Ax80211;
        const bool wifiIsBluetoothModule = true;
        WiFiAdapter tplinkWiFiAdapter = new WiFiAdapterBuilder()
            .WithVoltage(wifiAdapterVoltage)
            .WithVersionPci(wifiAVersionPci)
            .WithVersionWiFi(wifiVersionWiFi)
            .WithIsBluetoothModule(wifiIsBluetoothModule)
            .Build();

        // Cooling system
        var coolingSystemSize = new ComponentSize(75, 100, 75);
        var coolingSystemAvailableSocket = new List<Socket?>()
            { Socket.Amuda1, Socket.Amuda2, Socket.Amuda3, Socket.Amuda4 };
        const int coolingSystemLimitTdp = 75;
        CoolingSystem coolerMasterCoolingSystem = new CoolingSystemBuilder()
            .WithSize(coolingSystemSize)
            .WithAvailableSocket(coolingSystemAvailableSocket)
            .WithLimitTdp(coolingSystemLimitTdp)
            .Build();

        // Power unit
        const int powerUnitMaximumVoltage = 650;
        PowerUnit thermaltakePowerUnit = new PowerUnitBuilder()
            .WithMaximumVoltage(powerUnitMaximumVoltage)
            .Build();

        repository.Append(amdCpu);
        repository.Append(nVidiaGpu);
        repository.Append(hyperXRamMemory);
        repository.Append(cougarComputerCase);
        repository.Append(wdBlueHdd);
        repository.Append(samsungSsd);
        repository.Append(asusMotherboard);
        repository.Append(tplinkWiFiAdapter);
        repository.Append(coolerMasterCoolingSystem);
        repository.Append(thermaltakePowerUnit);

        // Act
        var configurator = new Configurator.Entities.Configurator();
        Computer.Entities.Computer computer = new ComputerBuilder().WithCpu(amdCpu).Build();
        Computer.Entities.Computer newComputer = configurator.Configure(computer);
        ConfigureResult configureResultNewComputer = configurator.Validation(newComputer);

        // Assert
        Assert.Equal(amdCpu, newComputer.Cpu);
        Assert.Null(newComputer.Gpu);
        Assert.Equal(new List<RamMemory>() { hyperXRamMemory }, newComputer.RamMemory);
        Assert.Equal(cougarComputerCase, newComputer.ComputerCase);
        Assert.Equal(new List<Hdd>() { wdBlueHdd }, newComputer.Hdd);
        Assert.Equal(new List<Ssd>() { samsungSsd }, newComputer.Ssd);
        Assert.Equal(asusMotherboard, newComputer.Motherboard);
        Assert.Equal(tplinkWiFiAdapter, newComputer.WiFiAdapter);
        Assert.Equal(coolerMasterCoolingSystem, newComputer.CoolingSystem);
        Assert.Equal(thermaltakePowerUnit, newComputer.PowerUnit);

        _testOutputHelper.WriteLine(
            $"CONFIGURE RESULT:\n" +
            $"New computer: {configureResultNewComputer.Computer?.Info}" +
            $"Is result success: {configureResultNewComputer.IsResultSuccess}\n" +
            $"Is warranty: {configureResultNewComputer.IsWarranty}\n" +
            $"Comments: {configureResultNewComputer.Comment}");
    }

    [Fact]
    public void VoltageWaringSetup()
    {
        // Arrange
        Repository.Entities.Repository repository = Repository.Entities.Repository.Instance;
        repository.Clear();

        // CPU
        const Socket cpuSocket = Socket.Amuda4;
        const int cpuVoltage = 150;
        const int cpuTdp = 65;
        const int cpuCoreCount = 6;
        const int cpuCoreFrequency = 3900;
        const bool cpuGraphicCore = false;
        var cpuMemoryFrequency = new List<int>() { 3600 };
        Cpu amdCpu = new CpuBuilder()
            .WithSocket(cpuSocket)
            .WithVoltage(cpuVoltage)
            .WithTdp(cpuTdp)
            .WithCoreCount(cpuCoreCount)
            .WithCoreFrequency(cpuCoreFrequency)
            .WithIsGraphicCore(cpuGraphicCore)
            .WithMemoryFrequency(cpuMemoryFrequency)
            .Build();

        // GPU
        const int gpuVoltage = 340;
        const int gpuCoreFrequency = 1837;
        const int gpuCountMemory = 12000;
        const VersionPci gpuVersionPci = VersionPci.PciX;
        var sizeGpu = new ComponentSize(41, 117, 282);

        Gpu nVidiaGpu = new GpuBuilder()
            .WithVoltage(gpuVoltage)
            .WithCoreFrequency(gpuCoreFrequency)
            .WithCountMemory(gpuCountMemory)
            .WithVersionPsi(gpuVersionPci)
            .WithSize(sizeGpu)
            .Build();

        // Ram memory
        const int ramVolume = 16000;
        const int ramFrequency = 3600;
        const int ramVoltage = 1;
        const TypeDdr ramTypeDdr = TypeDdr.Ddr4;
        var ramLatency = new Latency(19, 23, 23, 23);
        var ramXmp = new Xmp(ramLatency,  ramVoltage, ramFrequency);
        var ramJedec = new List<Jedec>() { new Jedec(ramFrequency, ramVoltage) };

        RamMemory hyperXRamMemory = new RamMemoryBuilder()
            .WithVolume(ramVolume)
            .WithVoltage(ramVoltage)
            .WithAvailableXmp(ramXmp)
            .WithAvailableJedec(ramJedec)
            .WithTypeDdr(ramTypeDdr)
            .Build();

        // Computer case
        var computerCaseSize = new ComponentSize(230, 491, 386);
        var computerCaseMaximumSizeGpu = new ComponentSize(50, 150, 330);
        var computerCaseFromFactors = new List<FormFactor?>()
            { FormFactor.StandardAtx, FormFactor.MicroAtx, FormFactor.MiniItx, FormFactor.NanoItx };

        ComputerCase cougarComputerCase = new ComputerCaseBuilder()
            .WithSize(computerCaseSize)
            .WithMaximumSizeGpu(computerCaseMaximumSizeGpu)
            .WithAvailableFromFactor(computerCaseFromFactors).Build();

        // HDD
        const ConnectionSlot hddSlot = ConnectionSlot.Sata;
        const int hddWorkSpeed = 150;
        const int hddVoltage = 7;
        const int hddVolume = 1000;

        Hdd wdBlueHdd = new HddBuilder()
            .WithSlot(hddSlot)
            .WithWorkSpeed(hddWorkSpeed)
            .WithVoltage(hddVoltage)
            .WithVolume(hddVolume)
            .Build();

        // SSD
        const ConnectionSlot ssdSlot = ConnectionSlot.Sata;
        const int ssdWorkSpeed = 520;
        const int ssdVoltage = 2;
        const int ssdVolume = 512;

        Ssd samsungSsd = new SsdBuilder()
            .WithSlot(ssdSlot)
            .WithWorkSpeed(ssdWorkSpeed)
            .WithVoltage(ssdVoltage)
            .WithVolume(ssdVolume)
            .Build();

        // Motherboard
        const Socket motherboardSocket = Socket.Amuda4;
        const TypeDdr motherboardTypeDdr = TypeDdr.Ddr4;
        const int motherboardCountDdr = 4;
        const int motherboardCountPsi = 2;
        const int motherboardCountSata = 4;
        const FormFactor motherboardFromFactor = FormFactor.StandardAtx;
        var motherboardAvailableFrequency = new List<int>() { 1600, 1800, 2400, 2600, 3000, 3200, 3600 };
        var motherboardXmp = new Xmp(ramLatency,  ramVoltage, ramFrequency);
        var motherboardBios = new Bios("Bios1", 1, new List<Cpu>() { amdCpu });
        var motherboardChipset = new Chipset(motherboardAvailableFrequency, motherboardXmp);

        Motherboard asusMotherboard = new MotherboardBuilder()
            .WithSocket(motherboardSocket)
            .WithTypeDdr(motherboardTypeDdr)
            .WithCountDdr(motherboardCountDdr)
            .WithCountPsi(motherboardCountPsi)
            .WithCountSata(motherboardCountSata)
            .WithFromFactor(motherboardFromFactor)
            .WithTypeBios(motherboardBios)
            .WithTypeChipset(motherboardChipset)
            .Build();

        // Wi-Fi Adapter
        const int wifiAdapterVoltage = 1;
        const VersionPci wifiAVersionPci = VersionPci.Pci2;
        const VersionWiFi wifiVersionWiFi = VersionWiFi.Ax80211;
        const bool wifiIsBluetoothModule = true;
        WiFiAdapter tplinkWiFiAdapter = new WiFiAdapterBuilder()
            .WithVoltage(wifiAdapterVoltage)
            .WithVersionPci(wifiAVersionPci)
            .WithVersionWiFi(wifiVersionWiFi)
            .WithIsBluetoothModule(wifiIsBluetoothModule)
            .Build();

        // Cooling system
        var coolingSystemSize = new ComponentSize(75, 100, 75);
        var coolingSystemAvailableSocket = new List<Socket?>()
            { Socket.Amuda1, Socket.Amuda2, Socket.Amuda3, Socket.Amuda4 };
        const int coolingSystemLimitTdp = 75;
        CoolingSystem coolerMasterCoolingSystem = new CoolingSystemBuilder()
            .WithSize(coolingSystemSize)
            .WithAvailableSocket(coolingSystemAvailableSocket)
            .WithLimitTdp(coolingSystemLimitTdp)
            .Build();

        // Power unit
        const int powerUnitMaximumVoltage = 490;
        PowerUnit thermaltakePowerUnit = new PowerUnitBuilder()
            .WithMaximumVoltage(powerUnitMaximumVoltage)
            .Build();

        repository.Append(amdCpu);
        repository.Append(nVidiaGpu);
        repository.Append(hyperXRamMemory);
        repository.Append(cougarComputerCase);
        repository.Append(wdBlueHdd);
        repository.Append(samsungSsd);
        repository.Append(asusMotherboard);
        repository.Append(tplinkWiFiAdapter);
        repository.Append(coolerMasterCoolingSystem);
        repository.Append(thermaltakePowerUnit);

        // Act
        var configurator = new Configurator.Entities.Configurator();
        Computer.Entities.Computer computer = new ComputerBuilder().WithCpu(amdCpu).Build();
        Computer.Entities.Computer newComputer = configurator.Configure(computer);
        ConfigureResult configureResultNewComputer = configurator.Validation(newComputer);

        // Assert
        Assert.Equal("The computer's power unit is fire!\n", configureResultNewComputer.Comment);
        _testOutputHelper.WriteLine(
            $"CONFIGURE RESULT:\n" +
            $"New computer: {configureResultNewComputer.Computer?.Info}" +
            $"Is result success: {configureResultNewComputer.IsResultSuccess}\n" +
            $"Is warranty: {configureResultNewComputer.IsWarranty}\n" +
            $"Comments: {configureResultNewComputer.Comment}");
    }

    [Fact]
    public void TdpWaringSetup()
    {
        // Arrange
        Repository.Entities.Repository repository = Repository.Entities.Repository.Instance;
        repository.Clear();

        // CPU
        const Socket cpuSocket = Socket.Amuda4;
        const int cpuVoltage = 65;
        const int cpuTdp = 100;
        const int cpuCoreCount = 6;
        const int cpuCoreFrequency = 3900;
        const bool cpuGraphicCore = true;
        var cpuMemoryFrequency = new List<int>() { 3600 };
        Cpu amdCpu = new CpuBuilder()
            .WithSocket(cpuSocket)
            .WithVoltage(cpuVoltage)
            .WithTdp(cpuTdp)
            .WithCoreCount(cpuCoreCount)
            .WithCoreFrequency(cpuCoreFrequency)
            .WithIsGraphicCore(cpuGraphicCore)
            .WithMemoryFrequency(cpuMemoryFrequency)
            .Build();

        // GPU
        const int gpuVoltage = 170;
        const int gpuCoreFrequency = 1837;
        const int gpuCountMemory = 12000;
        const VersionPci gpuVersionPci = VersionPci.PciX;
        var sizeGpu = new ComponentSize(41, 117, 282);

        Gpu nVidiaGpu = new GpuBuilder()
            .WithVoltage(gpuVoltage)
            .WithCoreFrequency(gpuCoreFrequency)
            .WithCountMemory(gpuCountMemory)
            .WithVersionPsi(gpuVersionPci)
            .WithSize(sizeGpu)
            .Build();

        // Ram memory
        const int ramVolume = 16000;
        const int ramFrequency = 3600;
        const int ramVoltage = 1;
        const TypeDdr ramTypeDdr = TypeDdr.Ddr4;
        var ramLatency = new Latency(19, 23, 23, 23);
        var ramXmp = new Xmp(ramLatency,  ramVoltage, ramFrequency);
        var ramJedec = new List<Jedec>() { new Jedec(ramFrequency, ramVoltage) };

        RamMemory hyperXRamMemory = new RamMemoryBuilder()
            .WithVolume(ramVolume)
            .WithVoltage(ramVoltage)
            .WithAvailableXmp(ramXmp)
            .WithAvailableJedec(ramJedec)
            .WithTypeDdr(ramTypeDdr)
            .Build();

        // Computer case
        var computerCaseSize = new ComponentSize(230, 491, 386);
        var computerCaseMaximumSizeGpu = new ComponentSize(50, 150, 330);
        var computerCaseFromFactors = new List<FormFactor?>()
            { FormFactor.StandardAtx, FormFactor.MicroAtx, FormFactor.MiniItx, FormFactor.NanoItx };

        ComputerCase cougarComputerCase = new ComputerCaseBuilder()
            .WithSize(computerCaseSize)
            .WithMaximumSizeGpu(computerCaseMaximumSizeGpu)
            .WithAvailableFromFactor(computerCaseFromFactors).Build();

        // HDD
        const ConnectionSlot hddSlot = ConnectionSlot.Sata;
        const int hddWorkSpeed = 150;
        const int hddVoltage = 7;
        const int hddVolume = 1000;

        Hdd wdBlueHdd = new HddBuilder()
            .WithSlot(hddSlot)
            .WithWorkSpeed(hddWorkSpeed)
            .WithVoltage(hddVoltage)
            .WithVolume(hddVolume)
            .Build();

        // SSD
        const ConnectionSlot ssdSlot = ConnectionSlot.Sata;
        const int ssdWorkSpeed = 520;
        const int ssdVoltage = 2;
        const int ssdVolume = 512;

        Ssd samsungSsd = new SsdBuilder()
            .WithSlot(ssdSlot)
            .WithWorkSpeed(ssdWorkSpeed)
            .WithVoltage(ssdVoltage)
            .WithVolume(ssdVolume)
            .Build();

        // Motherboard
        const Socket motherboardSocket = Socket.Amuda4;
        const TypeDdr motherboardTypeDdr = TypeDdr.Ddr4;
        const int motherboardCountDdr = 4;
        const int motherboardCountPsi = 2;
        const int motherboardCountSata = 4;
        const FormFactor motherboardFromFactor = FormFactor.StandardAtx;
        var motherboardAvailableFrequency = new List<int>() { 1600, 1800, 2400, 2600, 3000, 3200, 3600 };
        var motherboardXmp = new Xmp(ramLatency,  ramVoltage, ramFrequency);
        var motherboardBios = new Bios("Bios1", 1, new List<Cpu>() { amdCpu });
        var motherboardChipset = new Chipset(motherboardAvailableFrequency, motherboardXmp);

        Motherboard asusMotherboard = new MotherboardBuilder()
            .WithSocket(motherboardSocket)
            .WithTypeDdr(motherboardTypeDdr)
            .WithCountDdr(motherboardCountDdr)
            .WithCountPsi(motherboardCountPsi)
            .WithCountSata(motherboardCountSata)
            .WithFromFactor(motherboardFromFactor)
            .WithTypeBios(motherboardBios)
            .WithTypeChipset(motherboardChipset)
            .Build();

        // Wi-Fi Adapter
        const int wifiAdapterVoltage = 1;
        const VersionPci wifiAVersionPci = VersionPci.Pci2;
        const VersionWiFi wifiVersionWiFi = VersionWiFi.Ax80211;
        const bool wifiIsBluetoothModule = true;
        WiFiAdapter tplinkWiFiAdapter = new WiFiAdapterBuilder()
            .WithVoltage(wifiAdapterVoltage)
            .WithVersionPci(wifiAVersionPci)
            .WithVersionWiFi(wifiVersionWiFi)
            .WithIsBluetoothModule(wifiIsBluetoothModule)
            .Build();

        // Cooling system
        var coolingSystemSize = new ComponentSize(75, 100, 75);
        var coolingSystemAvailableSocket = new List<Socket?>()
            { Socket.Amuda1, Socket.Amuda2, Socket.Amuda3, Socket.Amuda4 };
        const int coolingSystemLimitTdp = 95;
        CoolingSystem coolerMasterCoolingSystem = new CoolingSystemBuilder()
            .WithSize(coolingSystemSize)
            .WithAvailableSocket(coolingSystemAvailableSocket)
            .WithLimitTdp(coolingSystemLimitTdp)
            .Build();

        // Power unit
        const int powerUnitMaximumVoltage = 650;
        PowerUnit thermaltakePowerUnit = new PowerUnitBuilder()
            .WithMaximumVoltage(powerUnitMaximumVoltage)
            .Build();

        repository.Append(amdCpu);
        repository.Append(nVidiaGpu);
        repository.Append(hyperXRamMemory);
        repository.Append(cougarComputerCase);
        repository.Append(wdBlueHdd);
        repository.Append(samsungSsd);
        repository.Append(asusMotherboard);
        repository.Append(tplinkWiFiAdapter);
        repository.Append(coolerMasterCoolingSystem);
        repository.Append(thermaltakePowerUnit);

        // Act
        var configurator = new Configurator.Entities.Configurator();
        Computer.Entities.Computer computer = new ComputerBuilder().WithCpu(amdCpu).Build();
        Computer.Entities.Computer newComputer = configurator.Configure(computer);
        ConfigureResult configureResultNewComputer = configurator.Validation(newComputer);

        // Assert
        Assert.Equal("The computer's cpu is fire!\n", configureResultNewComputer.Comment);

        _testOutputHelper.WriteLine(
            $"CONFIGURE RESULT:\n" +
            $"New computer: {configureResultNewComputer.Computer?.Info}" +
            $"Is result success: {configureResultNewComputer.IsResultSuccess}\n" +
            $"Is warranty: {configureResultNewComputer.IsWarranty}\n" +
            $"Comments: {configureResultNewComputer.Comment}");
    }

    [Fact]
    public void ErrorSetup()
    {
        // Arrange
        Repository.Entities.Repository repository = Repository.Entities.Repository.Instance;
        repository.Clear();

        // CPU
        const Socket cpuSocket = Socket.Amuda2;
        const int cpuVoltage = 65;
        const int cpuTdp = 100;
        const int cpuCoreCount = 6;
        const int cpuCoreFrequency = 3900;
        const bool cpuGraphicCore = true;
        var cpuMemoryFrequency = new List<int>() { 3200 };
        Cpu amdCpu = new CpuBuilder()
            .WithSocket(cpuSocket)
            .WithVoltage(cpuVoltage)
            .WithTdp(cpuTdp)
            .WithCoreCount(cpuCoreCount)
            .WithCoreFrequency(cpuCoreFrequency)
            .WithIsGraphicCore(cpuGraphicCore)
            .WithMemoryFrequency(cpuMemoryFrequency)
            .Build();

        // GPU
        const int gpuVoltage = 170;
        const int gpuCoreFrequency = 1837;
        const int gpuCountMemory = 12000;
        const VersionPci gpuVersionPci = VersionPci.PciX;
        var sizeGpu = new ComponentSize(41, 117, 282);

        Gpu nVidiaGpu = new GpuBuilder()
            .WithVoltage(gpuVoltage)
            .WithCoreFrequency(gpuCoreFrequency)
            .WithCountMemory(gpuCountMemory)
            .WithVersionPsi(gpuVersionPci)
            .WithSize(sizeGpu)
            .Build();

        // Ram memory
        const int ramVolume = 16000;
        const int ramFrequency = 3600;
        const int ramVoltage = 1;
        const TypeDdr ramTypeDdr = TypeDdr.Ddr4;
        var ramLatency = new Latency(19, 23, 23, 23);
        var ramXmp = new Xmp(ramLatency,  ramVoltage, ramFrequency);
        var ramJedec = new List<Jedec>() { new Jedec(ramFrequency, ramVoltage) };

        RamMemory hyperXRamMemory = new RamMemoryBuilder()
            .WithVolume(ramVolume)
            .WithVoltage(ramVoltage)
            .WithAvailableXmp(ramXmp)
            .WithAvailableJedec(ramJedec)
            .WithTypeDdr(ramTypeDdr)
            .Build();

        // Computer case
        var computerCaseSize = new ComponentSize(230, 491, 386);
        var computerCaseMaximumSizeGpu = new ComponentSize(50, 150, 330);
        var computerCaseFromFactors = new List<FormFactor?>()
            { FormFactor.StandardAtx, FormFactor.MicroAtx, FormFactor.MiniItx, FormFactor.NanoItx };

        ComputerCase cougarComputerCase = new ComputerCaseBuilder()
            .WithSize(computerCaseSize)
            .WithMaximumSizeGpu(computerCaseMaximumSizeGpu)
            .WithAvailableFromFactor(computerCaseFromFactors).Build();

        // HDD
        const ConnectionSlot hddSlot = ConnectionSlot.Sata;
        const int hddWorkSpeed = 150;
        const int hddVoltage = 7;
        const int hddVolume = 1000;

        Hdd wdBlueHdd = new HddBuilder()
            .WithSlot(hddSlot)
            .WithWorkSpeed(hddWorkSpeed)
            .WithVoltage(hddVoltage)
            .WithVolume(hddVolume)
            .Build();

        // SSD
        const ConnectionSlot ssdSlot = ConnectionSlot.Sata;
        const int ssdWorkSpeed = 520;
        const int ssdVoltage = 2;
        const int ssdVolume = 512;

        Ssd samsungSsd = new SsdBuilder()
            .WithSlot(ssdSlot)
            .WithWorkSpeed(ssdWorkSpeed)
            .WithVoltage(ssdVoltage)
            .WithVolume(ssdVolume)
            .Build();

        // Motherboard
        const Socket motherboardSocket = Socket.Amuda4;
        const TypeDdr motherboardTypeDdr = TypeDdr.Ddr4;
        const int motherboardCountDdr = 4;
        const int motherboardCountPsi = 2;
        const int motherboardCountSata = 4;
        const FormFactor motherboardFromFactor = FormFactor.StandardAtx;
        var motherboardAvailableFrequency = new List<int>() { 1600, 1800, 2400, 2600, 3000, 3200, 3600 };
        var motherboardXmp = new Xmp(ramLatency,  ramVoltage, ramFrequency);
        var motherboardBios = new Bios("Bios1", 1, new List<Cpu>() { amdCpu });
        var motherboardChipset = new Chipset(motherboardAvailableFrequency, motherboardXmp);

        Motherboard asusMotherboard = new MotherboardBuilder()
            .WithSocket(motherboardSocket)
            .WithTypeDdr(motherboardTypeDdr)
            .WithCountDdr(motherboardCountDdr)
            .WithCountPsi(motherboardCountPsi)
            .WithCountSata(motherboardCountSata)
            .WithFromFactor(motherboardFromFactor)
            .WithTypeBios(motherboardBios)
            .WithTypeChipset(motherboardChipset)
            .Build();

        // Wi-Fi Adapter
        const int wifiAdapterVoltage = 1;
        const VersionPci wifiAVersionPci = VersionPci.Pci2;
        const VersionWiFi wifiVersionWiFi = VersionWiFi.Ax80211;
        const bool wifiIsBluetoothModule = true;
        WiFiAdapter tplinkWiFiAdapter = new WiFiAdapterBuilder()
            .WithVoltage(wifiAdapterVoltage)
            .WithVersionPci(wifiAVersionPci)
            .WithVersionWiFi(wifiVersionWiFi)
            .WithIsBluetoothModule(wifiIsBluetoothModule)
            .Build();

        // Cooling system
        var coolingSystemSize = new ComponentSize(75, 100, 75);
        var coolingSystemAvailableSocket = new List<Socket?>()
            { Socket.Amuda1, Socket.Amuda2, Socket.Amuda3, Socket.Amuda4 };
        const int coolingSystemLimitTdp = 95;
        CoolingSystem coolerMasterCoolingSystem = new CoolingSystemBuilder()
            .WithSize(coolingSystemSize)
            .WithAvailableSocket(coolingSystemAvailableSocket)
            .WithLimitTdp(coolingSystemLimitTdp)
            .Build();

        // Power unit
        const int powerUnitMaximumVoltage = 650;
        PowerUnit thermaltakePowerUnit = new PowerUnitBuilder()
            .WithMaximumVoltage(powerUnitMaximumVoltage)
            .Build();

        repository.Append(amdCpu);
        repository.Append(nVidiaGpu);
        repository.Append(hyperXRamMemory);
        repository.Append(cougarComputerCase);
        repository.Append(wdBlueHdd);
        repository.Append(samsungSsd);
        repository.Append(asusMotherboard);
        repository.Append(tplinkWiFiAdapter);
        repository.Append(coolerMasterCoolingSystem);
        repository.Append(thermaltakePowerUnit);

        // Act
        var configurator = new Configurator.Entities.Configurator();
        Computer.Entities.Computer computer = new ComputerBuilder().WithCpu(amdCpu).Build();
        Computer.Entities.Computer newComputer = configurator.Configure(computer);
        ConfigureResult configureResultNewComputer = configurator.Validation(newComputer);

        // Assert
        Assert.Null(newComputer.Motherboard);
        Assert.Null(newComputer.Gpu);
        Assert.Null(newComputer.Ssd);
        Assert.Null(newComputer.Hdd);
        Assert.Null(newComputer.RamMemory);
        Assert.Null(newComputer.WiFiAdapter);
        Assert.False(configureResultNewComputer.IsResultSuccess);
        Assert.False(configureResultNewComputer.IsWarranty);

        _testOutputHelper.WriteLine(
            $"CONFIGURE RESULT:\n" +
            $"New computer: {configureResultNewComputer.Computer?.Info}" +
            $"Is result success: {configureResultNewComputer.IsResultSuccess}\n" +
            $"Is warranty: {configureResultNewComputer.IsWarranty}\n" +
            $"Comments: {configureResultNewComputer.Comment}");
    }
}