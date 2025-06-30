namespace BlinkClient.Dtos;

public class NotificationsDto
{
    public bool low_battery { get; set; }
    public bool camera_offline { get; set; }
    public bool camera_usage { get; set; }
    public bool scheduling { get; set; }
    public bool motion { get; set; }
    public bool sync_module_offline { get; set; }
    public bool temperature { get; set; }
    public bool doorbell { get; set; }
    public bool wifi { get; set; }
    public bool lfr { get; set; }
    public bool bandwidth { get; set; }
    public bool battery_dead { get; set; }
    public bool local_storage { get; set; }
    public bool accessory_connected { get; set; }
    public bool accessory_disconnected { get; set; }
    public bool accessory_low_battery { get; set; }
    public bool general { get; set; }
    public bool cv_motion { get; set; }
}