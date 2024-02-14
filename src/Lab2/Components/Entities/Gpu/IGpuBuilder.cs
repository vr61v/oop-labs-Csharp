using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Gpu;

public interface IGpuBuilder
{
    public GpuBuilder WithCountMemory(int countMemory);
    public GpuBuilder WithCoreFrequency(int coreFrequency);
    public GpuBuilder WithVoltage(int voltage);
    public GpuBuilder WithVersionPsi(VersionPci? versionPsi);
    public GpuBuilder WithSize(ComponentSize? size);

    public GpuBuilder BaseOn(Gpu? component);
    public Gpu Build();
}