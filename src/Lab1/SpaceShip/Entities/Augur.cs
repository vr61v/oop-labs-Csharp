using Itmo.ObjectOrientedProgramming.Lab1.Armor.BodyArmor.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Armor.BodySize.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Armor.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.ImpulseEngine.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngine.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;

public class Augur : Models.SpaceShip
{
    private const int ActivePlasmaCount = 300000;
    private const int GravityMatterCount = 20000;
    private const bool IsPhotonDeflectors = false;
    private const bool IsAntiNitrateEmitter = false;

    public Augur()
        : this(ActivePlasmaCount, GravityMatterCount, IsPhotonDeflectors, IsAntiNitrateEmitter) { }

    public Augur(int activePlasmaCount, int gravityMatterCount, bool photonDeflectors, bool antiNitrateEmitter)
    {
        Impulse = new ImpulseEngineClassE(activePlasmaCount);
        Jump = new JumpEngineAlpha(gravityMatterCount);
        Deflectors = new DeflectorsClass3(photonDeflectors);
        Armor = new BodyArmorClass3();
        AntiNitrateEmitter = antiNitrateEmitter;
        BodySize = new BodySizeLarge();
    }
}