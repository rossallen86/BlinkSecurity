using BlinkClient.Model;

namespace BlinkClient.Dtos;

public class WhatsNewDto
{
    public int updated_at { get; set; }
    public string url { get; set; } = default!;
}
