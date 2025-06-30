using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static Verification Map(VerificationDto x)
    {
        return new()
        {
            Email = Map(x.email),
            Phone = Map(x.phone),
        };
    }

    public static VerificationDto Map(Verification x)
    {
        return new()
        {
            email = Map(x.Email),
            phone = Map(x.Phone),
        };
    }
}
