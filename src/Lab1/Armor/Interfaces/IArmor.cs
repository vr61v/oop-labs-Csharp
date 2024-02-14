using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.Interfaces;

public interface IArmor
{
    public void TakeDamage(IObstacle obstacle, float damage);
}