using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Interfaces;
namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;

public class NeutrinoParticleNebula : Models.Environment
{
    private const int DefaultLength = 2000000;

    public NeutrinoParticleNebula(IEnumerable<IObstacle> obstacle)
        : this(DefaultLength, obstacle) { }

    public NeutrinoParticleNebula(int length, IEnumerable<IObstacle> obstacle)
    {
        Length = length;
        Obstacle = Validation(obstacle).ToList();
    }

    protected sealed override IEnumerable<IObstacle> Validation(IEnumerable<IObstacle> obstacle)
    {
        return obstacle.Where(x => x is CosmoWhales);
    }
}