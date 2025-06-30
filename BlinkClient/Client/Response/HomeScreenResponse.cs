using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Client.Response;

public class HomeScreenResponse
{
    public AccountMin Account { get; set; } = default!;
    public List<Network> Networks { get; set; } = default!;
    public List<SyncModule> SyncModules { get; set; } = default!;
    public List<Camera> Cameras { get; set; } = default!;
    public List<object> Sirens { get; set; } = default!;
    public List<object> Chimes { get; set; } = default!;
    public VideoStats VideoStats { get; set; } = default!;
    public List<object> DoorbellButtons { get; set; } = default!;
    public List<Owl> Owls { get; set; } = default!;
    public List<Doorbell> Doorbells { get; set; } = default!;
    public AppUpdates AppUpdates { get; set; } = default!;
    public DeviceLimits DeviceLimits { get; set; } = default!;
    public WhatsNew WhatsNew { get; set; } = default!;
    public Subscriptions Subscriptions { get; set; } = default!;
    public Entitlements Entitlements { get; set; } = default!;
    public bool TivLockEnable { get; set; } = default!;
    public TivLockStatus TivLockStatus { get; set; } = default!;
    public Accessories Accessories { get; set; } = default!;
}

public class HomeScreenResponseDto
{
    public AccountMinDto account { get; set; } = default!;
    public List<NetworkDto> networks { get; set; } = default!;
    public List<SyncModuleDto> sync_modules { get; set; } = default!;
    public List<CameraDto> cameras { get; set; } = default!;
    public List<object> sirens { get; set; } = default!;
    public List<object> chimes { get; set; } = default!;
    public VideoStatsDto video_stats { get; set; } = default!;
    public List<object> doorbell_buttons { get; set; } = default!;
    public List<OwlDto> owls { get; set; } = default!;
    public List<DoorbellDto> doorbells { get; set; } = default!;
    public AppUpdatesDto app_updates { get; set; } = default!;
    public DeviceLimitsDto device_limits { get; set; } = default!;
    public WhatsNewDto whats_new { get; set; } = default!;
    public SubscriptionsDto subscriptions { get; set; } = default!;
    public EntitlementsDto entitlements { get; set; } = default!;
    public bool tiv_lock_enable { get; set; }
    public TivLockStatusDto tiv_lock_status { get; set; } = default!;
    public AccessoriesDto accessories { get; set; } = default!;
}
