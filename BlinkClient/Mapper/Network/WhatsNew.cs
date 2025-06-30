using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static WhatsNew Map(WhatsNewDto x)
    {
        return new()
        {
            UpdatedAt = x.updated_at,
            Url = x.url
        };
    }
};