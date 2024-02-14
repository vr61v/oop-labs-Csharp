using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

public record Chipset(IList<int> AvailableFrequency, Xmp AvailableXmp);