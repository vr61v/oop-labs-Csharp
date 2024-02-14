using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Storage.Hdd;

public class Hdd : Storage, IComponent
{
    public Hdd(ConnectionSlot? slot, int volume, int workSpeed, int voltage)
    {
        Slot = slot;
        Volume = volume;
        WorkSpeed = workSpeed;
        Voltage = voltage;
    }

    public ComponentType ComponentType()
    {
        return Models.ComponentType.Hdd;
    }

    public ComponentInfo Info()
    {
        return new ComponentInfo(
            $"\nHDD INFO:\n" +
            $"\tConnection slot{Slot}\n" +
            $"\tVolume: {Volume}Gb\n" +
            $"\tWork speed: {WorkSpeed}Mb/s\n" +
            $"\tVoltage: {Voltage}W\n");
    }
}