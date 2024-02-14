using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.BodySize.Entities;

public class BodySizeMedium : Models.BodySize
{
    private const float DefaultAsteroidDamage = 0.8F;
    private const float DefaultMeteoriteDamage = 0.9F;
    private const float DefaultCosmoWhalesDamage = 1F;
    private const float DefaultAntimatterFlashDamage = 1F;

    public BodySizeMedium()
    {
        Damage = new DeflectDamageList(DefaultAsteroidDamage, DefaultMeteoriteDamage, DefaultCosmoWhalesDamage, DefaultAntimatterFlashDamage);
    }
}