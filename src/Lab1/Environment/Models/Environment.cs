using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Interfaces;
namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Models;

public abstract class Environment
{
    public int Length { get; protected init; }

    public IEnumerable<IObstacle>? Obstacle { get; protected init; }

    protected abstract IEnumerable<IObstacle>? Validation(IEnumerable<IObstacle> obstacle);
}