using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Client.Response;

public class LoginResponse
{
    public Account Account { get; set; } = default!;
    public Auth Auth { get; set; } = default!;
    public Phone Phone { get; set; } = default!;
    public Verification Verification { get; set; } = default!;
    public int LockoutTimeRemaining { get; set; }
    public bool ForcePasswordReset { get; set; }
    public int AllowPinResendSeconds { get; set; }

    public bool IsValid => Account != null && Auth != null && Phone != null && Verification != null;
}

public class LoginResponseDto
{
    public AccountDto account { get; set; } = default!;
    public AuthDto auth { get; set; } = default!;
    public PhoneDto phone { get; set; } = default!;
    public VerificationDto verification { get; set; } = default!;
    public int lockout_time_remaining { get; set; }
    public bool force_password_reset { get; set; }
    public int allow_pin_resend_seconds { get; set; }
}
