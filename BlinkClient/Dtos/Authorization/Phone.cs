using BlinkClient.Model;

namespace BlinkClient.Dtos;

public class PhoneDto
{
    public string number { get; set; } = default!;
    public string last_4_digits { get; set; } = default!;
    public string country_calling_code { get; set; } = default!;
    public bool valid { get; set; }
}

