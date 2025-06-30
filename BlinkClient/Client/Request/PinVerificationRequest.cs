using BlinkClient.Dtos;

namespace BlinkClient.Client.Request;

public class PinVerificationRequestDto
{
    public int account_id { get; set; }
    public int client_id { get; set; }
    public PinVerificationRequestBodyDto body { get; set; } = default!;
    public AuthDto auth { get; set; } = default!;
}

public class PinVerificationRequestBodyDto
{
    public int pin { get; set; }
}