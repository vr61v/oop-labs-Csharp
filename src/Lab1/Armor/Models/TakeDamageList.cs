using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

public class TakeDamageList
{
    private const float TakeAsteroidDamage = 1;
    private const float TakeMeteoriteDamage = 1;
    private const float TakeCosmoWhalesDamage = 1;
    private const float TakeAntimatterFlashDamage = 1;

    public TakeDamageList()
        : this(TakeAsteroidDamage, TakeMeteoriteDamage, TakeCosmoWhalesDamage, TakeAntimatterFlashDamage) { }

    public TakeDamageList(float asteroidDamage, float meteoriteDamage, float cosmoWhalesDamage, float antimatterFlashDamage)
    {
        TakeDamage = new Dictionary<string, float>
        {
            { "Asteroid", asteroidDamage },
            { "Meteorite", meteoriteDamage },
            { "CosmoWhales", cosmoWhalesDamage },
            { "AntimatterFlash", antimatterFlashDamage },
        };
    }

    public Dictionary<string, float>? TakeDamage { get; init; }
}