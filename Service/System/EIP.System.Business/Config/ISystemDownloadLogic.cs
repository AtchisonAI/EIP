using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Entities;
using EIP.System.Models.Entities;

namespace EIP.System.Business.Config
{
	/// <summary>
    /// �������ؼ�¼��ҵ���߼��ӿ�
    /// </summary>
    public interface ISystemDownloadLogic : IAsyncLogic<SystemDownload>
    {
        /// <summary>
        ///     ����
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <returns></returns>
        Task<OperateStatus> Save(SystemDownload entity);
    }
}