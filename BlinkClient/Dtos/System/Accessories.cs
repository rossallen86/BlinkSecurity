using BlinkClient.Model;

namespace BlinkClient.Dtos;

public class AccessoriesDto
{
    public List<AccessoryDto> storm { get; set; } = new();
    public List<AccessoryDto> rosie { get; set; } = new();
    public List<AccessoryDto> superior { get; set; } = new();
}