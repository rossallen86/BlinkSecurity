using BlinkClient.Model;

namespace BlinkClient.Dtos;

public class CommandDto
{
    public int id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public object deleted_at { get; set; } = default!;
    public DateTime execute_time { get; set; }
    public string command { get; set; } = default!;
    public string state_stage { get; set; } = default!;
    public DateTime stage_rest { get; set; }
    public DateTime? stage_cs_db { get; set; }
    public DateTime? stage_cs_sent { get; set; }
    public DateTime? stage_sm { get; set; }
    public DateTime? stage_dev { get; set; }
    public object stage_is { get; set; } = default!;
    public object stage_lv { get; set; } = default!;
    public object stage_vs { get; set; } = default!;
    public string state_condition { get; set; } = default!;
    public int? sm_ack { get; set; }
    public int? lfr_ack { get; set; }
    public int? sequence { get; set; }
    public int attempts { get; set; }
    public string transaction { get; set; } = default!;
    public string player_transaction { get; set; } = default!;
    public object server { get; set; } = default!;
    public object duration { get; set; } = default!;
    public string by_whom { get; set; } = default!;
    public bool diagnostic { get; set; }
    public string debug { get; set; } = default!;
    public int opts_1 { get; set; }
    public string target { get; set; } = default!;
    public int? target_id { get; set; }
    public string trace_parent { get; set; } = default!;
    public long sync_module_id { get; set; }
    public int? parent_command_id { get; set; }
    public int? camera_id { get; set; }
    public object siren_id { get; set; } = default!;
    public object firmware_id { get; set; } = default!;
    public int network_id { get; set; }
    public int account_id { get; set; }
}

