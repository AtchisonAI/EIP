using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Paging;
using EIP.System.Models.Dtos.Permission;
using EIP.System.Models.Entities;

namespace EIP.System.Business.Permission
{
    /// <summary>
    ///     ϵͳ�ֶ���ҵ���߼�
    /// </summary>
    public interface ISystemFieldLogic : IAsyncLogic<SystemField>
    {
        /// <summary>
        ///     ���ݲ˵�Id��ȡ�ֶ���Ϣ
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        Task<PagedResults<SystemFieldOutput>> GetFieldByMenuId(SystemFieldPagingInput paging);

        /// <summary>
        ///     �����ֶ���Ϣ
        /// </summary>
        /// <param name="field">�ֶ���Ϣ</param>
        /// <returns></returns>
        Task<OperateStatus> SaveField(SystemField field);

        /// <summary>
        ///     ɾ���ֶ���Ϣ
        /// </summary>
        /// <param name="input">�ֶ�Id</param>
        /// <returns></returns>
        Task<OperateStatus> DeleteField(IdInput input);
    }
}