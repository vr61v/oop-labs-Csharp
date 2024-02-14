using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Result.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceResearchOrganisation;

public class SpaceResearchOrganisation
{
    private const int PriceActivePlasma = 2;
    private const int PriceGravityMatter = 3;

    public SpaceResearchOrganisation(Route.Route route, IEnumerable<SpaceShip.Models.SpaceShip> ships)
    {
        Route = route;
        Ships = ships.ToList();
    }

    private Route.Route Route { get; }
    private List<SpaceShip.Models.SpaceShip> Ships { get; }

    public SpaceShip.Models.SpaceShip? CalculateBestShip()
    {
        var results = new List<RouteResult>();
        foreach (SpaceShip.Models.SpaceShip ship in Ships)
            results.Add(Route.CalculateRoute(ship));

        var bestShip = new List<OrganisationResult>();
        for (int i = 0; i < results.Count; i++)
        {
            var result = new OrganisationResult
            {
                Fuel = results[i].Fuel,
                Price = (results[i].ActivePlasmaFuel * PriceActivePlasma) + (results[i].GravityMatterFuel * PriceGravityMatter),
                Status = results[i].Status,
                Ship = Ships[i],
                Time = results[i].Time,
            };
            bestShip.Add(result);
        }

        var sortedBestShip = bestShip
            .OrderBy(x => x.Time)
            .ThenBy(y => y.Price)
            .ToList();

        return sortedBestShip[0].Ship;
    }
}