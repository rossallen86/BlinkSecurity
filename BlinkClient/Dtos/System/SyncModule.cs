using BlinkClient.Model;

namespace BlinkClient.Dtos;
public class SyncModuleDto
{
    public int id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public bool onboarded { get; set; }
    public string status { get; set; } = default!;
    public string name { get; set; } = default!;
    public string serial { get; set; } = default!;
    public string fw_version { get; set; } = default!;
    public string type { get; set; } = default!;
    public string subtype { get; set; } = default!;
    public DateTime last_hb { get; set; }
    public int wifi_strength { get; set; }
    public int network_id { get; set; }
    public bool enable_temp_alerts { get; set; }
    public bool local_storage_enabled { get; set; }
    public bool local_storage_compatible { get; set; }
    public string local_storage_status { get; set; } = default!;
    public string revision { get; set; } = default!;
};