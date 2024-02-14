using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IComponent
{
    public ComponentType ComponentType();
    public ComponentInfo Info();
}