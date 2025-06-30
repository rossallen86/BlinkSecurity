namespace BlinkClient.Client.Request;

public class LoginRequestDto
{
    public string email { get; set; } = default!;
    public string password { get; set; } = default!;
    public bool reauth { get; set; }
}
