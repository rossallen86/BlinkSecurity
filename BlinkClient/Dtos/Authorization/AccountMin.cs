using BlinkClient.Model;

namespace BlinkClient.Dtos;
public class AccountMinDto
{
    public int id { get; set; }
    public bool email_verified { get; set; }
    public bool email_verification_required { get; set; }
    public bool amazon_account_linked { get; set; }
}
