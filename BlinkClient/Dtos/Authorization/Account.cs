using BlinkClient.Model;

namespace BlinkClient.Dtos;
public class AccountDto
{
    public int account_id { get; set; }
    public string country { get; set; } = default!;
    public int user_id { get; set; }
    public int client_id { get; set; }
    public bool client_trusted { get; set; }
    public bool new_account { get; set; }
    public string tier { get; set; } = default!;
    public string region { get; set; } = default!;
    public bool account_verification_required { get; set; }
    public bool phone_verification_required { get; set; }
    public bool client_verification_required { get; set; }
    public bool require_trust_client_device { get; set; }
    public bool country_required { get; set; }
    public string verification_channel { get; set; } = default!;
    public UserDto user { get; set; } = default!;
    public bool amazon_account_linked { get; set; }
    public string braze_external_id { get; set; } = default!;
}
