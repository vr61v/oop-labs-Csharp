using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public interface IRepository
{
    public void Append(IComponent component);
    public void Remove(IComponent component);
    public void Clear();
}