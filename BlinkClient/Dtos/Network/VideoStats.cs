using BlinkClient.Model;

namespace BlinkClient.Dtos;

public class VideoStatsDto
{
    public int Storage { get; set; }
    public int AutoDeleteDays { get; set; }
    public List<int> AutoDeleteDayOptions { get; set; } = new();
}

