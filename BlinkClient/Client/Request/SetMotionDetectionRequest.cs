using BlinkClient.Dtos;

namespace BlinkClient.Client.Request;

public class SetMotionDetectionRequestDto
{
    public bool enable { get; set; }
    public int network_id { get; set; }
    public int camera_id { get; set; }
    public AuthDto auth { get; set; } = default!;
}
