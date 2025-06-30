using BlinkClient.Model;

namespace BlinkClient.Dtos;
public class PhoneVerificationDto
{
    public bool required { get; set; }
    public string channel { get; set; } = default!;
}

