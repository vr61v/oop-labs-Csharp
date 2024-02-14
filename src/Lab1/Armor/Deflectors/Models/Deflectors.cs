using Itmo.ObjectOrientedProgramming.Lab1.Armor.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.Deflectors.Models;

public abstract class Deflectors : IArmor
{
    private const float MinHealthPoint = 0F;
    private const float MaxHealthPoint = 100F;

    public bool IsPeopleAlive { get; protected set; }
    public bool IsShipAlive { get; protected set; }
    public TakeDamageList? Damage { get; protected init; }
    private float HealthPoints { get; set; } = MaxHealthPoint;

    public void TakeDamage(IObstacle? obstacle, float damage)
    {
        if (obstacle is null || Damage?.TakeDamage is null) return;
        HealthPoints -= MaxHealthPoint / Damage.TakeDamage[$"{obstacle.GetType().Name}"];

        if (HealthPoints >= MinHealthPoint) return;
        if (obstacle.GetTypeObstacle() == typeof(AntimatterFlash)) IsPeopleAlive = false;
        IsShipAlive = false;
    }
}