using BlinkClient.Model;

namespace BlinkClient.Dtos;
public class AppUpdatesDto
{
    public string message { get; set; } = default!;
    public int code { get; set; }
    public bool update_available { get; set; }
    public bool update_Required { get; set; }
}
