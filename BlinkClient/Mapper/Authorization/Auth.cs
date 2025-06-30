using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static Auth Map(AuthDto x)
    {
        return new()
        {
            Token = x.token
        };
    }

    public static AuthDto Map(Auth x)
    {
        return new()
        {
            token = x.Token
        };
    }
}
