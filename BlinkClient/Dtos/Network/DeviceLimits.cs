using BlinkClient.Model;

namespace BlinkClient.Dtos;

public class DeviceLimitsDto
{
    public int camera { get; set; }
    public int chime { get; set; }
    public int doorbell { get; set; }
    public int doorbellButton { get; set; }
    public int owl { get; set; }
    public int siren { get; set; }
    public int total_devices { get; set; }
}

