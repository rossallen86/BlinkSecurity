using BlinkClient.Client.Request;
using BlinkClient.Client.Response;
using Newtonsoft.Json;

namespace BlinkClient.Client;

#pragma warning disable 649 // Disable "CS0649 Field is never assigned to, and will always have its default value null"
#pragma warning disable 8604 // Disable "CS8604 Possible null reference argument for parameter"

public partial class BlinkApiClient
{
    private HttpClient _httpClient;
    private static Lazy<JsonSerializerSettings> _settings = new(CreateSerializerSettings, true);
    private JsonSerializerSettings? _instanceSettings;
    private string _tier = "prod";

    public BlinkApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        Initialize();
    }
    protected string BaseUrl => $"{_tier}.immedia-semi.com";
    protected JsonSerializerSettings JsonSerializerSettings { get { return _instanceSettings ?? _settings.Value; } }

    partial void Initialize();

    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url);
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
    partial void ProcessResponse(HttpClient client, HttpResponseMessage response);

    private static void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
    {
        settings.ContractResolver = new SafeContractResolver();
    }

    private static JsonSerializerSettings CreateSerializerSettings()
    {
        var settings = new JsonSerializerSettings();
        UpdateJsonSerializerSettings(settings);
        return settings;
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<LoginResponseDto> ApiBlinkLogin(LoginRequestDto dto)
    {
        return ApiBlinkLoginAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<LoginResponseDto> ApiBlinkLoginAsync(LoginRequestDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
            throw new ArgumentNullException("dto");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(dto, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new HttpMethod("POST");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);

                urlBuilder_.Append("/api/v5/account/login");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<LoginResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            _tier = objectResponse_.Object.account.tier;
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task ApiBlinkLogoutAsync(LogoutRequestDto dto)
    {
        return ApiBlinkLogoutAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task ApiBlinkLogoutAsync(LogoutRequestDto dto, CancellationToken cancellationToken)
    {
        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(dto, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("POST");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);

                urlBuilder_.Append($"/api/v4/account/{dto.account_id}/client/{dto.client_id}/logout");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                        return;
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<PinVerificationResponseDto> ApiBlinkPinVerificationAsync(PinVerificationRequestDto dto)
    {
        return ApiBlinkPinVerificationAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<PinVerificationResponseDto> ApiBlinkPinVerificationAsync(PinVerificationRequestDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
            throw new ArgumentNullException("dto");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(dto.body, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("POST");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);

                urlBuilder_.Append($"/api/v4/account/{dto.account_id}/client/{dto.client_id}/pin/verify");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PinVerificationResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<HomeScreenResponseDto> ApiBlinkHomeScreenDataAsync(HomeScreenRequestDto dto)
    {
        return ApiBlinkHomeScreenDataAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<HomeScreenResponseDto> ApiBlinkHomeScreenDataAsync(HomeScreenRequestDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(string.Empty, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("POST");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);

                urlBuilder_.Append($"/api/v3/accounts/{dto.account_id}/homescreen");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<HomeScreenResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<ArmResponseDto> ApiBlinkArmAsync(ArmRequestDto dto)
    {
        return ApiBlinkArmAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<ArmResponseDto> ApiBlinkArmAsync(ArmRequestDto dto, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(dto);

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(string.Empty, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("POST");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                var state = dto.enable ? "arm" : "disarm";
                urlBuilder_.Append($"/api/v1/accounts/{dto.account_id}/networks/{dto.network_id}/state/{state}");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ArmResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<MediaResponseDto> ApiBlinkMediaAsync(MediaRequestDto dto)
    {
        return ApiBlinkMediaAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<MediaResponseDto> ApiBlinkMediaAsync(MediaRequestDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
            throw new ArgumentNullException("dto");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(string.Empty, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("GET");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);

                urlBuilder_.Append($"api/v1/accounts/{dto.account_id}/media/changed?since={dto.since}");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<MediaResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<NotificationsResponseDto> ApiBlinkNotificationsAsync(NotificationsRequestDto dto)
    {
        return ApiBlinkNotificationsAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<NotificationsResponseDto> ApiBlinkNotificationsAsync(NotificationsRequestDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
            throw new ArgumentNullException("dto");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(string.Empty, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("GET");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);

                urlBuilder_.Append($"/api/v1/accounts/{dto.account_id}/notifications/configuration");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<NotificationsResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<SetNotificationsResponseDto> ApiBlinkSetNotificationsAsync(SetNotificationsRequestDto dto)
    {
        return ApiBlinkSetNotificationsAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<SetNotificationsResponseDto> ApiBlinkSetNotificationsAsync(SetNotificationsRequestDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
            throw new ArgumentNullException("dto");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(dto.notifications, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("POST");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);

                urlBuilder_.Append($"/api/v1/accounts/{dto.account_id}/notifications/configuration");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SetNotificationsResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<OptionsResponseDto> ApiBlinkClientOptionsAsync(OptionsRequestDto dto)
    {
        return ApiBlinkClientOptionsAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<OptionsResponseDto> ApiBlinkClientOptionsAsync(OptionsRequestDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
            throw new ArgumentNullException("dto");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(string.Empty, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("GET");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);

                urlBuilder_.Append($"/api/v1/accounts/{dto.account_id}/client/{dto.client_id}/options");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<OptionsResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<UpdateClientOptionsResponseDto> ApiBlinkUpdateClientOptionsAsync(UpdateClientOptionsRequestDto dto)
    {
        return ApiBlinkUpdateClientOptionsAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<UpdateClientOptionsResponseDto> ApiBlinkUpdateClientOptionsAsync(UpdateClientOptionsRequestDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
            throw new ArgumentNullException("dto");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(dto.body, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("POST");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);

                urlBuilder_.Append($"/client/{dto.client_id}/update");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<UpdateClientOptionsResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<LiveStreamResponseDto> ApiBlinkLiveStreamAsync(LiveStreamRequestDto dto)
    {
        return ApiBlinkLiveStreamAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<LiveStreamResponseDto> ApiBlinkLiveStreamAsync(LiveStreamRequestDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
            throw new ArgumentNullException("dto");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(dto.body, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("POST");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append($"/api/v5/accounts/{dto.account_id}/networks/{dto.network_id}/cameras/{dto.camera_id}/liveview");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<LiveStreamResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<ThumbnailResponseDto> ApiBlinkThumbnailAsync(ThumbnailRequestDto dto)
    {
        return ApiBlinkThumbnailAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<ThumbnailResponseDto> ApiBlinkThumbnailAsync(ThumbnailRequestDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
            throw new ArgumentNullException("dto");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(string.Empty, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("GET");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);

                urlBuilder_.Append($"media/production/account/{dto.account_id}/network/{dto.network_id}/camera/{dto.camera_id}/{dto.image_url}");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ThumbnailResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<SetThumbnailResponseDto> ApiBlinkSetThumbnailAsync(SetThumbnailRequestDto dto)
    {
        return ApiBlinkSetThumbnailAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<SetThumbnailResponseDto> ApiBlinkSetThumbnailAsync(SetThumbnailRequestDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
            throw new ArgumentNullException("dto");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(string.Empty, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("POST");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);

                urlBuilder_.Append($"/network/{dto.network_id}/camera/{dto.camera_id}/thumbnail");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SetThumbnailResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<SetMotionDetectionResponseDto> ApiBlinkSetMotionDetectionAsync(SetMotionDetectionRequestDto dto)
    {
        return ApiBlinkSetMotionDetectionAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<SetMotionDetectionResponseDto> ApiBlinkSetMotionDetectionAsync(SetMotionDetectionRequestDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
            throw new ArgumentNullException("dto");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(string.Empty, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("POST");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);

                var state = dto.enable ? "enable" : "disable";
                urlBuilder_.Append($"/network/{dto.network_id}/camera/{dto.camera_id}/{state}");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SetMotionDetectionResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<CommandResponseDto> ApiBlinkCommandAsync(CommandRequestDto dto)
    {
        return ApiBlinkCommandAsync(dto, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<CommandResponseDto> ApiBlinkCommandAsync(CommandRequestDto dto, CancellationToken cancellationToken)
    {
        if (dto == null)
            throw new ArgumentNullException("dto");

        var client_ = _httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var json_ = JsonConvert.SerializeObject(string.Empty, JsonSerializerSettings);
                var content_ = new StringContent(json_);
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                content_.Headers.Add("TOKEN-AUTH", dto.auth.token);
                request_.Content = content_;
                request_.Method = new HttpMethod("GET");

                var urlBuilder_ = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(BaseUrl)) urlBuilder_.Append(BaseUrl);
                urlBuilder_.Append($"/network/{dto.network_id}/command/{dto.command_id}");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = new Dictionary<string, IEnumerable<string>>();
                    foreach (var item_ in response_.Headers)
                        headers_[item_.Key] = item_.Value;
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CommandResponseDto>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        else
                        {
                            return objectResponse_.Object;
                        }
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
    {
        if (value == null)
            return "";

        if (value is Enum)
        {
            var name = Enum.GetName(value.GetType(), value);
            if (name != null)
            {
                var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                if (field != null)
                {
                    var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                        as System.Runtime.Serialization.EnumMemberAttribute;
                    if (attribute != null)
                        return attribute.Value != null ? attribute.Value : name;
                }

                var converted = Convert.ToString(Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                return converted == null ? string.Empty : converted;
            }
        }
        else if (value is bool)
        {
            return Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
        }
        else if (value is byte[])
        {
            return Convert.ToBase64String((byte[])value);
        }
        else if (value is string[])
        {
            return string.Join(",", (string[])value);
        }
        else if (value.GetType().IsArray)
        {
            var valueArray = (Array)value;
            var valueTextArray = new string[valueArray.Length];
            for (var i = 0; i < valueArray.Length; i++)
            {
                valueTextArray[i] = ConvertToString(valueArray.GetValue(i), cultureInfo);
            }
            return string.Join(",", valueTextArray);
        }

        var result = Convert.ToString(value, cultureInfo);
        return result == null ? "" : result;
    }

    protected struct ObjectResponseResult<T>
    {
        public ObjectResponseResult(T responseObject, string responseText)
        {
            Object = responseObject;
            Text = responseText;
        }

        public T Object { get; }

        public string Text { get; }
    }

    public bool ReadResponseAsString { get; set; }

    protected virtual async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken)
    {
        if (response == null || response.Content == null)
            return new ObjectResponseResult<T>(default, string.Empty);

        if (ReadResponseAsString)
        {
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                T? typedBody = JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                return new ObjectResponseResult<T>(typedBody, responseText);
            }
            catch (JsonException exception)
            {
                var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
            }
        }
        else
        {
            try
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (var streamReader = new StreamReader(responseStream))
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    var serializer = JsonSerializer.Create(JsonSerializerSettings);
                    var typedBody = serializer.Deserialize<T>(jsonTextReader);
                    return new ObjectResponseResult<T>(typedBody, string.Empty);
                }
            }
            catch (JsonException exception)
            {
                var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
            }
        }
    }

}

#pragma warning restore 649
#pragma warning restore 8604

