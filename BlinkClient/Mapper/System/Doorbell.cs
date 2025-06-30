using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static List<Doorbell> Map(List<DoorbellDto> x) => x.Select(i => Map(i)).ToList();

    public static Doorbell Map(DoorbellDto x)
    {
        return new()
        {
            Id = x.id,
            CreatedAt = x.created_at,
            UpdatedAt = x.updated_at,
            Name = x.name,
            Onboarded = x.onboarded,
            Serial = x.serial,
            FirmwareVersion = x.fw_version,
            Type = x.type,
            Enabled = x.enabled,
            NetworkId = x.network_id,
            Thumbnail = x.thumbnail,
            Status = x.status,
            Battery = x.battery,
            DoorbellMode = x.doorbell_mode,
            ChangingMode = x.changing_mode,
            Issues = x.issues,
            Signals = x.signals,
            LocalStorageCompatible = x.local_storage_compatible,
            LocalStorageEnabled = x.local_storage_enabled,
            ConfigOutOfSync = x.config_out_of_sync,
            Snooze = x.snooze,
            SnoozeTimeRemaining = x.snooze_time_remaining,
            Revision = x.revision,
            Color = x.color
        };
    }
};