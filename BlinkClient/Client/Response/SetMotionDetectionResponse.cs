using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Client.Response;

public class SetMotionDetectionResponse
{
    public Command Command { get; set; } = default!;

}

public class SetMotionDetectionResponseDto
{
    public CommandDto command { get; set; } = default!;
}
