namespace BlinkClient.Model;

public class VideoStats
{
    public int Storage { get; set; }
    public int AutoDeleteDays { get; set; }
    public List<int> AutoDeleteDayOptions { get; set; } = new();

}
