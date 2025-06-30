namespace BlinkClient.Model;

public class Owl
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public bool Onboarded { get; set; }
    public string Serial { get; set; } = default!;
    public string FirmwareVersion { get; set; } = default!;
    public bool Enabled { get; set; }
    public string Thumbnail { get; set; } = default!;
    public string Status { get; set; } = default!;
    public int NetworkId { get; set; }
    public bool LocalStorageEnabled { get; set; }
    public bool LocalStorageCompatible { get; set; }
    public bool Snooze { get; set; }
    public DateTime? SnoozeTimeRemaining { get; set; }
    public string Revision { get; set; } = default!;
    public string Color { get; set; } = default!;
}
