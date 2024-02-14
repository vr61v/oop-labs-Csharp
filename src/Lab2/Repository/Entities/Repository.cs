using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repository.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository.Entities;

public class Repository : IRepository
{
    private static Repository? _instance;
    private readonly RepositoryData? _data = new RepositoryData();
    private Repository() { }

    public static Repository Instance
    {
        get
        {
            _instance ??= new Repository();
            return _instance;
        }
    }

    public void Append(IComponent? component)
    {
        if (component is null || _data?.DataBase is null) return;

        if (_data.DataBase.TryGetValue(component.ComponentType().GetHashCode(), out IList<IComponent>? value))
            value?.Add(component);
        else
            _data?.DataBase.Add(component.ComponentType().GetHashCode(), new List<IComponent>() { component });
    }

    public void Remove(IComponent? component)
    {
        if (component is null || _data?.DataBase is null) return;
        if (_data.DataBase.TryGetValue(component.ComponentType().GetHashCode(), out IList<IComponent>? value))
            value?.Remove(component);
    }

    public void Clear()
    {
        if (_data?.DataBase is null) return;
        _data.DataBase.Clear();
    }

    public IEnumerable<IComponent>? GetCurrentTypeData(ComponentType type)
    {
        return _data?.DataBase[type.GetHashCode()];
    }

    public IReadOnlyDictionary<string, IList<IComponent>>? Data()
    {
        return _data?.DataBase as IReadOnlyDictionary<string, IList<IComponent>>;
    }
}