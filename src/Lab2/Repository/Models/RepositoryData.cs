using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.Models;

public class RepositoryData
{
    public IDictionary<int, IList<IComponent>?> DataBase { get; private set; } =
        new Dictionary<int, IList<IComponent>?>();
}