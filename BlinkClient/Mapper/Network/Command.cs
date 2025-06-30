using BlinkClient.Dtos;
using BlinkClient.Model;

namespace BlinkClient.Mapper;

public static partial class BlinkMapper
{
    public static List<Command> Map(List<CommandDto> x) => x.Select(i => Map(i)).ToList();

    public static Command Map(CommandDto x)
    {
        return new()
        {
            Id = x.id,
            CreatedAt = x.created_at,
            UpdatedAt = x.updated_at,
            DeletedAt = x.deleted_at,
            ExecuteTime = x.execute_time,
            CommandDescription = x.command,
            StateStage = x.state_stage,
            StageRest = x.stage_rest,
            StageCsDb = x.stage_cs_db,
            StageCsSent = x.stage_cs_sent,
            StageSm = x.stage_sm,
            StageDev = x.stage_dev,
            StageIs = x.stage_is,
            StageLv = x.stage_lv,
            StageVs = x.stage_vs,
            StateCondition = x.state_condition,
            SmAck = x.sm_ack,
            LfrAck = x.lfr_ack,
            Sequence = x.sequence,
            Attempts = x.attempts,
            Transaction = x.transaction,
            PlayerTransaction = x.player_transaction,
            Server = x.server,
            Duration = x.duration,
            ByWhom = x.by_whom,
            Diagnostic = x.diagnostic,
            Debug = x.debug,
            Opts1 = x.opts_1,
            Target = x.target,
            TargetId = x.target_id,
            TraceParent = x.trace_parent,
            SyncModuleId = x.sync_module_id,
            ParentCommandId = x.parent_command_id,
            CameraId = x.camera_id,
            SirenId = x.siren_id,
            FirmwareId = x.firmware_id,
            NetworkId = x.network_id,
            AccountId = x.account_id,
        };
    }
};
