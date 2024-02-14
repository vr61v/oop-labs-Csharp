using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Interfaces;
namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Entities;

public class AntimatterFlash : IObstacle
{
    public Type GetTypeObstacle()
    {
        return typeof(AntimatterFlash);
    }
}