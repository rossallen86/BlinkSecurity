namespace BlinkClient.Model;

public class Network
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; } = default!;
    public string TimeZone { get; set; } = default!;
    public bool Dst { get; set; }
    public bool Armed { get; set; }
    public bool LvSave { get; set; }
}