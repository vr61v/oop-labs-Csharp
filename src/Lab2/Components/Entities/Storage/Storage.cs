using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Storage;

public abstract class Storage
{
    public ConnectionSlot? Slot { get; protected set; }
    public int Volume { get; protected set; }
    public int WorkSpeed { get; protected set; }
    public int Voltage { get; protected set; }
}