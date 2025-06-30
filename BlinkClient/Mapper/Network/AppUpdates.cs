using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static AppUpdates Map(AppUpdatesDto x)
    {
        return new()
        {
            Message = x.message,
            Code = x.code,
            UpdateAvailable = x.update_available,
            UpdateRequired = x.update_Required,
        };
    }
};