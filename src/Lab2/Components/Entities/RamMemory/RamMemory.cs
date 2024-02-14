using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.RamMemory;

public class RamMemory : IComponent
{
    public RamMemory(int volume, int voltage, IList<Jedec>? availableJedec, Xmp? availableXmp, TypeDdr? typeDdr)
    {
        Volume = volume;
        Voltage = voltage;
        AvailableJedec = availableJedec;
        AvailableXmp = availableXmp;
        TypeDdr = typeDdr;
    }

    public int Volume { get; private set; }
    public int Voltage { get; private set; }
    public IList<Jedec>? AvailableJedec { get; private set; }
    public Xmp? AvailableXmp { get; private set; }
    public TypeDdr? TypeDdr { get; private set; }

    public ComponentType ComponentType()
    {
        return Components.Models.ComponentType.RamMemory;
    }

    public ComponentInfo Info()
    {
        return new ComponentInfo(
            $"\nRAM MEMORY INFO:\n" +
            $"\tVolume: {Volume}Mb\n" +
            $"\tVoltage: {Voltage}W\n" +
            $"\tAvailable xmp: " +
                $"voltage: {AvailableXmp?.Voltage}W, " +
                $"frequency: {AvailableXmp?.Frequency}Hz, " +
                $"latency: {AvailableXmp?.Latency.Ras}-{AvailableXmp?.Latency.RasT}-{AvailableXmp?.Latency.RasRecharge}-{AvailableXmp?.Latency.RcT}\n" +
            $"\tType ddr: {TypeDdr}\n");
    }
}