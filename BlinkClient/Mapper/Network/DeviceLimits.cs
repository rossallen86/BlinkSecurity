using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static DeviceLimits Map(DeviceLimitsDto x)
    {
        return new()
        {
            Camera = x.camera,
            Chime = x.chime,
            Doorbell = x.doorbell,
            DoorbellButton = x.doorbellButton,
            Owl = x.owl,
            Siren = x.siren,
            TotalDevices = x.total_devices
        };
    }
};