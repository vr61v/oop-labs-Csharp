using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.ComputerCase;

public class ComputerCaseBuilder : IComputerCaseBuilder
{
    private IList<FormFactor?>? _availableFromFactor;
    private ComponentSize? _maximumSizeGpu;
    private ComponentSize? _size;

    public ComputerCaseBuilder WithAvailableFromFactor(IList<FormFactor?> availableFromFactor)
    {
        _availableFromFactor = availableFromFactor;
        return this;
    }

    public ComputerCaseBuilder WithMaximumSizeGpu(ComponentSize? maximumSizeGpu)
    {
        _maximumSizeGpu = maximumSizeGpu;
        return this;
    }

    public ComputerCaseBuilder WithSize(ComponentSize? size)
    {
        _size = size;
        return this;
    }

    public ComputerCaseBuilder BaseOn(ComputerCase? component)
    {
        _availableFromFactor = component?.AvailableFromFactor;
        _maximumSizeGpu = component?.MaximumSizeGpu;
        _size = component?.Size;
        return this;
    }

    public ComputerCase Build()
    {
        return new ComputerCase(
            _availableFromFactor,
            _maximumSizeGpu,
            _size);
    }
}