using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Core.Extensions;
using EIP.Common.Core.Resource;
using EIP.Common.Core.Utils;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.System.DataAccess.Permission;
using EIP.System.Models.Dtos.Permission;
using EIP.System.Models.Entities;
using EIP.System.Models.Enums;

namespace EIP.System.Business.Permission
{
    /// <summary>
    ///     ������ҵ���߼�
    /// </summary>
    public class SystemMenuButtonLogic : AsyncLogic<SystemMenuButton>, ISystemMenuButtonLogic
    {
        #region ���캯��

        private readonly ISystemMenuButtonRepository _functionRepository;
        private readonly ISystemPermissionLogic _permissionLogic;

        public SystemMenuButtonLogic(ISystemMenuButtonRepository functionRepository,
            ISystemPermissionLogic permissionLogic)
            : base(functionRepository)
        {
            _permissionLogic = permissionLogic;
            _functionRepository = functionRepository;
        }

        #endregion

        #region ����

        /// <summary>
        ///     ���ݲ˵���ȡ��������Ϣ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SystemMenuButtonOutput>> GetMenuButtonByMenuId(NullableIdInput input)
        {
            var functions = await _functionRepository.GetMenuButtonByMenuId(input);
            return functions.OrderBy(o => o.MenuName).ThenBy(b => b.OrderNo).ToList();
        }

        /// <summary>
        ///     ���湦������Ϣ
        /// </summary>
        /// <param name="function">��������Ϣ</param>
        /// <returns></returns>
        public async Task<OperateStatus> SaveMenuButton(SystemMenuButton function)
        {
            if (function.MenuButtonId.IsEmptyGuid())
            {
                function.MenuButtonId = CombUtil.NewComb();
                return await InsertAsync(function);
            }
            return await UpdateAsync(function);
        }

        /// <summary>
        ///     ɾ��������
        /// </summary>
        /// <param name="input">��������Ϣ</param>
        /// <returns></returns>
        public async Task<OperateStatus> DeleteMenuButton(IdInput input)
        {
            var operateStatus = new OperateStatus();
            //�鿴�ù������Ƿ��ѱ�����ռ��
            var permissions = await _permissionLogic.GetSystemPermissionsByPrivilegeAccessAndValue(EnumPrivilegeAccess.�˵���ť, input.Id);
            if (permissions.Any())
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format(Chs.Error, ResourceSystem.�ѱ�����Ȩ��);
                return operateStatus;
            }
            return await DeleteAsync(input.Id);
        }

        /// <summary>
        ///     ��ȡ��¼��Ա��Ӧ�˵��µĹ�����
        /// </summary>
        /// <param name="mvcRote">·����Ϣ</param>
        /// <param name="userId">�û�Id</param>
        /// <returns></returns>
        public async Task< IEnumerable<SystemMenuButton>> GetMenuButtonByMenuIdAndUserId(MvcRote mvcRote,
            Guid userId)
        {
            return (await _functionRepository.GetMenuButtonByMenuIdAndUserId(mvcRote, userId)).ToList();
        }

        #endregion
    }
}