using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.BodyArmor.Entities;

public class BodyArmorClass2 : Models.BodyArmor
{
    private const float DefaultAsteroidDamage = 5F;
    private const float DefaultMeteoriteDamage = 2F;
    private const float DefaultCosmoWhalesDamage = 0.5F;
    private const float DefaultAntimatterFlashDamage = 0.5F;

    public BodyArmorClass2()
    {
        IsShipAlive = true;
        Damage = new TakeDamageList(DefaultAsteroidDamage, DefaultMeteoriteDamage, DefaultCosmoWhalesDamage, DefaultAntimatterFlashDamage);
    }
}