namespace BlinkClient.Model;

public class PhoneVerification
{
    public bool Required { get; set; }
    public string Channel { get; set; } = default!;
}
