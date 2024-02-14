using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.ComputerCase;

public interface IComputerCaseBuilder
{
    public ComputerCaseBuilder WithAvailableFromFactor(IList<FormFactor?> availableFromFactor);
    public ComputerCaseBuilder WithMaximumSizeGpu(ComponentSize? maximumSizeGpu);
    public ComputerCaseBuilder WithSize(ComponentSize? size);
    public ComputerCaseBuilder BaseOn(ComputerCase? component);
    public ComputerCase Build();
}