using System.Threading.Tasks;
using EIP.Common.Core.Extensions;
using EIP.Common.Dapper;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;
using HiDM.Reporting.Models.JobConfig;

namespace HiDM.Reporting.DataAccess
{
    /// <summary>
    ///     数据访问接口实现
    /// </summary>
    public class RPTTBLJOBCONFIGRepository : DapperRepository<RPTTBLJOBCONFIG>, IRPTTBLJOBCONFIGRepository
    {
        public PagedResults<RPTJOBCONFIGOutput> PagingConfigQuery(RPTJOBCONFIGPagingInput paging)
        {
            string sql = @" SELECT t.sysid,
        t.procedurename,
        t.trigger_type,
        t.max_retry_count,
        t.is_stop_when_failed,
        t.job_state,
        b.process_status,
        b.cycle_start_time,
        b.retry_count,
        c.next_cycle_time,
        T.SEQUENCE,
                                @rowNumber, @recordCount 
   FROM rpt_tbl_job_config t
   left join rpt_tbl_job_circle_status b
     on t.current_cycle_job_status_id = b.sysid
   left join rpt_tbl_job_trigger_history c
     on b.job_trigger_hist_id = c.sysid
                                @where";


            return PagingQuery<RPTJOBCONFIGOutput>(sql.ToString(), paging);
        }

        public PagedResults<RPTJOBCONFIGPARAMSOutput> PagingConfigParamsQuery(RPTJOBCONFIGPARAMSPagingInput paging)
        {
            string sql = string.Format(@"select SysID,PARAM_NAME PARAMNAME, PARAM_SEQUENCE ParamSequence,Param_Type ParamType,
Value_Type ValueType,Param_Expression ParamExpression,Param_Description Description,PARAM_LENGTH ParamLength,
                                @rowNumber, @recordCount 
 FROM rpt_tbl_job_config_params @where and procedurename = '{0}'", paging.ProcedureName);

            return PagingQuery<RPTJOBCONFIGPARAMSOutput>(sql.ToString(), paging);
        }
    }
}