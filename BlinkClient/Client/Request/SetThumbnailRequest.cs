using BlinkClient.Dtos;

namespace BlinkClient.Client.Request;

public class SetThumbnailRequestDto
{
    public int account_id { get; set; } = default!;
    public int network_id { get; set; } = default!;
    public int camera_id { get; set; }
    public AuthDto auth { get; set; } = default!;
}
