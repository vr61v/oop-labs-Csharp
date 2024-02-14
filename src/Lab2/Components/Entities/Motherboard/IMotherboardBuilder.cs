using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Motherboard;

public interface IMotherboardBuilder
{
    public MotherboardBuilder WithSocket(Socket? socket);
    public MotherboardBuilder WithTypeDdr(TypeDdr? typeDdr);
    public MotherboardBuilder WithFromFactor(FormFactor? fromFactor);
    public MotherboardBuilder WithTypeChipset(Chipset? typeChipset);
    public MotherboardBuilder WithTypeBios(Bios? typeBios);
    public MotherboardBuilder WithCountPsi(int countPsi);
    public MotherboardBuilder WithCountSata(int countSata);
    public MotherboardBuilder WithCountDdr(int countDdr);

    public MotherboardBuilder BaseOn(Motherboard? component);
    public Motherboard Build();
}