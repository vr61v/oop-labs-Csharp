using Itmo.ObjectOrientedProgramming.Lab2.Components.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Entities.WiFiAdapter;

public class WiFiAdapterBuilder : IWiFiAdapterBuilder
{
    private int _voltage;
    private bool _isBluetoothModule;
    private VersionWiFi? _versionWiFi;
    private VersionPci? _versionPci;

    public WiFiAdapterBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public WiFiAdapterBuilder WithIsBluetoothModule(bool isBluetoothModule)
    {
        _isBluetoothModule = isBluetoothModule;
        return this;
    }

    public WiFiAdapterBuilder WithVersionWiFi(VersionWiFi? versionWiFi)
    {
        _versionWiFi = versionWiFi;
        return this;
    }

    public WiFiAdapterBuilder WithVersionPci(VersionPci? versionPci)
    {
        _versionPci = versionPci;
        return this;
    }

    public WiFiAdapterBuilder BaseOn(WiFiAdapter? component)
    {
        _voltage = component?.Voltage ?? 0;
        _isBluetoothModule = component?.IsBluetoothModule ?? false;
        _versionWiFi = component?.VersionWiFi;
        _versionPci = component?.VersionPci;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _voltage,
            _isBluetoothModule,
            _versionWiFi,
            _versionPci);
    }
}