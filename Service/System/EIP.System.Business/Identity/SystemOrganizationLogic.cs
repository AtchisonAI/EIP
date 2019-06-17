using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Core.Extensions;
using EIP.Common.Core.Utils;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Tree;
using EIP.Common.Core.Resource;
using EIP.System.Business.Permission;
using EIP.System.DataAccess.Identity;
using EIP.System.Models.Dtos.Identity;
using EIP.System.Models.Dtos.Permission;
using EIP.System.Models.Entities;
using EIP.System.Models.Enums;
namespace EIP.System.Business.Identity
{
    public class SystemOrganizationLogic : AsyncLogic<SystemOrganization>, ISystemOrganizationLogic
    {
        #region ���캯��

        private readonly ISystemOrganizationRepository _organizationRepository;
        private readonly ISystemPermissionUserLogic _permissionUserLogic;
        private readonly ISystemPermissionLogic _permissionLogic;
        private readonly ISystemGroupLogic _groupLogic;
        private readonly ISystemRoleLogic _roleLogic;
        private readonly ISystemPostLogic _postLogic;
        public SystemOrganizationLogic(ISystemOrganizationRepository organizationRepository,
            ISystemPermissionUserLogic permissionUserLogic,
            ISystemPermissionLogic permissionLogic, 
            ISystemGroupLogic groupLogic, 
            ISystemRoleLogic roleLogic,
            ISystemPostLogic postLogic)
            : base(organizationRepository)
        {
            _permissionUserLogic = permissionUserLogic;
            _permissionLogic = permissionLogic;
            _groupLogic = groupLogic;
            _roleLogic = roleLogic;
            _postLogic = postLogic;
            _organizationRepository = organizationRepository;
        }

        #endregion

        #region ����

        /// <summary>
        ///     �첽��ȡ������
        /// </summary>
        /// <param name="input">����id</param>
        /// <returns></returns>
        public async Task<IEnumerable<TreeEntity>> GetOrganizationTreeAsync(IdInput input)
        {
            var lists = (await _organizationRepository.GetSystemOrganizationByPid(input)).ToList();
            foreach (var list in lists)
            {
                var info = (await _organizationRepository.GetSystemOrganizationByPid(input)).ToList();
                if (info.Count > 0)
                {
                    list.isParent = true;
                }
            }
            return lists;
        }

        /// <summary>
        ///     ͬ����ȡ����������
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TreeEntity>> GetOrganizationTree()
        {
            return await _organizationRepository.GetSystemOrganization();
        }

        /// <summary>
        ///     ���ݸ�����ѯ�¼�
        /// </summary>
        /// <param name="input">����id</param>
        /// <returns></returns>
        public async Task<IEnumerable<SystemOrganizationOutput>> GetOrganizationResultByTreeId(IdInput input)
        {
            IList<SystemOrganizationOutput> organizations = (await _organizationRepository.GetOrganizationResultByTreeId(input)).ToList();
            foreach (var organization in organizations)
            {
                organization.NatureName = EnumUtil.GetName(typeof(EnumOrgNature), organization.Nature);
            }
            return organizations;
        }

        /// <summary>
        ///     �������Ƿ��Ѿ������ظ���
        /// </summary>
        /// <param name="input">��Ҫ��֤�Ĳ���</param>
        /// <returns></returns>
        public async Task<OperateStatus> CheckOrganizationCode(CheckSameValueInput input)
        {
            var operateStatus = new OperateStatus();
            if (await _organizationRepository.CheckOrganizationCode(input))
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
        ///     ������֯����
        /// </summary>
        /// <param name="organization">��֯����</param>
        /// <returns></returns>
        public async Task<OperateStatus> SaveOrganization(SystemOrganization organization)
        {
            if (organization.OrganizationId.IsEmptyGuid())
            {
                organization.CreateTime = DateTime.Now;
                organization.OrganizationId = Guid.NewGuid();
                return await InsertAsync(organization);
            }
            organization.UpdateTime = DateTime.Now;
            organization.UpdateUserId = organization.CreateUserId;
            organization.UpdateUserName = organization.CreateUserName;
            SystemOrganization systemOrganization = await GetByIdAsync(organization.OrganizationId);
            organization.CreateTime = systemOrganization.CreateTime;
            organization.CreateUserId = systemOrganization.CreateUserId;
            organization.CreateUserName = systemOrganization.CreateUserName;
            return await UpdateAsync(organization);
        }

        /// <summary>
        ///     ɾ����֯�����¼�����
        ///     ɾ������:
        ///     1:û���¼��˵�
        ///     2:û��Ȩ������
        ///     3:û����Ա
        /// </summary>
        /// <param name="input">��֯����id</param>
        /// <returns></returns>
        public async Task<OperateStatus> DeleteOrganization(IdInput input)
        {
            var operateStatus = new OperateStatus();
            //�ж��¼��˵�
            IList<TreeEntity> orgs = (await _organizationRepository.GetSystemOrganizationByPid(input)).ToList();
            if (orgs.Any())
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format(Chs.Error, ResourceSystem.�����¼���);
                return operateStatus;
            }

            //�ж��Ƿ������Ա
            var permissionUsers =await 
                _permissionUserLogic.GetPermissionUsersByPrivilegeMasterAdnPrivilegeMasterValue(
                    EnumPrivilegeMaster.��֯����,
                    input.Id);
            if (permissionUsers.Any())
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format(Chs.Error, ResourceSystem.������Ա);
                return operateStatus;
            }

            //�ж��Ƿ��н�ɫ
            var orgRole = await
               _roleLogic.GetRolesByOrganizationId(new NullableIdInput(input.Id));
            if (orgRole.Any())
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format(Chs.Error, ResourceSystem.���н�ɫ);
                return operateStatus;
            }

            //�ж��Ƿ�����
            var orgGroup = await
                _groupLogic.GetGroupByOrganizationId(new NullableIdInput(input.Id));
            if (orgGroup.Any())
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format(Chs.Error, ResourceSystem.������);
                return operateStatus;
            }

            //�ж��Ƿ��и�λ
            var orgPost = await
               _postLogic.GetPostByOrganizationId(new NullableIdInput(input.Id));
            if (orgPost.Any())
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format(Chs.Error, ResourceSystem.���и�λ);
                return operateStatus;
            }

            //�ж��Ƿ���а�ťȨ��
            var functionPermissions =await 
                _permissionLogic.GetPermissionByPrivilegeMasterValue(
                  new GetPermissionByPrivilegeMasterValueInput()
                {
                    PrivilegeAccess = EnumPrivilegeAccess.�˵���ť,
                    PrivilegeMasterValue = input.Id,
                    PrivilegeMaster = EnumPrivilegeMaster.��֯����
                });
            if (functionPermissions.Any())
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format(Chs.Error, ResourceSystem.���й�����Ȩ��);
                return operateStatus;
            }
            //�ж��Ƿ���в˵�Ȩ��
            var menuPermissions =await 
                _permissionLogic.GetPermissionByPrivilegeMasterValue(
                 new GetPermissionByPrivilegeMasterValueInput()
                {
                    PrivilegeAccess = EnumPrivilegeAccess.�˵�,
                    PrivilegeMasterValue = input.Id,
                    PrivilegeMaster = EnumPrivilegeMaster.��֯����
                });
            if (menuPermissions.Any())
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format(Chs.Error, ResourceSystem.���в˵�Ȩ��);
                return operateStatus;
            }
            //����ɾ������
            return await DeleteAsync(input.Id);
        }
        /// <summary>
        ///     �������ɴ���
        /// </summary>
        /// <returns></returns>
        public async Task<OperateStatus> GeneratingCode()
        {
            OperateStatus operateStatus = new OperateStatus();
            try
            {
                //��ȡ�����ֵ���
                var dics = (await GetAllEnumerableAsync()).ToList();
                var topOrgs = dics.Where(w => w.ParentId == Guid.Empty);
                foreach (var org in topOrgs)
                {
                    org.Code = PinYinUtil.GetFirst(org.Name);
                    await UpdateAsync(org);
                    await GeneratingCodeRecursion(org, dics.ToList(), "");
                }
            }
            catch (Exception ex)
            {
                operateStatus.Message = string.Format(Chs.Error, ex.Message);
                return operateStatus;
            }
            operateStatus.Message = Chs.Successful;
            operateStatus.ResultSign = ResultSign.Successful;
            return operateStatus;
        }

        /// <summary>
        /// �ݹ��ȡ����
        /// </summary>
        /// <param name="organization"></param>
        /// <param name="dictionaries"></param>
        /// <param name="generationCode"></param>
        private async Task GeneratingCodeRecursion(SystemOrganization organization, IList<SystemOrganization> dictionaries, string generationCode)
        {
            string emp = PinYinUtil.GetFirst(organization.Name);
            //��ȡ�¼�
            var nextOrg = dictionaries.Where(w => w.ParentId == organization.OrganizationId).ToList();
            if (nextOrg.Any())
            {
                emp = generationCode.IsNullOrEmpty() ? emp : generationCode + "_" + emp;
            }
            foreach (var org in nextOrg)
            {
                org.Code = emp + "_" + PinYinUtil.GetFirst(org.Name);
                await UpdateAsync(org);
                await GeneratingCodeRecursion(org, dictionaries, emp);
            }
        }

        /// <summary>
        /// ����Ȩ����֯������
        /// </summary>
        ///  <param name="input"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TreeEntity>> GetOrganizationResultByDataPermission(IdInput<string> input)
        {
            return await _organizationRepository.GetOrganizationResultByDataPermission(input);
        }
        #endregion
    }
}