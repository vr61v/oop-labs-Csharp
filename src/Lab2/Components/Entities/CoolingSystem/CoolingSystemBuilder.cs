using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.CoolingSystem;

public class CoolingSystemBuilder : ICoolingSystemBuilder
{
    private int _limitTdp;
    private ComponentSize? _size;
    private IList<Socket?>? _availableSocket;

    public CoolingSystemBuilder WithLimitTdp(int limitTdp)
    {
        _limitTdp = limitTdp;
        return this;
    }

    public CoolingSystemBuilder WithSize(ComponentSize? size)
    {
        _size = size;
        return this;
    }

    public CoolingSystemBuilder WithAvailableSocket(IList<Socket?>? availableSocket)
    {
        _availableSocket = availableSocket;
        return this;
    }

    public CoolingSystemBuilder BaseOn(CoolingSystem? component)
    {
        _limitTdp = component?.LimitTdp ?? 0;
        _size = component?.Size;
        _availableSocket = component?.AvailableSocket;
        return this;
    }

    public CoolingSystem Build()
    {
        return new CoolingSystem(
            _limitTdp,
            _size,
            _availableSocket);
    }
}