using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Cpu;

public interface ICpuBuilder
{
    public CpuBuilder WithCoreFrequency(int coreFrequency);
    public CpuBuilder WithCoreCount(int coreCount);
    public CpuBuilder WithTdp(int tdp);
    public CpuBuilder WithVoltage(int voltage);
    public CpuBuilder WithIsGraphicCore(bool isGraphicCore);
    public CpuBuilder WithSocket(Socket? socket);
    public CpuBuilder WithMemoryFrequency(IList<int>? memoryFrequency);

    public CpuBuilder BaseOn(Cpu? component);
    public Cpu Build();
}