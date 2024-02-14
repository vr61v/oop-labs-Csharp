using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.WiFiAdapter;

public interface IWiFiAdapterBuilder
{
    public WiFiAdapterBuilder WithVoltage(int voltage);
    public WiFiAdapterBuilder WithIsBluetoothModule(bool isBluetoothModule);
    public WiFiAdapterBuilder WithVersionWiFi(VersionWiFi? versionWiFi);
    public WiFiAdapterBuilder WithVersionPci(VersionPci? versionPci);

    public WiFiAdapterBuilder BaseOn(WiFiAdapter? component);
    public WiFiAdapter Build();
}