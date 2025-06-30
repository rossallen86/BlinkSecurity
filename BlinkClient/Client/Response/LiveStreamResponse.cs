namespace BlinkClient.Client.Response;

public class LiveStreamResponse
{
    public int CommandId { get; set; }
    public bool JoinAvailable { get; set; }
    public string? JoinState { get; set; }
    public int Duration { get; set; }
    public int ContinueInterval { get; set; }
    public int ContinueWarning { get; set; }
    public bool SubmitLogs { get; set; }
    public bool NewCommand { get; set; }
    public int? MediaId { get; set; }
    public List<object>? Options { get; set; }
}


public class LiveStreamResponseDto
{
    public int command_id { get; set; }
    public bool join_available { get; set; }
    public string? join_state { get; set; }
    public int duration { get; set; }
    public int continue_interval { get; set; }
    public int continue_warning { get; set; }
    public bool submit_logs { get; set; }
    public bool new_command { get; set; }
    public int? media_id { get; set; }
    public List<object>? options { get; set; }
}

