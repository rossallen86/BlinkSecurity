namespace BlinkClient.Model;

public class AppUpdates
{
    public string Message { get; set; } = default!;
    public int Code { get; set; }
    public bool UpdateAvailable { get; set; }
    public bool UpdateRequired { get; set; }
}
