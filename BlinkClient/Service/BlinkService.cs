using BlinkClient.Client;
using BlinkClient.Client.Request;
using BlinkClient.Client.Response;
using BlinkClient.Mapper;

namespace BlinkClient.Service;

public class BlinkService : IBlinkService
{
    private BlinkApiClient Client { get; set; }

    public BlinkService(BlinkApiClient client) => Client = client;

    public async Task<LoginResponse> Login(string email, string password, bool reauth)
    {
        var request = new LoginRequestDto()
        {
            email = email,
            password = password,
            reauth = reauth
        };
        var response = await Client.ApiBlinkLogin(request);
        //TODO: Store these four in cache/db
        var account = BlinkMapper.Map(response.account);
        var auth = BlinkMapper.Map(response.auth);
        var phone = BlinkMapper.Map(response.phone);
        var verification = BlinkMapper.Map(response.verification);

        return new()
        {
            Account = account,
            Auth = auth,
            Phone = phone,
            Verification = verification,
            LockoutTimeRemaining = response.lockout_time_remaining,
            ForcePasswordReset = response.force_password_reset,
            AllowPinResendSeconds = response.allow_pin_resend_seconds
        };
    }

    public async Task<PinVerificationResponse> VerifyPin(int accountId, int clientId, int pin, string authToken)
    {
        var request = new PinVerificationRequestDto()
        {
            account_id = accountId,
            client_id = clientId,
            auth = new() { token = authToken },
            body = new() { pin = pin }
        };

        var response = await Client.ApiBlinkPinVerificationAsync(request);

        return new()
        {
            Valid = response.valid,
            RequireNewPin = response.require_new_pin,
            Message = response.message,
            Code = response.code
        };
    }

    public async Task Logout(int accountId, int clientId, string authToken)
    {
        var request = new LogoutRequestDto()
        {
            account_id = accountId,
            client_id = clientId,
            auth = new() { token = authToken }
        };

        await Client.ApiBlinkLogoutAsync(request);
    }

    public async Task<HomeScreenResponse> HomeScreen(int accountId, string authToken)
    {
        var request = new HomeScreenRequestDto()
        {
            account_id = accountId,
            auth = new() { token = authToken }
        };

        var response = await Client.ApiBlinkHomeScreenDataAsync(request);

        return new()
        {
            Account = BlinkMapper.Map(response.account),
            Networks = BlinkMapper.Map(response.networks),
            SyncModules = BlinkMapper.Map(response.sync_modules),
            Cameras = BlinkMapper.Map(response.cameras),
            Sirens = response.sirens,
            Chimes = response.chimes,
            VideoStats = BlinkMapper.Map(response.video_stats),
            DoorbellButtons = response.doorbell_buttons,
            Owls = BlinkMapper.Map(response.owls),
            Doorbells = BlinkMapper.Map(response.doorbells),
            AppUpdates = BlinkMapper.Map(response.app_updates),
            DeviceLimits = BlinkMapper.Map(response.device_limits),
            WhatsNew = BlinkMapper.Map(response.whats_new),
            Subscriptions = new() { UpdatedAt = response.subscriptions.updated_at },
            Entitlements = new() { UpdatedAt = response.entitlements.updated_at },
            TivLockEnable = response.tiv_lock_enable,
            TivLockStatus = new() { locked = response.tiv_lock_status.locked },
            Accessories = BlinkMapper.Map(response.accessories)
        };
    }

    public async Task<ArmResponse> Arm(int accountId, int networkId, string authToken, bool enable)
    {
        var request = new ArmRequestDto()
        {
            account_id = accountId,
            network_id = networkId,
            auth = new() { token = authToken },
            enable = enable
        };

        var response = await Client.ApiBlinkArmAsync(request);

        return new()
        {
            Id = response.id,
            NetworkId = response.network_id,
            CommandType = response.command,
            State = response.state,
            Commands = BlinkMapper.Map(response.commands)
        };
    }

    public async Task<LiveStreamResponse> LiveStream(int accountId, int networkId, int cameraId, string authToken, string eventTime)
    {
        var request = new LiveStreamRequestDto()
        {
            account_id = accountId,
            network_id = networkId,
            camera_id = cameraId,
            auth = new() { token = authToken },
            body = new() { motion_event_start_time = eventTime }
        };

        var response = await Client.ApiBlinkLiveStreamAsync(request);

        return new()
        {
            CommandId = response.command_id,
            JoinAvailable = response.join_available,
            JoinState = response.join_state,
            Duration = response.duration,
            ContinueInterval = response.continue_interval,
            ContinueWarning = response.continue_warning,
            SubmitLogs = response.submit_logs,
            NewCommand = response.new_command,
            MediaId = response.media_id,
            Options = response.options
        };
    }
}
