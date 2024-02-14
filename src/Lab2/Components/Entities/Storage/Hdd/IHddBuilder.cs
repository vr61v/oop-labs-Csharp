using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Hdd;

public interface IHddBuilder
{
    public HddBuilder WithSlot(ConnectionSlot? slot);
    public HddBuilder WithVolume(int volume);
    public HddBuilder WithWorkSpeed(int workSpeed);
    public HddBuilder WithVoltage(int voltage);

    public HddBuilder BaseOn(Storage.Hdd.Hdd? component);
    public Storage.Hdd.Hdd Build();
}