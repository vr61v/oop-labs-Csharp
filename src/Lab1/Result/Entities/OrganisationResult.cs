namespace Itmo.ObjectOrientedProgramming.Lab1.Result.Entities;

public class OrganisationResult : Models.Result
{
    private const int DefaultTime = 0;
    private const SpaceShip.Models.SpaceShip? DefaultShip = null;
    public OrganisationResult()
        : this(DefaultTime, DefaultShip) { }
    public OrganisationResult(int price, SpaceShip.Models.SpaceShip? ship)
    {
        Price = price;
        Ship = ship;
    }

    public int Price { get; init; }
    public SpaceShip.Models.SpaceShip? Ship { get; init; }
}
