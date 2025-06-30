using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;


public static partial class BlinkMapper
{
    public static EmailVerification Map(EmailVerificationDto x)
    {
        return new()
        {
            Required = x.required
        };
    }

    public static EmailVerificationDto Map(EmailVerification x)
    {
        return new()
        {
            required = x.Required
        };
    }
}
