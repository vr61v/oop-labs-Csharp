using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.BodySize.Entities;

public class BodySizeLarge : Models.BodySize
{
    private const float DefaultAsteroidDamage = 0.6F;
    private const float DefaultMeteoriteDamage = 0.75F;
    private const float DefaultCosmoWhalesDamage = 0.9F;
    private const float DefaultAntimatterFlashDamage = 1F;

    public BodySizeLarge()
    {
        Damage = new DeflectDamageList(DefaultAsteroidDamage, DefaultMeteoriteDamage, DefaultCosmoWhalesDamage, DefaultAntimatterFlashDamage);
    }
}