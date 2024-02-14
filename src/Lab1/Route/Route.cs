using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Result.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route;

public class Route
{
    private readonly List<Environment.Models.Environment> _ways;

    public Route(IEnumerable<Environment.Models.Environment> environments)
    {
        _ways = environments.ToList();
    }

    public RouteResult CalculateRoute(SpaceShip.Models.SpaceShip? ship)
    {
        if (ship is null) return new RouteResult("Ship loss");
        var result = new RouteResult("Success");

        foreach (Environment.Models.Environment way in _ways)
        {
            PathResult driveResult = ship.Drive(way);
            if (way is HighDensityNebula)
                result.GravityMatterFuel += driveResult.Fuel;
            else
                result.ActivePlasmaFuel += driveResult.Fuel;

            if (driveResult.Status != "Success") result.Status = driveResult.Status;
            result.Time += driveResult.Time;
        }

        result.Fuel = result.ActivePlasmaFuel + result.GravityMatterFuel;
        return result;
    }
}