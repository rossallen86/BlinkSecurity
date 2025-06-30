namespace BlinkClient.Model;

public class Accessory
{
    public int Id { get; set; }
    public string Serial { get; set; } = default!;
    public string Type { get; set; } = default!;
    public bool Connected { get; set; }
    public bool Calibrated { get; set; }
    public string PowerType { get; set; } = default!;
    public string Battery { get; set; } = default!;
    public string Target { get; set; } = default!;
    public int TargetId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Revision { get; set; } = default!;
}
