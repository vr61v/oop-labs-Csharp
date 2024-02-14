using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.Deflectors.Entities;

public class DeflectorsClass3 : Armor.Deflectors.Models.Deflectors
{
    private const float DefaultAsteroidDamage = 40F;
    private const float DefaultMeteoriteDamage = 10F;
    private const float DefaultCosmoWhalesDamage = 1F;
    private const float DefaultAntimatterFlashDamage = 0.5F;
    private const float DefaultAntimatterFlashDamageWithPhotonDeflectors = 3F;

    public DeflectorsClass3()
        : this(false) { }
    public DeflectorsClass3(bool photonDeflectors)
    {
        IsShipAlive = true;
        IsPeopleAlive = true;
        Damage = new TakeDamageList(DefaultAsteroidDamage, DefaultMeteoriteDamage, DefaultCosmoWhalesDamage, photonDeflectors ? DefaultAntimatterFlashDamageWithPhotonDeflectors : DefaultAntimatterFlashDamage);
    }
}