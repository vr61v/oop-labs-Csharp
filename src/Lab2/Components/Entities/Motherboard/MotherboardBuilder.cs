using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Motherboard;

public class MotherboardBuilder : IMotherboardBuilder
{
    private Socket? _socket;
    private TypeDdr? _typeDdr;
    private FormFactor? _fromFactor;
    private Chipset? _typeChipset;
    private Bios? _typeBios;
    private int _countPsi;
    private int _countSata;
    private int _countDdr;

    public MotherboardBuilder WithSocket(Socket? socket)
    {
        _socket = socket;
        return this;
    }

    public MotherboardBuilder WithTypeDdr(TypeDdr? typeDdr)
    {
        _typeDdr = typeDdr;
        return this;
    }

    public MotherboardBuilder WithFromFactor(FormFactor? fromFactor)
    {
        _fromFactor = fromFactor;
        return this;
    }

    public MotherboardBuilder WithTypeChipset(Chipset? typeChipset)
    {
        _typeChipset = typeChipset;
        return this;
    }

    public MotherboardBuilder WithTypeBios(Bios? typeBios)
    {
        _typeBios = typeBios;
        return this;
    }

    public MotherboardBuilder WithCountPsi(int countPsi)
    {
        _countPsi = countPsi;
        return this;
    }

    public MotherboardBuilder WithCountSata(int countSata)
    {
        _countSata = countSata;
        return this;
    }

    public MotherboardBuilder WithCountDdr(int countDdr)
    {
        _countDdr = countDdr;
        return this;
    }

    public MotherboardBuilder BaseOn(Motherboard? component)
    {
        _socket = component?.Socket;
        _typeDdr = component?.TypeDdr;
        _fromFactor = component?.FormFactor;
        _typeChipset = component?.TypeChipset;
        _typeBios = component?.TypeBios;
        _countPsi = component?.CountPci ?? 0;
        _countSata = component?.CountSata ?? 0;
        _countDdr = component?.CountDdr ?? 0;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _socket,
            _typeDdr,
            _fromFactor,
            _typeChipset,
            _typeBios,
            _countPsi,
            _countSata,
            _countDdr);
    }
}