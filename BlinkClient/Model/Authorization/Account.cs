namespace BlinkClient.Model;

public class Account
{
    public int AccountId { get; set; }
    public string Country { get; set; } = default!;
    public int UserId { get; set; }
    public int ClientId { get; set; }
    public bool ClientTrusted { get; set; }
    public bool NewAccount { get; set; }
    public string Tier { get; set; } = default!;
    public string Region { get; set; } = default!;
    public bool AccountVerificationRequired { get; set; }
    public bool PhoneVerificationRequired { get; set; }
    public bool ClientVerificationRequired { get; set; }
    public bool RequireTrustClientDevice { get; set; }
    public bool CountryRequired { get; set; }
    public string VerificationChannel { get; set; } = default!;
    public User User { get; set; } = default!;
    public bool AmazonAccountLinked { get; set; }
    public string BrazeExternalId { get; set; } = default!;
}