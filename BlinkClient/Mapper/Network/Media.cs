using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static List<Media> Map(List<MediaDto> x) => x.Select(i => Map(i)).ToList();

    public static Media Map(MediaDto x)
    {
        return new()
        {
            Id = x.id,
            CreatedAt = x.created_at,
            UpdatedAt = x.updated_at,
            Deleted = x.deleted,
            Device = x.device,
            DeviceId = x.device_id,
            DeviceName = x.device_name,
            NetworkId = x.network_id,
            NetworkName = x.network_name,
            Type = x.type,
            Source = x.source,
            Partial = x.partial,
            Watched = x.watched,
            Thumbnail = x.thumbnail,
            MediaUrl = x.media,
            Metadata = x.metadata,
            AdditionalDevices = x.additional_devices,
            TimeZone = x.time_zone
        };
    }
};