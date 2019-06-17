using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.System.Models.Dtos.Permission;
using EIP.System.Models.Entities;
using EIP.System.Models.Enums;

namespace EIP.System.Business.Permission
{
    /// <summary>
    ///     Ȩ���û�ҵ���߼��ӿ�
    /// </summary>
    public interface ISystemPermissionUserLogic : IAsyncLogic<SystemPermissionUser>
    {
        /// <summary>
        ///     ��������û�:��֯��������λ���顢��Ա
        /// </summary>
        /// <param name="master">����</param>
        /// <param name="value">ҵ���Id������֯����Id����Id����λId����ԱId��</param>
        /// <param name="userIds">Ȩ������:��֯�������顢��λ����ԱId</param>
        /// <returns></returns>
        Task<OperateStatus> SavePermissionUser(EnumPrivilegeMaster master,
            Guid value,
            IList<Guid> userIds);

        /// <summary>
        ///     ��������û�:��֯��������λ���顢��Ա���Ƚ���ɾ��,�ٽ�����ӡ�
        /// </summary>
        /// <param name="master">����</param>
        /// <param name="value">ҵ���Id������֯����Id����Id����λId����ԱId��</param>
        /// <param name="userIds">Ȩ������:��֯�������顢��λ����ԱId</param>
        /// <returns></returns>
        Task<OperateStatus> SavePermissionUserBeforeDelete(EnumPrivilegeMaster master,
            Guid value,
            IList<Guid> userIds);

        /// <summary>
        ///     ɾ���û�
        /// </summary>
        /// <param name="input">Ȩ������:��֯�������顢��λ����ԱId</param>
        /// <returns></returns>
        Task<OperateStatus> DeletePermissionUser(IdInput input);

        /// <summary>
        ///     �����û�Ȩ������
        /// </summary>
        /// <param name="privilegeMaster">����</param>
        /// <param name="privilegeMasterUserId">ҵ���Id������֯����Id����Id����λId����ԱId��</param>
        /// <param name="privilegeMasterValue">Ȩ������:��ɫId</param>
        /// <returns></returns>
        Task<OperateStatus> SavePermissionMasterValueBeforeDelete(EnumPrivilegeMaster privilegeMaster,
            Guid privilegeMasterUserId,
            IList<Guid> privilegeMasterValue);

        /// <summary>
        ///     ɾ���û�
        /// </summary>
        /// <param name="privilegeMasterUserId">�û�Id</param>
        /// <param name="privilegeMasterValue">��������Id:��֯��������ɫ����λ����</param>
        /// <param name="privilegeMaster">������Ա����:��֯��������ɫ����λ����</param>
        /// <returns></returns>
        Task<OperateStatus> DeletePrivilegeMasterUser(Guid privilegeMasterUserId,
            Guid privilegeMasterValue,
            EnumPrivilegeMaster privilegeMaster);

        /// <summary>
        ///     ɾ���û���ӦȨ������
        /// </summary>
        /// <param name="privilegeMasterUserId">�û�Id</param>
        /// <param name="privilegeMaster">������Ա����:��֯��������ɫ����λ����</param>
        /// <returns></returns>
        Task<OperateStatus> DeletePrivilegeMasterUser(Guid privilegeMasterUserId,
            EnumPrivilegeMaster privilegeMaster);

        /// <summary>
        ///     �����û�Id��ȡ��ɫ���顢��λ��Ϣ
        /// </summary>
        /// <param name="input">��ԱId</param>
        /// <returns></returns>
        Task<IEnumerable<SystemPrivilegeDetailListOutput>> GetSystemPrivilegeDetailOutputsByUserId(IdInput input);

        /// <summary>
        ///     ��ȡ�˵����ֶζ�Ӧӵ������Ϣ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<SystemPrivilegeDetailOutput> GetSystemPrivilegeDetailOutputsByAccessAndValue(
            SystemPrivilegeDetailInput input);

        /// <summary>
        ///     ������Ȩ���ͼ���Ȩid��ȡ��Ȩ�û���Ϣ
        /// </summary>
        /// <param name="privilegeMaster">��Ȩ����</param>
        /// <param name="privilegeMasterValue">��Ȩid</param>
        /// <returns></returns>
        Task<IEnumerable<SystemPermissionUser>> GetPermissionUsersByPrivilegeMasterAdnPrivilegeMasterValue(
            EnumPrivilegeMaster privilegeMaster,
            Guid? privilegeMasterValue = null);
    }
}