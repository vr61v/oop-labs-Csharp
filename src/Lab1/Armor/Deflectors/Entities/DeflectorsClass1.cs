using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.Deflectors.Entities;

public class DeflectorsClass1 : Armor.Deflectors.Models.Deflectors
{
    private const float DefaultAsteroidDamage = 2F;
    private const float DefaultMeteoriteDamage = 1F;
    private const float DefaultCosmoWhalesDamage = 0.5F;
    private const float DefaultAntimatterFlashDamage = 0.5F;
    private const float DefaultAntimatterFlashDamageWithPhotonDeflectors = 3F;

    public DeflectorsClass1()
        : this(false) { }
    public DeflectorsClass1(bool photonDeflectors)
    {
        IsShipAlive = true;
        IsPeopleAlive = true;
        Damage = new TakeDamageList(DefaultAsteroidDamage, DefaultMeteoriteDamage, DefaultCosmoWhalesDamage, photonDeflectors ? DefaultAntimatterFlashDamageWithPhotonDeflectors : DefaultAntimatterFlashDamage);
    }
}