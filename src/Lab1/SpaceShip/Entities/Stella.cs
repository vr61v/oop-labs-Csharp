using Itmo.ObjectOrientedProgramming.Lab1.Armor.BodyArmor.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Armor.BodySize.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Armor.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.ImpulseEngine.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngine.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;

public class Stella : Models.SpaceShip
{
    private const int ActivePlasmaCount = 100000;
    private const int GravityMatterCount = 30000;
    private const bool IsPhotonDeflectors = false;
    private const bool IsAntiNitrateEmitter = false;

    public Stella()
        : this(ActivePlasmaCount, GravityMatterCount, IsPhotonDeflectors, IsAntiNitrateEmitter) { }
    public Stella(int activePlasmaCount, int gravityMatterCount, bool photonDeflectors, bool antiNitrateEmitter)
    {
        Impulse = new ImpulseEngineClassC(activePlasmaCount);
        Jump = new JumpEngineOmega(gravityMatterCount);
        Deflectors = new DeflectorsClass1(photonDeflectors);
        Armor = new BodyArmorClass1();
        AntiNitrateEmitter = antiNitrateEmitter;
        BodySize = new BodySizeSmall();
    }
}