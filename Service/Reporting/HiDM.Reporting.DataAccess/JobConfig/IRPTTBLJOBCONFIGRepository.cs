using System.Threading.Tasks;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;
using HiDM.Reporting.Models.JobConfig;

namespace HiDM.Reporting.DataAccess
{
    /// <summary>
    /// 数据访问接口
    /// </summary>
    public interface IRPTTBLJOBCONFIGRepository : IRepository<RPTTBLJOBCONFIG>
    {
       PagedResults<RPTJOBCONFIGOutput> PagingConfigQuery(RPTJOBCONFIGPagingInput paging);


        PagedResults<RPTJOBCONFIGPARAMSOutput> PagingConfigParamsQuery(RPTJOBCONFIGPARAMSPagingInput paging);
    }
}