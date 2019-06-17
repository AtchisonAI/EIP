using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Core.Extensions;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Tree;
using EIP.Common.Core.Resource;
using EIP.Common.Core.Utils;
using EIP.System.DataAccess.Permission;
using EIP.System.Models.Entities;
using EIP.System.Models.Enums;

namespace EIP.System.Business.Permission
{
    public class SystemMenuLogic : AsyncLogic<SystemMenu>, ISystemMenuLogic
    {
        #region ���캯��

        private readonly ISystemMenuRepository _menuRepository;
        private readonly ISystemPermissionLogic _permissionLogic;

        public SystemMenuLogic(ISystemMenuRepository menuRepository,
            ISystemPermissionLogic permissionLogic)
            : base(menuRepository)
        {
            _permissionLogic = permissionLogic;
            _menuRepository = menuRepository;
        }

        #endregion

        #region ����

        /// <summary>
        ///     ����״̬ΪTrue�Ĳ˵���Ϣ
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TreeEntity>> GetAllPortalMenu()
        {
            return await _menuRepository.GetAllPortalMenu();
        }

        /// <summary>
        ///     ����״̬ΪTrue�Ĳ˵���Ϣ
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TreeEntity>> GetAllMenu()
        {
            return await _menuRepository.GetAllMenu();
        }

        /// <summary>
        ///     ����״̬ΪTrue�Ĳ˵���Ϣ
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SystemMenu>> GetMeunuByPId(IdInput input)
        {
            return await _menuRepository.GetMeunuByPId(input);
        }

        /// <summary>
        ///     ����˵�
        /// </summary>
        /// <param name="menu">�˵���Ϣ</param>
        /// <returns></returns>
        public async Task<OperateStatus<Guid>> SaveMenu(SystemMenu menu)
        {
            OperateStatus<Guid> operateStatus = new OperateStatus<Guid>();
            OperateStatus result;
            menu.CanbeDelete = true;
            if (menu.MenuId.IsEmptyGuid())
            {
                menu.MenuId = CombUtil.NewComb();
                result = await InsertAsync(menu);
            }
            else
            {
                result = await UpdateAsync(menu);
            }
            if (result.ResultSign != ResultSign.Successful) return operateStatus;
            operateStatus.ResultSign = result.ResultSign;
            operateStatus.Message = result.Message;
            operateStatus.Data = menu.MenuId;
            return operateStatus;
        }

        /// <summary>
        ///     ɾ���˵����¼�����
        /// </summary>
        /// <param name="input">����id</param>
        /// <returns></returns>
        public async Task<OperateStatus> DeleteMenu(IdInput input)
        {
            var operateStatus = new OperateStatus();

            //�жϸ����ܷ����ɾ��
            var menu = await GetByIdAsync(input.Id);

            if (menu != null && !menu.CanbeDelete)
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = Chs.CanotDelete;
                return operateStatus;
            }
            //�鿴�Ƿ�����¼�
            if ((await GetMeunuByPId(input)).Any())
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format(Chs.Error, ResourceSystem.�����¼���);
                return operateStatus;
            }
            //�鿴�ò˵��Ƿ��ѱ�����ռ��
            var permissions = await _permissionLogic.GetSystemPermissionsByPrivilegeAccessAndValue(EnumPrivilegeAccess.�˵�, input.Id);
            if (permissions.Any())
            {
                //��ȡ��ռ�����ͼ�ֵ
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format(Chs.Error, ResourceSystem.�ѱ�����Ȩ��);
                return operateStatus;
            }
            return await DeleteAsync(input.Id);
        }

        /// <summary>
        ///     �������Ƿ��Ѿ������ظ���
        /// </summary>
        /// <param name="input">��Ҫ��֤�Ĳ���</param>
        /// <returns></returns>
        public async Task<OperateStatus> CheckMenuCode(CheckSameValueInput input)
        {
            var operateStatus = new OperateStatus();
            if (await _menuRepository.CheckMenuCode(input))
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
        ///     ��ѯ���о��в˵�Ȩ�޵Ĳ˵�
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TreeEntity>> GetHaveMenuPermissionMenu()
        {
            return await _menuRepository.GetHaveMenuPermissionMenu();
        }

        /// <summary>
        ///     ��ѯ���о�������Ȩ�޵Ĳ˵�
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TreeEntity>> GetHaveDataPermissionMenu()
        {
            return await _menuRepository.GetHaveDataPermissionMenu();
        }

        /// <summary>
        ///     ��ѯ���о����ֶ�Ȩ�޵Ĳ˵�
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TreeEntity>> GetHaveFieldPermissionMenu()
        {
            return await _menuRepository.GetHaveFieldPermissionMenu();
        }

        /// <summary>
        ///     ��ѯ���о��й�����Ĳ˵�
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TreeEntity>> GetHaveMenuButtonPermissionMenu()
        {
            return await _menuRepository.GetHaveMenuButtonPermissionMenu();
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
                //��ȡ���в˵�
                var menus = (await GetAllEnumerableAsync()).ToList();
                var topMenu = menus.Where(w => w.ParentId == Guid.Empty);
                foreach (var menu in topMenu)
                {
                    menu.Code = PinYinUtil.GetFirst(menu.Name);
                    await UpdateAsync(menu);
                    await GeneratingCodeRecursion(menu, menus.ToList(), "");
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
        /// <param name="menu"></param>
        /// <param name="menus"></param>
        /// <param name="generationCode"></param>
        private async Task GeneratingCodeRecursion(SystemMenu menu, IList<SystemMenu> menus, string generationCode)
        {
            string emp = PinYinUtil.GetFirst(menu.Name);
            //��ȡ�¼�
            var nextMenu = menus.Where(w => w.ParentId == menu.MenuId).ToList();
            if (nextMenu.Any())
            {
                emp = generationCode.IsNullOrEmpty() ? emp : generationCode + "_" + emp;
            }
            foreach (var me in nextMenu)
            {
                me.Code = emp + "_" + PinYinUtil.GetFirst(me.Name);
                await UpdateAsync(me);
                await GeneratingCodeRecursion(me, menus, emp);
            }
        }

        #region ����ɾ��Demo

        ///// <summary>
        /////     ɾ���˵����¼�����
        ///// </summary>
        ///// <param name="menuId">����id</param>
        ///// <returns></returns>
        //public OperateStatus DeleteMenu(Guid menuId)
        //{
        //    var operateStatus = new OperateStatus();

        //    //�жϸ����ܷ����ɾ��
        //    var menu = GetById(menuId);
        //    if (!menu.CanbeDelete)
        //    {
        //        operateStatus.ResultSign = ResultSign.Error;
        //        operateStatus.Message = Chs.CanotDelete;
        //        return operateStatus;
        //    }
        //    MenuDeletGuid.Add(menuId);
        //    GetMenuDeleteGuid(menuId);
        //    foreach (var delete in MenuDeletGuid)
        //    {
        //        operateStatus = Delete(delete);
        //    }
        //    return operateStatus;
        //}

        ///// <summary>
        /////     ɾ����������
        ///// </summary>
        //public IList<Guid> MenuDeletGuid = new List<Guid>();

        ///// <summary>
        /////     ��ȡɾ��������Ϣ
        ///// </summary>
        ///// <param name="guid"></param>
        //private void GetMenuDeleteGuid(Guid guid)
        //{
        //    //��ȡ�¼�
        //    var menus = _menuRepository.GetMeunuByPId(guid);
        //    foreach (var dic in menus)
        //    {
        //        MenuDeletGuid.Add(dic.MenuId);
        //        GetMenuDeleteGuid(dic.MenuId);
        //    }
        //}

        #endregion

        #endregion


    }
}