namespace BlinkClient.Model;

public class Notifications
{
    public bool LowBattery { get; set; }
    public bool CameraOffline { get; set; }
    public bool CameraUsage { get; set; }
    public bool Scheduling { get; set; }
    public bool Motion { get; set; }
    public bool SyncModuleOffline { get; set; }
    public bool Temperature { get; set; }
    public bool Doorbell { get; set; }
    public bool Wifi { get; set; }
    public bool Lfr { get; set; }
    public bool Bandwidth { get; set; }
    public bool BatteryDead { get; set; }
    public bool LocalStorage { get; set; }
    public bool AccessoryConnected { get; set; }
    public bool AccessoryDisconnected { get; set; }
    public bool AccessoryLowBattery { get; set; }
    public bool General { get; set; }
    public bool CvMotion { get; set; }
}