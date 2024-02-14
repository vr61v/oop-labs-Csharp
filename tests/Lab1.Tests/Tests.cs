using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Tests
{
    public static IEnumerable<object[]> DataCalculateRoute => new List<object[]>
        {
            new object[]
            {
                new Route.Route(new List<HighDensityNebula>() { new HighDensityNebula(5000000, new List<Meteorite>() { new Meteorite(), }), }),
                new List<SpaceShip.Models.SpaceShip>() { new WalkingShuttle(), new Augur() },
                new List<string>() { "Ship loss", "Ship loss" },
            },
            new object[]
            {
                new Route.Route(new List<HighDensityNebula>() { new HighDensityNebula(new List<AntimatterFlash>() { new AntimatterFlash(), }), }),
                new List<SpaceShip.Models.SpaceShip>() { new Valakas(), new Valakas(300000, 50000, true, false) },
                new List<string>() { "People dead", "Success" },
            },
            new object[]
            {
                new Route.Route(new List<NeutrinoParticleNebula>() { new NeutrinoParticleNebula(new List<CosmoWhales>() { new CosmoWhales(), }), }),
                new List<SpaceShip.Models.SpaceShip>() { new Valakas(), new Augur(), new Meredian(), },
                new List<string>() { "Ship dead", "Success", "Success" },
            },
        };

    public static IEnumerable<object[]> DataCalculateBestShip => new List<object[]>
    {
        new object[]
        {
            new SpaceResearchOrganisation.SpaceResearchOrganisation(
                new Route.Route(new List<Space>() { new Space(250000, new List<Meteorite>()), }),
                new List<SpaceShip.Models.SpaceShip>() { new WalkingShuttle(), new Valakas(), }),
            typeof(WalkingShuttle),
        },
        new object[]
        {
            new SpaceResearchOrganisation.SpaceResearchOrganisation(
                new Route.Route(new List<HighDensityNebula>() { new HighDensityNebula(new List<AntimatterFlash>()), }),
                new List<SpaceShip.Models.SpaceShip>() { new Augur(), new Stella(), }),
            typeof(Stella),
        },
        new object[]
        {
            new SpaceResearchOrganisation.SpaceResearchOrganisation(
                new Route.Route(new List<NeutrinoParticleNebula>() { new NeutrinoParticleNebula(new List<CosmoWhales>() { new CosmoWhales(), }), }),
                new List<SpaceShip.Models.SpaceShip>() { new WalkingShuttle(), new Valakas(), }),
            typeof(Valakas),
        },
    };

    [Theory]
    [MemberData(nameof(DataCalculateRoute))]
    public void CalculateRoute(Route.Route? route, IList<SpaceShip.Models.SpaceShip>? spaceShips, IList<string>? results)
    {
        if (spaceShips is null || route is null || results is null) return;
        var shipResults = new List<string>();
        foreach (SpaceShip.Models.SpaceShip t in spaceShips)
        {
            string? status = route.CalculateRoute(t).Status;
            if (status is not null) shipResults.Add(status);
        }

        Assert.Equal(results, shipResults);
    }

    [Theory]
    [MemberData(nameof(DataCalculateBestShip))]
    public void CalculateBestShip(SpaceResearchOrganisation.SpaceResearchOrganisation? sro, Type? result)
    {
        if (sro is null) return;
        SpaceShip.Models.SpaceShip? bestShip = sro.CalculateBestShip();
        Assert.Equal(result, bestShip?.GetType());
    }
}