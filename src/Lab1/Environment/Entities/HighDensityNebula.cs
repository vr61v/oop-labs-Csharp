using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Interfaces;
namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class HighDensityNebula : Models.Environment
{
    private const int DefaultLength = 1500000;

    public HighDensityNebula(IEnumerable<IObstacle> obstacle)
        : this(DefaultLength, obstacle) { }

    public HighDensityNebula(int length, IEnumerable<IObstacle> obstacle)
    {
        Length = length;
        Obstacle = Validation(obstacle).ToList();
    }

    protected sealed override IEnumerable<IObstacle> Validation(IEnumerable<IObstacle> obstacle)
    {
        return obstacle.Where(x => x is AntimatterFlash);
    }
}