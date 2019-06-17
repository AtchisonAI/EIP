using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.System.Models.Dtos.Permission;
using EIP.System.Models.Entities;
using EIP.System.Models.Enums;

namespace EIP.System.DataAccess.Permission
{
    public interface ISystemPermissionUserRepository : IAsyncRepository<SystemPermissionUser>
    {
        /// <summary>
        ///     �����û�Idɾ��Ȩ���û���Ϣ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<int> DeletePermissionUser(IdInput input);

        /// <summary>
        ///     �����û�Idɾ��Ȩ���û���Ϣ
        /// </summary>
        /// <param name="privilegeMaster"></param>
        /// <param name="privilegeMasterValue"></param>
        /// <returns></returns>
        Task<int> DeletePermissionUser(EnumPrivilegeMaster privilegeMaster,
            Guid privilegeMasterValue);

        /// <summary>
        ///     ɾ���û�
        /// </summary>
        /// <param name="privilegeMasterUserId">�û�Id</param>
        /// <param name="privilegeMasterValue">��������Id:��֯��������ɫ����λ����</param>
        /// <param name="privilegeMaster">������Ա����:��֯��������ɫ����λ����</param>
        /// <returns></returns>
        Task<int> DeletePrivilegeMasterUser(Guid privilegeMasterUserId,
            Guid privilegeMasterValue,
            EnumPrivilegeMaster privilegeMaster);

        /// <summary>
        ///     ɾ���û�
        /// </summary>
        /// <param name="privilegeMasterUserId">�û�Id</param>
        /// <param name="privilegeMaster">������Ա����:��֯��������ɫ����λ����</param>
        /// <returns></returns>
        Task<int> DeletePrivilegeMasterUser(Guid privilegeMasterUserId,
            EnumPrivilegeMaster privilegeMaster);

        /// <summary>
        ///     �����û�Idɾ���û���������
        /// </summary>
        /// <param name="privilegeMaster">������Ա����:��֯��������ɫ����λ����</param>
        /// <param name="privilegeMasterUserId">�û�Id</param>
        /// <returns></returns>
        Task<int> DeletePermissionMaster(EnumPrivilegeMaster privilegeMaster,
            Guid privilegeMasterUserId);

        /// <summary>
        ///     �����û�Id��ȡ��ɫ���顢��λ��Ϣ
        /// </summary>
        /// <param name="input">��ԱId</param>
        /// <returns></returns>
        Task<IEnumerable<SystemPrivilegeDetailListOutput>> GetSystemPrivilegeDetailOutputsByUserId(IdInput input);

        /// <summary>
        ///     ������Ȩ���ͼ���Ȩid��ȡ��Ȩ�û���Ϣ
        /// </summary>
        /// <param name="privilegeMaster">��Ȩ����</param>
        /// <param name="privilegeMasterValue">��Ȩid</param>
        /// <returns></returns>
        Task<IEnumerable<SystemPermissionUser>> GetPermissionUsersByPrivilegeMasterAdnPrivilegeMasterValue(
            EnumPrivilegeMaster privilegeMaster,
            Guid? privilegeMasterValue = null);

        /// <summary>
        ///     ��ȡ�˵����ֶζ�Ӧӵ������Ϣ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IEnumerable<SystemPrivilegeDetailListOutput>> GetSystemPrivilegeDetailOutputsByAccessAndValue(
            SystemPrivilegeDetailInput input);
    }
}