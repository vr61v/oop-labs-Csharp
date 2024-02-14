using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Ssd;

public interface ISsdBuilder
{
    public void WithSlot(ConnectionSlot? slot);
    public void WithVolume(int volume);
    public void WithWorkSpeed(int workSpeed);
    public void WithVoltage(int voltage);

    public void BaseOn(Storage.Ssd.Ssd? component);
    public Storage.Ssd.Ssd Build();
}