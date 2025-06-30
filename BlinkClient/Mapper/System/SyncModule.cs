using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static List<SyncModule> Map(List<SyncModuleDto> x) => x.Select(i => Map(i)).ToList();

    public static SyncModule Map(SyncModuleDto x)
    {
        return new()
        {
            Id = x.id,
            CreatedAt = x.created_at,
            UpdatedAt = x.updated_at,
            Onboarded = x.onboarded,
            Status = x.status,
            Name = x.name,
            Serial = x.serial,
            FirmwareVersion = x.fw_version,
            Type = x.type,
            Subtype = x.subtype,
            LasHB = x.last_hb,
            WifiStrength = x.wifi_strength,
            NetworkId = x.network_id,
            EnableTempAlerts = x.enable_temp_alerts,
            LocalStorageCompatible = x.local_storage_compatible,
            LocalStorageEnabled = x.local_storage_enabled,
            LocalStorageStatus = x.local_storage_status,
            Revision = x.revision
        };
    }
};