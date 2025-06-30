using BlinkClient.Dtos;

namespace BlinkClient.Client.Request;

public class HomeScreenRequestDto
{
    public int account_id { get; set; }
    public AuthDto auth { get; set; } = default!;
}
