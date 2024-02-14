using Itmo.ObjectOrientedProgramming.Lab1.Armor.BodyArmor.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Armor.BodySize.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Armor.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.ImpulseEngine.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;

public class Meredian : Models.SpaceShip
{
    private const int ActivePlasmaCount = 300000;
    private const bool IsPhotonDeflectors = false;
    private const bool IsAntiNitrateEmitter = true;

    public Meredian()
        : this(ActivePlasmaCount, IsPhotonDeflectors, IsAntiNitrateEmitter) { }
    public Meredian(int activePlasmaCount, bool photonDeflectors, bool antiNitrateEmitter)
    {
        Impulse = new ImpulseEngineClassE(activePlasmaCount);
        Jump = null;
        Deflectors = new DeflectorsClass2(photonDeflectors);
        Armor = new BodyArmorClass2();
        AntiNitrateEmitter = antiNitrateEmitter;
        BodySize = new BodySizeMedium();
    }
}