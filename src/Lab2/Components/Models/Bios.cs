using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Cpu;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

public record Bios(string Type, int Version, IList<Cpu> AvailableCpu);