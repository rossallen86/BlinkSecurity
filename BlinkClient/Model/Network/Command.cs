namespace BlinkClient.Model;

public class Command
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public object DeletedAt { get; set; } = default!;
    public DateTime ExecuteTime { get; set; }
    public string CommandDescription { get; set; } = default!;
    public string StateStage { get; set; } = default!;
    public DateTime StageRest { get; set; }
    public DateTime? StageCsDb { get; set; } = default!;
    public DateTime? StageCsSent { get; set; } = default!;
    public DateTime? StageSm { get; set; } = default!;
    public DateTime? StageDev { get; set; } = default!;
    public object StageIs { get; set; } = default!;
    public object StageLv { get; set; } = default!;
    public object StageVs { get; set; } = default!;
    public string StateCondition { get; set; } = default!;
    public int? SmAck { get; set; } = default!;
    public int? LfrAck { get; set; } = default!;
    public int? Sequence { get; set; } = default!;
    public int Attempts { get; set; }
    public string Transaction { get; set; } = default!;
    public string PlayerTransaction { get; set; } = default!;
    public object Server { get; set; } = default!;
    public object Duration { get; set; } = default!;
    public string ByWhom { get; set; } = default!;
    public bool Diagnostic { get; set; }
    public string Debug { get; set; } = default!;
    public int Opts1 { get; set; }
    public string Target { get; set; } = default!;
    public int? TargetId { get; set; }
    public string TraceParent { get; set; } = default!;
    public long SyncModuleId { get; set; }
    public int? ParentCommandId { get; set; } = default!;
    public int? CameraId { get; set; }
    public object SirenId { get; set; } = default!;
    public object FirmwareId { get; set; } = default!;
    public int NetworkId { get; set; }
    public int AccountId { get; set; }
}

