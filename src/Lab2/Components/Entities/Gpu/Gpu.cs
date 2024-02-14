using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Gpu;

public class Gpu : IComponent
{
    public Gpu(int countMemory, int coreFrequency, int voltage, VersionPci? versionPci, ComponentSize? size)
    {
        CountMemory = countMemory;
        CoreFrequency = coreFrequency;
        Voltage = voltage;
        VersionPci = versionPci;
        Size = size;
    }

    public int CountMemory { get; private set; }
    public int CoreFrequency { get; private set; }
    public int Voltage { get; private set; }
    public VersionPci? VersionPci { get; private set; }
    public ComponentSize? Size { get; private set; }

    public ComponentType ComponentType()
    {
        return Models.ComponentType.Gpu;
    }

    public ComponentInfo Info()
    {
        return new ComponentInfo(
            $"\nGPU INFO:\n" +
            $"\tCount memory: {CountMemory}Mb\n" +
            $"\tCore frequency: {CoreFrequency}Hz\n" +
            $"\tVoltage: {Voltage}W\n" +
            $"\tVersion pci: {VersionPci}\n" +
            $"\tSize: width {Size?.Width}mm, height {Size?.Height}mm, length {Size?.Length}mm\n");
    }
}