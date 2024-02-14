using Itmo.ObjectOrientedProgramming.Lab1.Armor.BodyArmor.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Armor.BodySize.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.ImpulseEngine.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.JumpEngine.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Result.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Models;

public abstract class SpaceShip
{
    protected ImpulseEngine? Impulse { get; init; }
    protected JumpEngine? Jump { get; init; }
    protected Armor.Deflectors.Models.Deflectors? Deflectors { get; init; }
    protected BodyArmor? Armor { get; init; }
    protected BodySize? BodySize { get; init; }
    protected bool AntiNitrateEmitter { get; init; }

    public PathResult Drive(Environment.Models.Environment? environment)
    {
        if (environment is null) return new PathResult("Ship loss");
        var result = new PathResult("Success");

        CalculateFuel(environment, result);
        if (result.Status != "Success") return result;

        if (environment is NeutrinoParticleNebula && AntiNitrateEmitter) return result;
        ShipTakeDamage(environment, result);

        return result;
    }

    private void ShipTakeDamage(Environment.Models.Environment environment, PathResult result)
    {
        if (environment.Obstacle is null)
        {
            result.Status = "Ship loss";
            return;
        }

        foreach (IObstacle obstacle in environment.Obstacle)
        {
            string obstacleName = $"{obstacle.GetTypeObstacle().Name}";
            float damage = 0;

            if (Deflectors is { IsShipAlive: true, IsPeopleAlive: true })
            {
                if (Deflectors.Damage?.TakeDamage is not null) damage = 100F / Deflectors.Damage.TakeDamage[obstacleName];
                if (BodySize?.Damage?.DeflectDamage is not null) damage *= BodySize.Damage.DeflectDamage[obstacleName];
                Deflectors.TakeDamage(obstacle, damage);
            }
            else if (Armor is not null)
            {
                if (Armor.Damage?.TakeDamage is not null) damage = 100F / Armor.Damage.TakeDamage[obstacleName];
                if (BodySize?.Damage?.DeflectDamage is not null) damage *= BodySize.Damage.DeflectDamage[obstacleName];
                Armor.TakeDamage(obstacle, damage);
            }
        }

        if (Deflectors is { IsPeopleAlive: false }) result.Status = "People dead";
        else if (Deflectors is { IsShipAlive: false }) result.Status = "Ship dead";
        else if (Armor is { IsShipAlive: false }) result.Status = "Ship dead";
        else result.Status = "Success";
    }

    private void CalculateFuel(Environment.Models.Environment environment, PathResult result)
    {
        if (environment is Space or NeutrinoParticleNebula)
            CalculateFuelForImpulse(environment, result);
        else if (environment is HighDensityNebula)
            CalculateFuelForJump(environment, result);
    }

    private void CalculateFuelForImpulse(Environment.Models.Environment environment, Result.Models.Result result)
    {
        if (Impulse is null)
        {
            result.Status = "Ship loss";
            return;
        }

        int length = 0;
        int time = 1;
        while (length + (time * Impulse.Speed(time)) <= environment.Length)
        {
            length += time * Impulse.Speed(time);
            time++;
        }

        result.Time = time - 1;
        result.Fuel = length * Impulse.FuelConsumption;
    }

    private void CalculateFuelForJump(Environment.Models.Environment environment, PathResult result)
    {
        if (Jump is null)
        {
            result.Status = "Ship loss";
            return;
        }

        int length = 0;
        int time = 1;
        int fuel = 0;
        while (length + (time * Jump.Speed) <= environment.Length)
        {
            int pathLength = time * Jump.Speed;
            length += pathLength;
            fuel += pathLength * Jump.FuelConsumption(time).Value / 1000;
            time++;
        }

        result.Time = time;
        result.Fuel = fuel;
        if (Jump.FuelCapacity is not null && fuel > Jump.FuelCapacity.Value)
            result.Status = "Ship loss";
    }
}