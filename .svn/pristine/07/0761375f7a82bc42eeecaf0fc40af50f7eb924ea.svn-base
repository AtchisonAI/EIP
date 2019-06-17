using System.Threading.Tasks;
using System.Transactions;
using EIP.Common.Business;
using EIP.Common.Core.Extensions;
using EIP.Common.Core.Resource;
using EIP.Common.Core.Utils;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;
using HiDM.Reporting.DataAccess;
using HiDM.Reporting.Models.JobConfig;

namespace HiDM.Reporting.Business
{
    /// <summary>
    ///     业务逻辑接口实现
    /// </summary>
    public class RPTTBLJOBCONFIGLogic : Logic<RPTTBLJOBCONFIG>, IRPTTBLJOBCONFIGLogic
    {
        #region 构造函数
        private readonly IRPTTBLJOBCONFIGRepository _rPTTBLJOBCONFIGRepository;
        private readonly IRPTTBLJOBCONFIGPARAMSRepository _rPTTBLJOBCONFIGPARAMSRepository;
        public RPTTBLJOBCONFIGLogic(IRPTTBLJOBCONFIGRepository rPTTBLJOBCONFIGRepository, IRPTTBLJOBCONFIGPARAMSRepository rPTTBLJOBCONFIGPARAMSRepository)
            : base(rPTTBLJOBCONFIGRepository)
        {
            _rPTTBLJOBCONFIGRepository = rPTTBLJOBCONFIGRepository;
            _rPTTBLJOBCONFIGPARAMSRepository = rPTTBLJOBCONFIGPARAMSRepository;
        }

        #endregion

        #region 方法

        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public OperateStatus Save(RPTTBLJOBCONFIG entity)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                OperateStatus sts;


                if (!string.IsNullOrWhiteSpace(entity.SYSID))
                {
                    var oldEntity = GetById(entity.SYSID);
                    _rPTTBLJOBCONFIGPARAMSRepository.DeleteParams(oldEntity.PROCEDURENAME);


                    sts = Update(entity, true);
                }
                else
                {
                    entity.SYSID = CombUtil.NewComb().ToString("N").ToUpper();
                    sts = Insert(entity, true);
                }

                if (sts.ResultSign == ResultSign.Successful)
                {
                    if (entity.Parameters.Count > 0)
                    {
                        foreach(var param in entity.Parameters)
                        {
                            if (param.SYSID.IsNullOrWhiteSpace())
                            {
                                param.SYSID = CombUtil.NewComb().ToString("N").ToUpper();
                            }
                        }

                        int result = _rPTTBLJOBCONFIGPARAMSRepository.InsertMultiple(entity.Parameters);
                    }
                }
                ts.Complete();
                return sts;
            }
        }


        public OperateStatus Delete(object id)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var entity = base.GetById(id);
                _rPTTBLJOBCONFIGPARAMSRepository.DeleteParams(entity.PROCEDURENAME);
                var sts =  base.Delete(id,true);
                ts.Complete();
                return sts;
            }
        }


        public PagedResults<RPTJOBCONFIGOutput> PagingConfigQuery(RPTJOBCONFIGPagingInput paging)
        {
            return _rPTTBLJOBCONFIGRepository.PagingConfigQuery(paging);
        }

        public PagedResults<RPTJOBCONFIGPARAMSOutput> PagingConfigParamsQuery(RPTJOBCONFIGPARAMSPagingInput paging)
        {
            return _rPTTBLJOBCONFIGRepository.PagingConfigParamsQuery(paging);
        }

        #endregion
    }
}