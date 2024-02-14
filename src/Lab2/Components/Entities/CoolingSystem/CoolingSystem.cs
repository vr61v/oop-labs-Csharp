using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.CoolingSystem;

public class CoolingSystem : IComponent
{
    public CoolingSystem(int limitTdp, ComponentSize? size, IList<Socket?>? availableSocket)
    {
        LimitTdp = limitTdp;
        Size = size;
        AvailableSocket = availableSocket;
    }

    public int LimitTdp { get; private set; }
    public ComponentSize? Size { get; private set; }
    public IList<Socket?>? AvailableSocket { get; private set; }

    public ComponentType ComponentType()
    {
        return Models.ComponentType.CoolingSystem;
    }

    public ComponentInfo Info()
    {
        return new ComponentInfo(
            $"\nCOOLING SYSTEM INFO:\n" +
            $"\tLimit tdp: {LimitTdp}W\n" +
            $"\tSize: width {Size?.Width}mm, height {Size?.Height}mm, length {Size?.Length}mm\n" +
            $"\tAvailable sockets: {AvailableSocket}\n");
    }
}