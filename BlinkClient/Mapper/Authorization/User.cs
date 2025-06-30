using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static User Map(UserDto x)
    {
        return new()
        {
            UserId = x.user_id,
            Country = x.country
        };
    }
}