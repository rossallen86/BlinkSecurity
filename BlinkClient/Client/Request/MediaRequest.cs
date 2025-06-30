using BlinkClient.Dtos;

namespace BlinkClient.Client.Request;

public class MediaRequestDto
{
    public int account_id { get; set; } = default!;
    public AuthDto auth { get; set; } = default!;
    public DateTime since { get; set; }
    public int page { get; set; }
}
