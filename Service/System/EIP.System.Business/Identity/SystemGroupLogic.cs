using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Core.Extensions;
using EIP.Common.Core.Utils;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.Common.Core.Resource;
using EIP.System.Business.Permission;
using EIP.System.DataAccess.Identity;
using EIP.System.Models.Dtos.Identity;
using EIP.System.Models.Dtos.Permission;
using EIP.System.Models.Entities;
using EIP.System.Models.Enums;

namespace EIP.System.Business.Identity
{
    public class SystemGroupLogic : AsyncLogic<SystemGroup>, ISystemGroupLogic
    {
        #region ���캯��

        private readonly ISystemGroupRepository _groupRepository;
        private readonly ISystemPermissionUserLogic _permissionUserLogic;
        private readonly ISystemPermissionLogic _permissionLogic;

        public SystemGroupLogic(ISystemGroupRepository groupRepository,
            ISystemPermissionUserLogic permissionUserLogic,
            ISystemPermissionLogic permissionLogic)
            : base(groupRepository)
        {
            _permissionUserLogic = permissionUserLogic;
            _permissionLogic = permissionLogic;
            _groupRepository = groupRepository;
        }

        #endregion

        #region ����

        /// <summary>
        ///     ������֯������ȡ����Ϣ
        /// </summary>
        /// <param name="input">��֯����</param>
        /// <returns></returns>
        public async Task<IEnumerable<SystemGroupOutput>> GetGroupByOrganizationId(NullableIdInput input)
        {
            var groups =(await _groupRepository.GetGroupByOrganizationId(input)).ToList();

            //��ȡ��֯������Ϣ
            foreach (var group in groups)
            {
                group.BelongToName = EnumUtil.GetName(typeof (EnumGroupBelongTo), group.BelongTo);
            }
            return groups;
        }

        /// <summary>
        ///     �������������Ƿ��Ѿ������ظ���
        /// </summary>
        /// <param name="input">��Ҫ��֤�Ĳ���</param>
        /// <returns></returns>
        public async Task<OperateStatus> CheckGroupCode(CheckSameValueInput input)
        {
            var operateStatus = new OperateStatus();
            if (await _groupRepository.CheckGroupCode(input))
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format(Chs.HaveCode, input.Param);
            }
            else
            {
                operateStatus.ResultSign = ResultSign.Successful;
                operateStatus.Message = Chs.CheckSuccessful;
            }
            return operateStatus;
        }

        /// <summary>
        ///     ��������Ϣ
        /// </summary>
        /// <param name="group">��λ��Ϣ</param>
        /// <param name="belongTo">����</param>
        /// <returns></returns>
        public async Task<OperateStatus> SaveGroup(SystemGroup group,
            EnumGroupBelongTo belongTo)
        {
            group.BelongTo = (byte) belongTo;
            if (group.GroupId.IsEmptyGuid())
            {
                group.CreateTime = DateTime.Now;
                group.GroupId = CombUtil.NewComb();
                return await InsertAsync(group);
            }
            var systemGroup =await GetByIdAsync(group.GroupId);
            group.CreateTime = systemGroup.CreateTime;
            group.CreateUserId = systemGroup.CreateUserId;
            group.CreateUserName = systemGroup.CreateUserName;
            group.UpdateTime = DateTime.Now;
            group.UpdateUserId = group.CreateUserId;
            group.UpdateUserName = group.CreateUserName;
            return await UpdateAsync(group);
        }

        /// <summary>
        ///     ɾ������Ϣ
        /// </summary>
        /// <param name="input">��Id</param>
        /// <returns></returns>
        public async Task<OperateStatus> DeleteGroup(IdInput input)
        {
            var operateStatus = new OperateStatus();
            //�ж��Ƿ������Ա
            var permissionUsers =await 
                _permissionUserLogic.GetPermissionUsersByPrivilegeMasterAdnPrivilegeMasterValue(EnumPrivilegeMaster.��,
                    input.Id);
            if (permissionUsers.Any())
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format( Chs.Error, ResourceSystem.������Ա);
                return operateStatus;
            }
            //�ж��Ƿ���а�ťȨ��
            var functionPermissions =await 
                _permissionLogic.GetPermissionByPrivilegeMasterValue(
                    new GetPermissionByPrivilegeMasterValueInput
                    {
                        PrivilegeAccess = EnumPrivilegeAccess.�˵���ť,
                        PrivilegeMasterValue = input.Id,
                        PrivilegeMaster = EnumPrivilegeMaster.��
                    });
            if (functionPermissions.Any())
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format( Chs.Error, ResourceSystem.���й�����Ȩ��);
                return operateStatus;
            }
            //�ж��Ƿ���в˵�Ȩ��
            var menuPermissions =await 
                _permissionLogic.GetPermissionByPrivilegeMasterValue(
                    new GetPermissionByPrivilegeMasterValueInput
                    {
                        PrivilegeAccess = EnumPrivilegeAccess.�˵�,
                        PrivilegeMasterValue = input.Id,
                        PrivilegeMaster = EnumPrivilegeMaster.��
                    });

            if (menuPermissions.Any())
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format( Chs.Error, ResourceSystem.���в˵�Ȩ��);
                return operateStatus;
            }
            return await DeleteAsync(input.Id);
        }

        #endregion
    }
}