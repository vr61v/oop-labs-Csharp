using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.WiFiAdapter;

public class WiFiAdapter : IComponent
{
    public WiFiAdapter(int voltage, bool isBluetoothModule, VersionWiFi? versionWiFi, VersionPci? versionPci)
    {
        Voltage = voltage;
        IsBluetoothModule = isBluetoothModule;
        VersionWiFi = versionWiFi;
        VersionPci = versionPci;
    }

    public int Voltage { get; private set; }
    public bool IsBluetoothModule { get; private set; }
    public VersionWiFi? VersionWiFi { get; private set; }
    public VersionPci? VersionPci { get; private set; }

    public ComponentType ComponentType()
    {
        return Models.ComponentType.WiFiAdapter;
    }

    public ComponentInfo Info()
    {
        return new ComponentInfo(
            $"\nWI-FI ADAPTER INFO:\n" +
            $"\tVoltage: {Voltage}W\n" +
            $"\tIs bluetooth module: {IsBluetoothModule}\n" +
            $"\tVersion Wi-Fi: {VersionWiFi}\n" +
            $"\tVersion pci: {VersionPci}\n");
    }
}