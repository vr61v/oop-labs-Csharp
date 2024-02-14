using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Interfaces;
namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Entities;

public class Meteorite : IObstacle
{
    public Type GetTypeObstacle()
    {
        return typeof(Meteorite);
    }
}