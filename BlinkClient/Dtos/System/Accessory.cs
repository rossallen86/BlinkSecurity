using BlinkClient.Model;

namespace BlinkClient.Dtos;

public class AccessoryDto
{
    public int id { get; set; }
    public string serial { get; set; } = default!;
    public string type { get; set; } = default!;
    public bool connected { get; set; }
    public bool calibrated { get; set; }
    public string power_type { get; set; } = default!;
    public string battery { get; set; } = default!;
    public string target { get; set; } = default!;
    public int target_id { get; set; }
    public DateTime created_at { get; set; }
    public string revision { get; set; } = default!;
}
