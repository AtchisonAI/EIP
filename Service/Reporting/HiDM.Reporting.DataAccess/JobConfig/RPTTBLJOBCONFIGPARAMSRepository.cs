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
    public class RPTTBLJOBCONFIGPARAMSRepository : DapperRepository<RPTTBLJOBCONFIGPARAMS>, IRPTTBLJOBCONFIGPARAMSRepository
    {

        public int DeleteParams(string procedureName)
        {
            const string sql = "DELETE FROM RPT_TBL_JOB_CONFIG_PARAMS  WHERE PROCEDURENAME=:procedureName";
            return SqlMapperUtil.InsertUpdateOrDeleteSqlSync<RPTTBLJOBCONFIGPARAMS>(sql, new { procedureName = procedureName });
        }
        
    }
}