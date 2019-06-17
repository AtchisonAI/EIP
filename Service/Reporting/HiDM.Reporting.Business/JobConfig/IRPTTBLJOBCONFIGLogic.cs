using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;
using HiDM.Reporting.Models.JobConfig;

namespace HiDM.Reporting.Business
{
	/// <summary>
    /// 业务逻辑接口
    /// </summary>
    public interface IRPTTBLJOBCONFIGLogic : ILogic<RPTTBLJOBCONFIG>
    {
        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        OperateStatus Save(RPTTBLJOBCONFIG entity);
        OperateStatus Delete(object id);

        PagedResults<RPTJOBCONFIGOutput> PagingConfigQuery(RPTJOBCONFIGPagingInput paging);
        PagedResults<RPTJOBCONFIGPARAMSOutput> PagingConfigParamsQuery(RPTJOBCONFIGPARAMSPagingInput paging);
    }
}