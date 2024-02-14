using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.BodySize.Models;

public abstract class BodySize
{
    public DeflectDamageList? Damage { get; protected init; }
}