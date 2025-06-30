using BlinkClient.Dtos;

namespace BlinkClient.Client.Request;

public class CommandRequestDto
{
    public int network_id { get; set; }
    public int command_id { get; set; }
    public AuthDto auth { get; set; } = default!;
}
