using BlinkClient.Dtos;

namespace BlinkClient.Client.Request;

public class OptionsRequestDto
{
    public int account_id { get; set; }
    public int client_id { get; set; }
    public AuthDto auth { get; set; } = default!;
}