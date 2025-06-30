using BlinkClient.Model;

namespace BlinkClient.Dtos;

public class MediaDto
{
    public int id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public bool deleted { get; set; }
    public string device { get; set; } = default!;
    public int device_id { get; set; }
    public string device_name { get; set; } = default!;
    public int network_id { get; set; }
    public string network_name { get; set; } = default!;
    public string type { get; set; } = default!;
    public string source { get; set; } = default!;
    public bool partial { get; set; }
    public bool watched { get; set; }
    public string thumbnail { get; set; } = default!;
    public string media { get; set; } = default!;
    public string metadata { get; set; } = default!;
    public List<object> additional_devices { get; set; } = new();
    public string time_zone { get; set; } = default!;
}
