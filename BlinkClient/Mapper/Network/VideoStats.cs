using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;


public static partial class BlinkMapper
{
    public static VideoStats Map(VideoStatsDto x)
    {
        return new()
        {
            Storage = x.Storage,
            AutoDeleteDays = x.AutoDeleteDays,
            AutoDeleteDayOptions = x.AutoDeleteDayOptions
        };
    }
};