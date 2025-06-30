namespace BlinkClient.Model;

public class AccountMin
{
    public int Id { get; set; }
    public bool EmailVerified { get; set; }
    public bool EmailVerificatioRequired { get; set; }
    public bool AmazonAccountLinked { get; set; }
}
