using BlinkClient.Dtos;

namespace BlinkClient.Client.Request;

public class LogoutRequestDto
{
    public int account_id { get; set; }
    public int client_id { get; set; }
    public AuthDto auth { get; set; } = default!;
}
