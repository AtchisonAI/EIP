using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Entities;
using EIP.System.Models.Entities;
using EIP.Common.Entities.Dtos;

namespace EIP.System.Business.Config
{
	/// <summary>
    /// �������ű�ҵ���߼��ӿ�
    /// </summary>
    public interface ISystemArticleLogic : IAsyncLogic<SystemArticle>
    {
        /// <summary>
        ///     ����
        /// </summary>
        /// <param name="model">ʵ��</param>
        /// <returns></returns>
        Task<OperateStatus> Save(SystemArticle model);

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperateStatus> SaveViewNums(IdInput input);
    }
}