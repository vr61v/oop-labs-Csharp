using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.BodyArmor.Entities;

public class BodyArmorClass3 : Models.BodyArmor
{
    private const float DefaultAsteroidDamage = 20F;
    private const float DefaultMeteoriteDamage = 5F;
    private const float DefaultCosmoWhalesDamage = 0.5F;
    private const float DefaultAntimatterFlashDamage = 0.5F;

    public BodyArmorClass3()
    {
        IsShipAlive = true;
        Damage = new TakeDamageList(DefaultAsteroidDamage, DefaultMeteoriteDamage, DefaultCosmoWhalesDamage, DefaultAntimatterFlashDamage);
    }
}