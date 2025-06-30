using BlinkClient.Dtos;

namespace BlinkClient.Client.Request;

public class SetNotificationsRequestDto
{
    public int account_id { get; set; }
    public AuthDto auth { get; set; } = default!;
    public Dictionary<string, string> notifications { get; set; } = new();
}
