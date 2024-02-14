using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

public class DeflectDamageList
{
    private const float DeflectAsteroidDamage = 1;
    private const float DeflectMeteoriteDamage = 1;
    private const float DeflectCosmoWhalesDamage = 1;
    private const float DeflectAntimatterFlashDamage = 1;

    public DeflectDamageList()
        : this(DeflectAsteroidDamage, DeflectMeteoriteDamage, DeflectCosmoWhalesDamage, DeflectAntimatterFlashDamage) { }

    public DeflectDamageList(float asteroidDamage, float meteoriteDamage, float cosmoWhalesDamage, float antimatterFlashDamage)
    {
        DeflectDamage = new Dictionary<string, float>
        {
            { "Asteroid", asteroidDamage },
            { "Meteorite", meteoriteDamage },
            { "CosmoWhales", cosmoWhalesDamage },
            { "AntimatterFlash", antimatterFlashDamage },
        };
    }

    public Dictionary<string, float>? DeflectDamage { get; init; }
}