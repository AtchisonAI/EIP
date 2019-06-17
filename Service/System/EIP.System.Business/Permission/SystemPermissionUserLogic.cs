using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Core.Extensions;
using EIP.Common.Core.Resource;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.System.DataAccess.Permission;
using EIP.System.Models.Dtos.Permission;
using EIP.System.Models.Entities;
using EIP.System.Models.Enums;

namespace EIP.System.Business.Permission
{
    /// <summary>
    ///     Ȩ���û�ҵ���߼�
    /// </summary>
    public class SystemPermissionUserLogic : AsyncLogic<SystemPermissionUser>, ISystemPermissionUserLogic
    {
        #region ���캯��

        private readonly ISystemPermissionUserRepository _permissionUsernRepository;

        public SystemPermissionUserLogic(ISystemPermissionUserRepository permissionUserRepository)
            : base(permissionUserRepository)
        {
            _permissionUsernRepository = permissionUserRepository;
        }

        #endregion

        #region ����

        /// <summary>
        ///     ��������û�:��֯��������λ���顢��Ա
        /// </summary>
        /// <param name="master">����</param>
        /// <param name="value">ҵ���Id������֯����Id����Id����λId����ԱId��</param>
        /// <param name="userIds">Ȩ������:��֯�������顢��λ����ԱId</param>
        /// <returns></returns>
        public async Task<OperateStatus> SavePermissionUser(EnumPrivilegeMaster master,
            Guid value,
            IList<Guid> userIds)
        {
            IList<SystemPermissionUser> systemPermissionUsers = userIds.Select(userId => new SystemPermissionUser
            {
                PrivilegeMaster = (byte)master,
                PrivilegeMasterUserId = userId,
                PrivilegeMasterValue = value
            }).ToList();
            //��������
            return await InsertMultipleAsync(systemPermissionUsers);
        }

        /// <summary>
        ///     ��������û�:��֯��������λ���顢��Ա���Ƚ���ɾ��,�ٽ�����ӡ�
        /// </summary>
        /// <param name="master">����</param>
        /// <param name="value">ҵ���Id������֯����Id����Id����λId����ԱId��</param>
        /// <param name="userIds">Ȩ������:��֯�������顢��λ����ԱId</param>
        /// <returns></returns>
        public async Task<OperateStatus> SavePermissionUserBeforeDelete(EnumPrivilegeMaster master,
            Guid value,
            IList<Guid> userIds)
        {
            var operateStatus = new OperateStatus();
            //ɾ��
            await _permissionUsernRepository.DeletePermissionUser(master, value);
            IList<SystemPermissionUser> systemPermissionUsers = userIds.Select(userId => new SystemPermissionUser
            {
                PrivilegeMaster = (byte)master,
                PrivilegeMasterUserId = userId,
                PrivilegeMasterValue = value
            }).ToList();
            if (systemPermissionUsers.Any())
            {
                //��������
                operateStatus = await InsertMultipleAsync(systemPermissionUsers);
            }
            else
            {
                operateStatus.ResultSign = ResultSign.Successful;
                operateStatus.Message = Chs.Successful;
            }
            return operateStatus;
        }

        /// <summary>
        ///     �����û�Ȩ������
        /// </summary>
        /// <param name="privilegeMaster">����</param>
        /// <param name="privilegeMasterUserId">ҵ���Id������֯����Id����Id����λId����ԱId��</param>
        /// <param name="privilegeMasterValue">Ȩ������:��ɫId</param>
        /// <returns></returns>
        public async Task<OperateStatus> SavePermissionMasterValueBeforeDelete(EnumPrivilegeMaster privilegeMaster,
            Guid privilegeMasterUserId,
            IList<Guid> privilegeMasterValue)
        {
            var operateStatus = new OperateStatus();
            //ɾ��
            await _permissionUsernRepository.DeletePermissionMaster(privilegeMaster, privilegeMasterUserId);
            IList<SystemPermissionUser> systemPermissionUsers =
                privilegeMasterValue.Select(roleId => new SystemPermissionUser
                {
                    PrivilegeMaster = (byte)privilegeMaster,
                    PrivilegeMasterUserId = privilegeMasterUserId,
                    PrivilegeMasterValue = roleId
                }).ToList();
            if (systemPermissionUsers.Any())
            {
                //��������
                operateStatus = await InsertMultipleAsync(systemPermissionUsers);
            }
            else
            {
                operateStatus.ResultSign = ResultSign.Successful;
                operateStatus.Message = Chs.Successful;
            }
            return operateStatus;
        }

        /// <summary>
        ///     ɾ���û�
        /// </summary>
        /// <param name="input">�û�Id</param>
        /// <returns></returns>
        public async Task<OperateStatus> DeletePermissionUser(IdInput input)
        {
            var operateStatus = new OperateStatus();
            if (await _permissionUsernRepository.DeletePermissionUser(input) > 0)
            {
                operateStatus.ResultSign = ResultSign.Successful;
                operateStatus.Message = Chs.Successful;
            }
            return operateStatus;
        }

        /// <summary>
        ///     ɾ���û�
        /// </summary>
        /// <param name="privilegeMasterUserId">�û�Id</param>
        /// <param name="privilegeMasterValue">��������Id:��֯��������ɫ����λ����</param>
        /// <param name="privilegeMaster">������Ա����:��֯��������ɫ����λ����</param>
        /// <returns></returns>
        public async Task<OperateStatus> DeletePrivilegeMasterUser(Guid privilegeMasterUserId,
            Guid privilegeMasterValue,
            EnumPrivilegeMaster privilegeMaster)
        {
            var operateStatus = new OperateStatus();
            if (
                await _permissionUsernRepository.DeletePrivilegeMasterUser(privilegeMasterUserId, privilegeMasterValue,
                    privilegeMaster) > 0)
            {
                operateStatus.ResultSign = ResultSign.Successful;
                operateStatus.Message = Chs.Successful;
            }
            return operateStatus;
        }

        /// <summary>
        ///     �����û�Id��ȡ��ɫ���顢��λ��Ϣ
        /// </summary>
        /// <param name="input">��ԱId</param>
        /// <returns></returns>
        public async Task<IEnumerable<SystemPrivilegeDetailListOutput>> GetSystemPrivilegeDetailOutputsByUserId(
            IdInput input)
        {
            return await _permissionUsernRepository.GetSystemPrivilegeDetailOutputsByUserId(input);
        }

        /// <summary>
        ///     ������Ȩ���ͼ���Ȩid��ȡ��Ȩ�û���Ϣ
        /// </summary>
        /// <param name="privilegeMaster">��Ȩ����</param>
        /// <param name="privilegeMasterValue">��Ȩid</param>
        /// <returns></returns>
        public async Task<IEnumerable<SystemPermissionUser>> GetPermissionUsersByPrivilegeMasterAdnPrivilegeMasterValue(
            EnumPrivilegeMaster privilegeMaster,
            Guid? privilegeMasterValue = null)
        {
            return
                await
                    _permissionUsernRepository.GetPermissionUsersByPrivilegeMasterAdnPrivilegeMasterValue(
                        privilegeMaster, privilegeMasterValue);
        }

        /// <summary>
        ///     ��ȡ�˵����ֶζ�Ӧӵ������Ϣ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<SystemPrivilegeDetailOutput> GetSystemPrivilegeDetailOutputsByAccessAndValue(
            SystemPrivilegeDetailInput input)
        {
            var output = new SystemPrivilegeDetailOutput();
            //��ȡ��ɫ���顢��λ����
            IList<SystemPrivilegeDetailListOutput> privilegeDetailDtos =
                (await _permissionUsernRepository.GetSystemPrivilegeDetailOutputsByAccessAndValue(input)).DistinctBy(
                    p => new {p.Name, p.Organization, p.PrivilegeMaster }).ToList();
            //��ɫ
            output.Role = privilegeDetailDtos.Where(w => w.PrivilegeMaster == EnumPrivilegeMaster.��ɫ).ToList();
            //��
            output.Group = privilegeDetailDtos.Where(w => w.PrivilegeMaster == EnumPrivilegeMaster.��).ToList();
            //��λ
            output.Post = privilegeDetailDtos.Where(w => w.PrivilegeMaster == EnumPrivilegeMaster.��λ).ToList();
            //��֯����
            output.Organization = privilegeDetailDtos.Where(w => w.PrivilegeMaster == EnumPrivilegeMaster.��֯����).ToList();
            //�û�
            output.User = privilegeDetailDtos.Where(w => w.PrivilegeMaster == EnumPrivilegeMaster.��Ա).ToList();
            return output;
        }

        #endregion

        /// <summary>
        ///     ɾ���û���ӦȨ������
        /// </summary>
        /// <param name="privilegeMasterUserId">�û�Id</param>
        /// <param name="privilegeMaster">������Ա����:��֯��������ɫ����λ����</param>
        /// <returns></returns>
        public async Task<OperateStatus> DeletePrivilegeMasterUser(Guid privilegeMasterUserId, EnumPrivilegeMaster privilegeMaster)
        {
            var operateStatus = new OperateStatus();
            if (await _permissionUsernRepository.DeletePrivilegeMasterUser(privilegeMasterUserId,privilegeMaster) > 0)
            {
                operateStatus.ResultSign = ResultSign.Successful;
                operateStatus.Message = Chs.Successful;
            }
            return operateStatus;
        }
    }
}