using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Client.Response;

public class ArmResponse
{
    public int Id { get; set; } = default!;
    public int NetworkId { get; set; } = default!;
    public string CommandType { get; set; } = default!;
    public string State { get; set; } = default!;
    public List<Command> Commands { get; set; } = default!;
}

public class ArmResponseDto
{
    public int id { get; set; } = default!;
    public int network_id { get; set; } = default!;
    public string command { get; set; } = default!;
    public string state { get; set; } = default!;
    public List<CommandDto> commands { get; set; } = default!;
}