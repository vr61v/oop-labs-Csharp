using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Cpu;

public class Cpu : IComponent
{
    public Cpu(int coreFrequency, int coreCount, int tdp, int voltage, bool isGraphicCore, Socket? socket, IList<int>? memoryFrequency)
    {
        CoreFrequency = coreFrequency;
        CoreCount = coreCount;
        Tdp = tdp;
        Voltage = voltage;
        IsGraphicCore = isGraphicCore;
        Socket = socket;
        MemoryFrequency = memoryFrequency;
    }

    public int CoreFrequency { get; private set; }
    public int CoreCount { get; private set; }
    public int Tdp { get; private set; }
    public int Voltage { get; private set; }
    public bool IsGraphicCore { get; private set; }
    public Socket? Socket { get; private set; }
    public IList<int>? MemoryFrequency { get; private set; }

    public ComponentType ComponentType()
    {
        return Models.ComponentType.Cpu;
    }

    public ComponentInfo Info()
    {
        return new ComponentInfo(
            $"\nCPU INFO:\n" +
            $"\tCore frequency: {CoreFrequency}Hz\n" +
            $"\tCore count: {CoreCount}\n" +
            $"\tTdp: {Tdp}W\n" +
            $"\tVoltage: {Voltage}W\n" +
            $"\tIsGraphicCore: {IsGraphicCore}\n" +
            $"\tSocket: {Socket}\n");
    }
}