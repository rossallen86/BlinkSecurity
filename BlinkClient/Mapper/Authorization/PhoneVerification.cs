using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static PhoneVerification Map(PhoneVerificationDto x)
    {
        return new()
        {
            Required = x.required,
            Channel = x.channel
        };
    }

    public static PhoneVerificationDto Map(PhoneVerification x)
    {
        return new()
        {
            required = x.Required,
            channel = x.Channel
        };
    }
}
