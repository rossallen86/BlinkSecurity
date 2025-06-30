using BlinkClient.Dtos;

namespace BlinkClient.Client.Request;

public class UpdateClientOptionsRequestDto
{
    public int client_id { get; set; }
    public AuthDto auth { get; set; } = default!;
    public string body { get; set; } = default!;
}

