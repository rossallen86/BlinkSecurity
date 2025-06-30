using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static List<Accessory> Map(List<AccessoryDto> x) => x.Select(i => Map(i)).ToList();

    public static Accessory Map(AccessoryDto x)
    {
        return new()
        {
            Id = x.id,
            CreatedAt = x.created_at,
            Serial = x.serial,
            Type = x.type,
            Calibrated = x.calibrated,
            Connected = x.connected,
            PowerType = x.power_type,
            Battery = x.battery,
            Target = x.target,
            TargetId = x.target_id,
            Revision = x.revision
        };
    }
};