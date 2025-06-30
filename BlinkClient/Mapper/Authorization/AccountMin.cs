using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static AccountMin Map(AccountMinDto x)
    {
        return new()
        {
            Id = x.id,
            EmailVerified = x.email_verified,
            EmailVerificatioRequired = x.email_verification_required,
            AmazonAccountLinked = x.amazon_account_linked,
        };

    }
}