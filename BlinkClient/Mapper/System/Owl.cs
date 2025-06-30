using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static List<Owl> Map(List<OwlDto> x) => x.Select(i => Map(i)).ToList();

    public static Owl Map(OwlDto x)
    {
        return new()
        {
            Id = x.id,
            CreatedAt = x.created_at,
            UpdatedAt = x.updated_at,
            Name = x.name,
            Serial = x.serial,
            FirmwareVersion = x.fw_version,
            Type = x.type,
            Onboarded = x.onboarded,
            Enabled = x.enabled,
            Thumbnail = x.thumbnail,
            Status = x.status,
            NetworkId = x.network_id,
            LocalStorageCompatible = x.local_storage_compatible,
            LocalStorageEnabled = x.local_storage_enabled,
            Snooze = x.snooze,
            SnoozeTimeRemaining = x.snooze_time_remaining,
            Revision = x.revision,
            Color = x.color
        };
    }
};