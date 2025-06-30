using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Client.Response;

public class SetThumbnailResponse
{
    public Command Result { get; set; } = default!;
}


public class SetThumbnailResponseDto
{
    public CommandDto result { get; set; } = default!;
}
