using Itmo.ObjectOrientedProgramming.Lab1.Armor.BodyArmor.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Armor.BodySize.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.ImpulseEngine.Entities;
namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;

public class WalkingShuttle : Models.SpaceShip
{
    private const int ActivePlasmaCount = 100000;
    private const bool IsAntiNitrateEmitter = false;

    public WalkingShuttle()
        : this(ActivePlasmaCount, IsAntiNitrateEmitter) { }
    public WalkingShuttle(int activePlasmaCount, bool antiNitrateEmitter)
    {
        Impulse = new ImpulseEngineClassC(activePlasmaCount);
        Jump = null;
        Deflectors = null;
        Armor = new BodyArmorClass1();
        AntiNitrateEmitter = antiNitrateEmitter;
        BodySize = new BodySizeSmall();
    }
}