using Itmo.ObjectOrientedProgramming.Lab2.Computer.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Configurator.Models;

public record ConfigureResult(ComputerInfo? Computer, bool IsResultSuccess, string? Comment, bool IsWarranty);