using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static List<Camera> Map(List<CameraDto> x) => x.Select(i => Map(i)).ToList();

    public static Camera Map(CameraDto x)
    {
        return new()
        {
            Id = x.id,
            CreatedAt = x.created_at,
            UpdatedAt = x.updated_at,
            Name = x.name,
            Serial = x.serial,
            FwVersion = x.fw_version,
            Type = x.type,
            Enabled = x.enabled,
            Thumbnail = x.thumbnail,
            Status = x.status,
            Battery = x.battery,
            UsageRate = x.usage_rate,
            NetworkId = x.network_id,
            Issues = x.issues,
            Signals = x.signals,
            LocalStorageCompatible = x.local_storage_compatible,
            LocalStorageEnabled = x.local_storage_enabled,
            Snooze = x.snooze,
            SnoozeTimeRemaining = x.snooze_time_remaining,
            Revision = x.revision,
            Color = x.color
        };
    }
};