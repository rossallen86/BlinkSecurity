namespace BlinkClient.Client.Response;

public class PinVerificationResponse
{
    public bool Valid { get; set; }
    public bool RequireNewPin { get; set; }
    public string Message { get; set; } = default!;
    public int Code { get; set; }
}

public class PinVerificationResponseDto
{
    public bool valid { get; set; }
    public bool require_new_pin { get; set; }
    public string message { get; set; } = default!;
    public int code { get; set; }
}
