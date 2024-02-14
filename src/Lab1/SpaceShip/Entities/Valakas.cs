using Itmo.ObjectOrientedProgramming.Lab1.Armor.BodyArmor.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Armor.BodySize.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Armor.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.ImpulseEngine.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngine.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;

public class Valakas : Models.SpaceShip
{
    private const int ActivePlasmaCount = 300000;
    private const int GravityMatterCount = 50000;
    private const bool IsPhotonDeflectors = false;
    private const bool IsAntiNitrateEmitter = false;

    public Valakas()
        : this(ActivePlasmaCount, GravityMatterCount, IsPhotonDeflectors, IsAntiNitrateEmitter) { }
    public Valakas(int activePlasmaCount, int gravityMatterCount, bool photonDeflectors, bool antiNitrateEmitter)
    {
        Impulse = new ImpulseEngineClassE(activePlasmaCount);
        Jump = new JumpEngineGamma(gravityMatterCount);
        Deflectors = new DeflectorsClass1(photonDeflectors);
        Armor = new BodyArmorClass2();
        AntiNitrateEmitter = antiNitrateEmitter;
        BodySize = new BodySizeMedium();
    }
}