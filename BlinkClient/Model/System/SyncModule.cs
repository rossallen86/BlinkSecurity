namespace BlinkClient.Model;

public class SyncModule
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Onboarded { get; set; }
    public string Status { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Serial { get; set; } = default!;
    public string FirmwareVersion { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Subtype { get; set; } = default!;
    public DateTime LasHB { get; set; }
    public int WifiStrength { get; set; }
    public int NetworkId { get; set; }
    public bool EnableTempAlerts { get; set; }
    public bool LocalStorageEnabled { get; set; }
    public bool LocalStorageCompatible { get; set; }
    public string LocalStorageStatus { get; set; } = default!;
    public string Revision { get; set; } = default!;
}
