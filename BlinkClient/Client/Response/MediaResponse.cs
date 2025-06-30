using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Client.Response;

public class MediaResponse
{
    public int Limit { get; set; }
    public long PurgeId { get; set; }
    public int RefreshCount { get; set; }
    public List<Media> Media { get; set; } = new();
}

public class MediaResponseDto
{
    public int limit { get; set; }
    public long purge_id { get; set; }
    public int refresh_count { get; set; }
    public List<MediaDto> media { get; set; } = new();
}