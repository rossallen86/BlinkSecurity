using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;


public static partial class BlinkMapper
{
    public static List<Network> Map(List<NetworkDto> x) => x.Select(i => Map(i)).ToList();

    public static Network Map(NetworkDto x)
    {
        return new()
        {
            Id = x.id,
            CreatedAt = x.created_at,
            UpdatedAt = x.updated_at,
            Name = x.name,
            TimeZone = x.time_zone,
            Dst = x.dst,
            Armed = x.armed,
            LvSave = x.lv_save,
        };
    }
}