using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.Motherboard;

public class Motherboard : IComponent
{
    public Motherboard(Socket? socket, TypeDdr? typeDdr, FormFactor? formFactor, Chipset? typeChipset, Bios? typeBios, int countPci, int countSata, int countDdr)
    {
        Socket = socket;
        TypeDdr = typeDdr;
        FormFactor = formFactor;
        TypeChipset = typeChipset;
        TypeBios = typeBios;
        CountPci = countPci;
        CountSata = countSata;
        CountDdr = countDdr;
    }

    public Socket? Socket { get; private set; }
    public TypeDdr? TypeDdr { get; private set; }
    public FormFactor? FormFactor { get; private set; }
    public Chipset? TypeChipset { get; private set; }
    public Bios? TypeBios { get; private set; }
    public int CountPci { get; private set; }
    public int CountSata { get; private set; }
    public int CountDdr { get; private set; }

    public ComponentType ComponentType()
    {
        return Components.Models.ComponentType.Motherboard;
    }

    public ComponentInfo Info()
    {
        return new ComponentInfo(
            $"\nMOTHERBOARD INFO:\n" +
            $"\tSocket: {Socket}\n" +
            $"\tType ddr: {TypeDdr}\n" +
            $"\tForm factor: {FormFactor}\n" +
            $"\tChipset: " +
                $"frequency: {TypeChipset?.AvailableXmp.Frequency}Hz, " +
                $"latency: {TypeChipset?.AvailableXmp.Latency.Ras}-{TypeChipset?.AvailableXmp.Latency.RasRecharge}-{TypeChipset?.AvailableXmp.Latency.RasT}-{TypeChipset?.AvailableXmp.Latency.RcT}, " +
                $"voltage: {TypeChipset?.AvailableXmp.Voltage}W\n" +
            $"\tBios: type: {TypeBios?.Type}, version{TypeBios?.Version}\n" +
            $"\tCount psi: {CountPci}\n" +
            $"\tCount sata: {CountSata}\n" +
            $"\tCount ddr: {CountDdr}\n");
    }
}