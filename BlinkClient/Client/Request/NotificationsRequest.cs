using BlinkClient.Dtos;

namespace BlinkClient.Client.Request;

public class NotificationsRequestDto
{
    public int account_id { get; set; } = default!;
    public AuthDto auth { get; set; } = default!;
}