using Itmo.ObjectOrientedProgramming.Lab2.Configurator.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Configurator;

public interface IConfigurator
{
    Computer.Entities.Computer Configure(Computer.Entities.Computer computer);
    ConfigureResult Validation(Computer.Entities.Computer? computer);
}