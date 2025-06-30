using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static Account Map(AccountDto x)
    {
        return new()
        {
            AccountId = x.account_id,
            Country = x.country,
            UserId = x.user_id,
            ClientId = x.client_id,
            ClientTrusted = x.client_trusted,
            NewAccount = x.new_account,
            Tier = x.tier,
            Region = x.region,
            AccountVerificationRequired = x.account_verification_required,
            PhoneVerificationRequired = x.phone_verification_required,
            ClientVerificationRequired = x.client_verification_required,
            RequireTrustClientDevice = x.require_trust_client_device,
            CountryRequired = x.country_required,
            VerificationChannel = x.verification_channel,
            User = BlinkMapper.Map(x.user),
            AmazonAccountLinked = x.amazon_account_linked,
            BrazeExternalId = x.braze_external_id
        };
    }
}
