using BlinkClient.Dtos;

namespace BlinkClient.Client.Request;

public class LiveStreamRequestDto
{
    public int account_id { get; set; }
    public int network_id { get; set; }
    public int camera_id { get; set; }
    public AuthDto auth { get; set; } = default!;
    public LiveViewRequestBodyDto body { get; set; } = new();
}

public class LiveViewRequestBodyDto
{
    public string intent { get; set; } = "liveview";
    public string motion_event_start_time { get; set; } = string.Empty;
}