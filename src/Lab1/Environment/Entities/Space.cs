using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Interfaces;
namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class Space : Models.Environment
{
    private const int DefaultLength = 500000;
    public Space(IEnumerable<IObstacle> obstacle)
        : this(DefaultLength, obstacle) { }

    public Space(int length, IEnumerable<IObstacle> obstacle)
    {
        Length = length;
        Obstacle = Validation(obstacle).ToList();
    }

    protected sealed override IEnumerable<IObstacle> Validation(IEnumerable<IObstacle> obstacle)
    {
        return obstacle.Where(x => x is Meteorite or Asteroid);
    }
}