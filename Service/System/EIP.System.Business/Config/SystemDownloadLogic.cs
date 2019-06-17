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
    ///     �������ؼ�¼��ҵ���߼��ӿ�ʵ��
    /// </summary>
    public class SystemDownloadLogic : AsyncLogic<SystemDownload>, ISystemDownloadLogic
    {
        #region ���캯��
        private readonly ISystemDownloadRepository _systemDownloadRepository;
        public SystemDownloadLogic(ISystemDownloadRepository systemDownloadRepository)
            : base(systemDownloadRepository)
        {
            _systemDownloadRepository = systemDownloadRepository;
        }

        #endregion

        #region ����

        /// <summary>
        ///     ����
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <returns></returns>
        public async Task<OperateStatus> Save(SystemDownload entity)
        {
            if (!entity.DownloadId.IsEmptyGuid())
                return await UpdateAsync(entity);
            entity.DownloadId = CombUtil.NewComb();
            return await InsertAsync(entity);
        }
        #endregion
    }
}