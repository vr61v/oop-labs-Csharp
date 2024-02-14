using Itmo.ObjectOrientedProgramming.Lab1.Armor.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Armor.BodySize.Entities;

public class BodySizeSmall : Models.BodySize
{
    public BodySizeSmall()
    {
        Damage = new DeflectDamageList();
    }
}