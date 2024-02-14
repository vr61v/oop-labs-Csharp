using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.CoolingSystem;

public interface ICoolingSystemBuilder
{
    public CoolingSystemBuilder WithLimitTdp(int limitTdp);
    public CoolingSystemBuilder WithSize(ComponentSize? size);
    public CoolingSystemBuilder WithAvailableSocket(IList<Socket?>? availableSocket);
    public CoolingSystemBuilder BaseOn(CoolingSystem? component);
    public CoolingSystem Build();
}