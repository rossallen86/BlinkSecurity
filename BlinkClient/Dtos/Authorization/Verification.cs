namespace BlinkClient.Dtos;
public class VerificationDto
{
    public EmailVerificationDto email { get; set; } = default!;
    public PhoneVerificationDto phone { get; set; } = default!;
}
