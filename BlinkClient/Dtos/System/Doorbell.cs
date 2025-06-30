using BlinkClient.Model;

namespace BlinkClient.Dtos;

public class DoorbellDto
{
    public int id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public string name { get; set; } = default!;
    public string type { get; set; } = default!;
    public bool onboarded { get; set; }
    public string serial { get; set; } = default!;
    public string fw_version { get; set; } = default!;
    public bool enabled { get; set; }
    public string thumbnail { get; set; } = default!;
    public string status { get; set; } = default!;
    public int network_id { get; set; }
    public string battery { get; set; } = default!;
    public string doorbell_mode { get; set; } = default!;
    public bool changing_mode { get; set; }
    public Dictionary<string, int> signals { get; set; } = new();
    public List<string> issues { get; set; } = new();
    public bool local_storage_enabled { get; set; }
    public bool local_storage_compatible { get; set; }
    public bool config_out_of_sync { get; set; }
    public bool snooze { get; set; }
    public object snooze_time_remaining { get; set; } = default!;
    public string revision { get; set; } = default!;
    public string color { get; set; } = default!;
}