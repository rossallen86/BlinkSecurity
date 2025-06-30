namespace BlinkClient.Model;

public class Phone
{
    public string Number { get; set; } = default!;
    public string Last4Digits { get; set; } = default!;
    public string CountryCallingCode { get; set; } = default!;
    public bool Valid { get; set; }
}

