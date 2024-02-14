using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Storage.Ssd;

public class Ssd : Storage, IComponent
{
    public Ssd(ConnectionSlot? slot, int volume, int workSpeed, int voltage)
    {
        Slot = slot;
        Volume = volume;
        WorkSpeed = workSpeed;
        Voltage = voltage;
    }

    public ComponentType ComponentType()
    {
        return Components.Models.ComponentType.Ssd;
    }

    public ComponentInfo Info()
    {
        return new ComponentInfo(
            $"\nSSD INFO:\n" +
            $"\tConnection slot{Slot}\n" +
            $"\tVolume: {Volume}Gb\n" +
            $"\tWork speed: {WorkSpeed}Mb/s\n" +
            $"\tVoltage: {Voltage}W\n");
    }
}