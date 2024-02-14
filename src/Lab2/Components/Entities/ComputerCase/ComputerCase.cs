using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.ComputerCase;

public class ComputerCase : IComponent
{
    public ComputerCase(IList<FormFactor?>? availableFromFactor, ComponentSize? maximumSizeGpu, ComponentSize? size)
    {
        AvailableFromFactor = availableFromFactor;
        MaximumSizeGpu = maximumSizeGpu;
        Size = size;
    }

    public IList<FormFactor?>? AvailableFromFactor { get; private set; }
    public ComponentSize? MaximumSizeGpu { get; private set; }
    public ComponentSize? Size { get; private set; }

    public ComponentType ComponentType()
    {
        return Models.ComponentType.ComputerCase;
    }

    public ComponentInfo Info()
    {
        return new ComponentInfo(
            $"\nCOMPUTER CASE INFO:\n" +
            $"\tMaximum size gpu: height {MaximumSizeGpu?.Height}mm, width {MaximumSizeGpu?.Width}mm, length {MaximumSizeGpu?.Length}mm\n" +
            $"\tSize: width {Size?.Width}mm, height {Size?.Height}mm, length {Size?.Length}mm\n");
    }
}