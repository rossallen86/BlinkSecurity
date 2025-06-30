namespace BlinkClient.Client.Response;

public class CommandResponse
{
    bool Complete { get; set; }
    int Status { get; set; }
    public string StatusMessage { get; set; } = default!;
    public string StatusCode { get; set; } = default!;
    public string[] Commands { get; set; } = default!;
}

public class CommandResponseDto
{
    bool complete { get; set; }
    int status { get; set; }
    public string status_msg { get; set; } = default!;
    public string status_code { get; set; } = default!;
    public string[] commands { get; set; } = default!;
}