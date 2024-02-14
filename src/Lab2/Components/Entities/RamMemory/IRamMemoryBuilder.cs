using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.RamMemory;

public interface IRamMemoryBuilder
{
    public RamMemoryBuilder WithVolume(int volume);
    public RamMemoryBuilder WithVoltage(int voltage);
    public RamMemoryBuilder WithAvailableJedec(IList<Jedec>? availableJedec);
    public RamMemoryBuilder WithAvailableXmp(Xmp? availableXmp);
    public RamMemoryBuilder WithTypeDdr(TypeDdr? typeDdr);

    public RamMemoryBuilder BaseOn(RamMemory? component);
    public RamMemory Build();
}