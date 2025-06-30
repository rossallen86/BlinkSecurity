namespace BlinkClient.Model;

public class Media
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Deleted { get; set; }
    public string Device { get; set; } = default!;
    public int DeviceId { get; set; }
    public string DeviceName { get; set; } = default!;
    public int NetworkId { get; set; }
    public string NetworkName { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Source { get; set; } = default!;
    public bool Partial { get; set; }
    public bool Watched { get; set; }
    public string Thumbnail { get; set; } = default!;
    public string MediaUrl { get; set; } = default!;
    public string Metadata { get; set; } = default!;
    public List<object> AdditionalDevices { get; set; } = new();
    public string TimeZone { get; set; } = default!;
}
