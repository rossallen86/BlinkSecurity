using BlinkClient.Model;

namespace BlinkClient.Dtos;
public class UserDto
{
    public int user_id { get; set; }
    public string country { get; set; } = default!;
}
