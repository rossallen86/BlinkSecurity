namespace BlinkClient.Model;

public class Verification
{
    public EmailVerification Email { get; set; } = default!;
    public PhoneVerification Phone { get; set; } = default!;
}
