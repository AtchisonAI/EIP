using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Entities;
using EIP.System.Models.Entities;
using EIP.Common.Entities.Dtos;
using EIP.System.Models.Dtos.Permission;

namespace EIP.System.Business.Permission
{
    /// <summary>
    ///     ������ҵ���߼�
    /// </summary>
    public interface ISystemMenuButtonLogic : IAsyncLogic<SystemMenuButton>
    {
        /// <summary>
        ///     ���ݲ˵���ȡ��������Ϣ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IEnumerable<SystemMenuButtonOutput>> GetMenuButtonByMenuId(NullableIdInput input);

        /// <summary>
        ///     ���湦������Ϣ
        /// </summary>
        /// <param name="function">��������Ϣ</param>
        /// <returns></returns>
        Task<OperateStatus> SaveMenuButton(SystemMenuButton function);

        /// <summary>
        ///     ɾ��������
        /// </summary>
        /// <param name="input">��������Ϣ</param>
        /// <returns></returns>
        Task<OperateStatus> DeleteMenuButton(IdInput input);

        /// <summary>
        ///     ��ȡ��¼��Ա��Ӧ�˵��µĹ�����
        /// </summary>
        /// <param name="mvcRote">·����Ϣ</param>
        /// <param name="userId">�û�Id</param>
        /// <returns></returns>
        Task<IEnumerable<SystemMenuButton>> GetMenuButtonByMenuIdAndUserId(MvcRote mvcRote,
             Guid userId);
    }
}