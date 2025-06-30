namespace BlinkClient.Model;

public class Doorbell
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
    public string Battery { get; set; } = default!;
    public string DoorbellMode { get; set; } = default!;
    public bool ChangingMode { get; set; }
    public Dictionary<string, int> Signals { get; set; } = new();
    public List<string> Issues { get; set; } = new();
    public bool LocalStorageEnabled { get; set; }
    public bool LocalStorageCompatible { get; set; }
    public bool ConfigOutOfSync { get; set; }
    public bool Snooze { get; set; }
    public object? SnoozeTimeRemaining { get; set; }
    public string Revision { get; set; } = default!;
    public string Color { get; set; } = default!;
}
