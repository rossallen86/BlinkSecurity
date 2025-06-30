using BlinkClient.Client.Response;

namespace BlinkClient.Service;
public interface IBlinkService
{
    Task<LoginResponse> Login(string email, string password, bool reauth);
    Task<PinVerificationResponse> VerifyPin(int accountId, int clientId, int pin, string authToken);
    Task Logout(int accountId, int clientId, string authToken);
    Task<HomeScreenResponse> HomeScreen(int accountId, string authToken);
    Task<ArmResponse> Arm(int accountId, int networkId, string authToken, bool enable);
    Task<LiveStreamResponse> LiveStream(int accountId, int networkId, int cameraId, string authToken, string eventTime);
}
