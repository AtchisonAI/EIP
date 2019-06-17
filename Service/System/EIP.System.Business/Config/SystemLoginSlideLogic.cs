using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Core.Extensions;
using EIP.Common.Core.Utils;
using EIP.Common.Entities;
using EIP.System.DataAccess.Config;
using EIP.System.Models.Entities;

namespace EIP.System.Business.Config
{
    /// <summary>
    ///     ��¼�õ�Ƭҵ���߼��ӿ�ʵ��
    /// </summary>
    public class SystemLoginSlideLogic : AsyncLogic<SystemLoginSlide>, ISystemLoginSlideLogic
    {
        #region ���캯��
        private readonly ISystemLoginSlideRepository _systemLoginSlideRepository;
        public SystemLoginSlideLogic(ISystemLoginSlideRepository systemLoginSlideRepository)
            : base(systemLoginSlideRepository)
        {
            _systemLoginSlideRepository = systemLoginSlideRepository;
        }

        #endregion

        #region ����

        /// <summary>
        ///     ����
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <returns></returns>
        public async Task<OperateStatus> Save(SystemLoginSlide entity)
        {
            if (!entity.LoginSlideId.IsEmptyGuid())
                return await UpdateAsync(entity);
            entity.LoginSlideId = CombUtil.NewComb();
            return await InsertAsync(entity);
        }
        #endregion
    }
}