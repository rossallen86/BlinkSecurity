namespace BlinkClient.Dtos;

public class NetworkDto
{
    public int id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public string name { get; set; } = default!;
    public string time_zone { get; set; } = default!;
    public bool dst { get; set; }
    public bool armed { get; set; }
    public bool lv_save { get; set; }
}
