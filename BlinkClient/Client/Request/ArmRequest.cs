using BlinkClient.Dtos;

namespace BlinkClient.Client.Request;

public class ArmRequestDto
{
    public int account_id { get; set; } = default!;
    public int network_id { get; set; } = default!;
    public AuthDto auth { get; set; } = default!;
    public bool enable { get; set; }
}
