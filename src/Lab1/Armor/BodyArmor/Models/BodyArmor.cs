using Itmo.ObjectOrientedProgramming.Lab1.Armor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Interfaces;
namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.BodyArmor.Models;

public abstract class BodyArmor : IArmor
{
    private const float MinHealthPoint = 0F;
    private const float MaxHealthPoint = 100F;

    public bool IsShipAlive { get; protected set; }
    public TakeDamageList? Damage { get; protected init; }
    private float HealthPoints { get; set; } = MaxHealthPoint;

    public void TakeDamage(IObstacle? obstacle, float damage)
    {
        if (obstacle is null || Damage?.TakeDamage is null) return;
        HealthPoints -= MaxHealthPoint / Damage.TakeDamage[$"{obstacle.GetType().Name}"];

        if (HealthPoints >= MinHealthPoint) return;
        IsShipAlive = false;
    }
}