using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.Deflectors.Entities;

public class DeflectorsClass2 : Armor.Deflectors.Models.Deflectors
{
    private const float DefaultAsteroidDamage = 10F;
    private const float DefaultMeteoriteDamage = 3F;
    private const float DefaultCosmoWhalesDamage = 0.5F;
    private const float DefaultAntimatterFlashDamage = 0.5F;
    private const float DefaultAntimatterFlashDamageWithPhotonDeflectors = 3F;

    public DeflectorsClass2()
        : this(false) { }
    public DeflectorsClass2(bool photonDeflectors)
    {
        IsShipAlive = true;
        IsPeopleAlive = true;
        Damage = new TakeDamageList(DefaultAsteroidDamage, DefaultMeteoriteDamage, DefaultCosmoWhalesDamage, photonDeflectors ? DefaultAntimatterFlashDamageWithPhotonDeflectors : DefaultAntimatterFlashDamage);
    }
}