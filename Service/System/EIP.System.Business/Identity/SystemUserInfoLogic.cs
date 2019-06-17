using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Core.Config;
using EIP.Common.Core.Extensions;
using EIP.Common.Core.Report.Excel;
using EIP.Common.Core.Resource;
using EIP.Common.Core.Utils;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Dtos.Reports;
using EIP.Common.Entities.Paging;
using EIP.System.Business.Permission;
using EIP.System.DataAccess.Identity;
using EIP.System.Models.Dtos.Identity;
using EIP.System.Models.Dtos.Permission;
using EIP.System.Models.Entities;
using EIP.System.Models.Enums;
namespace EIP.System.Business.Identity
{
    /// <summary>
    ///     �û�ҵ���߼�ʵ��
    /// </summary>
    public class SystemUserInfoLogic : AsyncLogic<SystemUserInfo>, ISystemUserInfoLogic
    {
        #region ���캯��

        private readonly ISystemPermissionUserLogic _permissionUserLogic;
        private readonly ISystemUserInfoRepository _userInfoRepository;

        public SystemUserInfoLogic(ISystemUserInfoRepository userInfoRepository,
            ISystemPermissionUserLogic permissionUserLogic)
            : base(userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
            _permissionUserLogic = permissionUserLogic;
        }

        public SystemUserInfoLogic()
        {
            _userInfoRepository = new SystemUserInfoRepository();
        }

        #endregion

        #region ����

        /// <summary>
        ///     ���ݵ�¼����������ѯ�û���Ϣ
        /// </summary>
        /// <param name="input">��¼���������</param>
        /// <returns></returns>
        public async Task<OperateStatus<SystemUserOutput>> CheckUserByCodeAndPwd(UserLoginInput input)
        {
            var operateStatus = new OperateStatus<SystemUserOutput>();
            //��������������
            var encryptPwd = DEncryptUtil.Encrypt(input.Pwd, GlobalParams.Get("pwdKey").ToString());
            //��ѯ��Ϣ
            input.Pwd = encryptPwd;
            var data = await _userInfoRepository.CheckUserByCodeAndPwd(input);
            //�Ƿ����
            if (data == null)
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = ResourceSystem.�û������������;
                return operateStatus;
            }
            //�Ƿ񶳽�
            if (data.IsFreeze)
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = ResourceSystem.��¼�û��Ѷ���;
                return operateStatus;
            }
            //�ɹ�
            operateStatus.ResultSign = ResultSign.Successful;
            operateStatus.Message = "/";
            operateStatus.Data = data;
            if (data.FirstVisitTime == null)
            {
                //�����û����һ�ε�¼ʱ��
                _userInfoRepository.UpdateFirstVisitTime(new IdInput(data.UserId));
            }
            //�����û����һ�ε�¼ʱ��
            _userInfoRepository.UpdateLastLoginTime(new IdInput(data.UserId));
            return operateStatus;
        }

        /// <summary>
        ///     ��ҳ��ѯ
        /// </summary>
        /// <param name="paging">��ҳ����</param>
        /// <returns></returns>
        public async Task<PagedResults<SystemUserOutput>> PagingUserQuery(SystemUserPagingInput paging)
        {
            return await _userInfoRepository.PagingUserQuery(paging);
        }

        /// <summary>
        ///     Excel������ʽ
        /// </summary>
        /// <param name="paging">��ѯ����</param>
        /// <param name="excelReportDto"></param>
        /// <returns></returns>
        public async Task<OperateStatus> ReportExcelUserQuery(SystemUserPagingInput paging,
            ExcelReportDto excelReportDto)
        {
            var operateStatus = new OperateStatus();
            try
            {
                //��װ����
                IList<SystemUserOutput> dtos = (await _userInfoRepository.PagingUserQuery(paging)).Data.ToList();
                var tables = new Dictionary<string, DataTable>(StringComparer.OrdinalIgnoreCase);
                //��װ��Ҫ��������
                var dt = new DataTable("User");
                dt.Columns.Add("Num");
                dt.Columns.Add("Code");
                dt.Columns.Add("Name");
                dt.Columns.Add("OrganizationName");
                dt.Columns.Add("Mobile");
                dt.Columns.Add("IsFreeze");
                dt.Columns.Add("CreatTime");
                dt.Columns.Add("FirstVisitTime");
                dt.Columns.Add("LastVisitTime");
                dt.Columns.Add("Remark");
                var num = 1;
                if (dtos.Any())
                {
                    foreach (var dto in dtos)
                    {
                        var row = dt.NewRow();
                        dt.Rows.Add(row);
                        row[0] = num;
                        row[1] = dto.Code;
                        row[2] = dto.Name;
                        row[3] = dto.OrganizationName;
                        row[4] = dto.Mobile;
                        row[5] = dto.IsFreeze ? "��" : "��";
                        row[7] = dto.FirstVisitTime;
                        row[8] = dto.LastVisitTime;
                        row[9] = dto.Remark;
                        num++;
                    }
                }
                tables.Add(dt.TableName, dt);
                OpenXmlExcel.ExportExcel(excelReportDto.TemplatePath, excelReportDto.DownPath, tables);
                operateStatus.ResultSign = ResultSign.Successful;
            }
            catch (Exception)
            {
                operateStatus.ResultSign = ResultSign.Error;
            }
            return operateStatus;
        }

        /// <summary>
        ///     �������������Ƿ��Ѿ������ظ���
        /// </summary>
        /// <param name="input">��Ҫ��֤�Ĳ���</param>
        /// <returns></returns>
        public async Task<OperateStatus> CheckUserCode(CheckSameValueInput input)
        {
            var operateStatus = new OperateStatus();
            if (await _userInfoRepository.CheckUserCode(input))
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format(Chs.HaveCode, input.Id);
            }
            else
            {
                operateStatus.ResultSign = ResultSign.Successful;
                operateStatus.Message = Chs.CheckSuccessful;
            }
            return operateStatus;
        }

        /// <summary>
        ///     ������Ա��Ϣ
        /// </summary>
        /// <param name="user">��Ա��Ϣ</param>
        /// <param name="orgId">ҵ���Id������֯����Id</param>
        /// <returns></returns>
        public async Task<OperateStatus> SaveUser(SystemUserInfo user,
            Guid orgId)
        {
            OperateStatus operateStatus;
            if (user.UserId.IsEmptyGuid())
            {
                //����
                user.CreateTime = DateTime.Now;
                user.UserId = Guid.NewGuid();
                user.Password = DEncryptUtil.Encrypt(GlobalParams.Get("defaultPwd").ToString(),
                    GlobalParams.Get("pwdKey").ToString());
                 operateStatus = await InsertAsync(user);
                if (operateStatus.ResultSign == ResultSign.Successful)
                {
                    //����û�����֯����
                    operateStatus =
                        await
                            _permissionUserLogic.SavePermissionUser(EnumPrivilegeMaster.��֯����, orgId,
                                new List<Guid> { user.UserId });
                    if (operateStatus.ResultSign == ResultSign.Successful)
                    {
                        return operateStatus;
                    }
                }
                else
                {
                    return operateStatus;
                }
            }
            else
            {
                //ɾ����Ӧ��֯����
                 operateStatus = await _permissionUserLogic.DeletePrivilegeMasterUser(user.UserId, EnumPrivilegeMaster.��֯����);
                if (operateStatus.ResultSign == ResultSign.Successful)
                {
                    //����û�����֯����
                    operateStatus = await _permissionUserLogic.SavePermissionUser(EnumPrivilegeMaster.��֯����, orgId, new List<Guid> { user.UserId });
                    if (operateStatus.ResultSign == ResultSign.Successful)
                    {
                        var userInfo = await GetByIdAsync(user.UserId);
                        user.CreateTime = userInfo.CreateTime;
                        user.Password = userInfo.Password;
                        user.UpdateTime = DateTime.Now;
                        user.UpdateUserId = userInfo.CreateUserId;
                        user.UpdateUserName = user.CreateUserName;
                        return await UpdateAsync(user);
                    }
                }
            }
            return operateStatus;
        }

        /// <summary>
        ///     ��ȡ�����û�
        /// </summary>
        /// <param name="input">�Ƿ񶳽�</param>
        /// <returns></returns>
        public async Task<IEnumerable<SystemChosenUserOutput>> GetChosenUser(FreezeInput input = null)
        {
            return await _userInfoRepository.GetChosenUser(input);
        }

        /// <summary>
        /// ��ȡ�û�
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SystemUserInfo>> GetUser(FreezeInput input = null)
        {
            return await _userInfoRepository.GetUser(input);
        }

        /// <summary>
        ///     ɾ���û���Ϣ
        /// </summary>
        /// <param name="input">�û�id</param>
        /// <returns></returns>
        public async Task<OperateStatus> DeleteUser(IdInput input)
        {
            await _permissionUserLogic.DeletePermissionUser(input);
            return await DeleteAsync(input.Id);
        }

        /// <summary>
        ///     �����û�Id��ȡ���û���Ϣ
        /// </summary>
        /// <param name="input">�û�Id</param>
        /// <returns></returns>
        public async Task<SystemUserDetailOutput> GetDetailByUserId(IdInput input)
        {
            //��ȡ�û�������Ϣ
            var userDto = (await _userInfoRepository.GetByIdAsync(input.Id)).MapTo<SystemUserOutput>();
            //ת��
            var userDetailDto = userDto.MapTo<SystemUserDetailOutput>();
            //��ȡ��ɫ���顢��λ����
            IList<SystemPrivilegeDetailListOutput> privilegeDetailDtos = (await
                _permissionUserLogic.GetSystemPrivilegeDetailOutputsByUserId(input)).ToList();
            //��ɫ
            userDetailDto.Role = privilegeDetailDtos.Where(w => w.PrivilegeMaster == EnumPrivilegeMaster.��ɫ).ToList();
            //��
            userDetailDto.Group = privilegeDetailDtos.Where(w => w.PrivilegeMaster == EnumPrivilegeMaster.��).ToList();
            //��λ
            userDetailDto.Post = privilegeDetailDtos.Where(w => w.PrivilegeMaster == EnumPrivilegeMaster.��λ).ToList();
            return userDetailDto;
        }

        /// <summary>
        ///     �����û�Id����ĳ������
        /// </summary>
        /// <param name="input">�û�Id</param>
        /// <returns></returns>
        public async Task<OperateStatus> ResetPassword(IdInput input)
        {
            var operateStatus = new OperateStatus();
            //��ȡϵͳĬ��������������
            var password = GlobalParams.Get("resetPassword").ToString();
            //��������
            //��������������
            var encryptPwd = DEncryptUtil.Encrypt(password, GlobalParams.Get("pwdKey").ToString());
            if (await _userInfoRepository.ResetPassword(new ResetPasswordInput
            {
                EncryptPassword = encryptPwd,
                Id = input.Id
            }))
            {
                operateStatus.ResultSign = ResultSign.Successful;
                operateStatus.Message = string.Format(ResourceSystem.��������ɹ�, password);
            }
            return operateStatus;
        }

        /// <summary>
        /// �����޸ĺ�������Ϣ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<OperateStatus> SaveChangePassword(ChangePasswordInput input)
        {
            var operateStatus = new OperateStatus();
            //��̨�ٴ���֤�Ƿ�һ��
            if (!input.NewPassword.Equals(input.ConfirmNewPassword))
            {
                operateStatus.Message = string.Format(Chs.Error, "¼����������ȷ�����벻һ�¡�");
                return operateStatus;
            }
            //�������Ƿ���ȷ
            operateStatus = await CheckOldPassword(new CheckSameValueInput() { Id = input.Id, Param = input.OldPassword });
            if (operateStatus.ResultSign == ResultSign.Error)
            {
                return operateStatus;
            }
            //��������������
            var encryptPwd = DEncryptUtil.Encrypt(input.NewPassword, GlobalParams.Get("pwdKey").ToString());
            if (await _userInfoRepository.ResetPassword(new ResetPasswordInput
            {
                EncryptPassword = encryptPwd,
                Id = input.Id
            }))
            {
                operateStatus.ResultSign = ResultSign.Successful;
                operateStatus.Message = string.Format(ResourceSystem.��������ɹ�, input.NewPassword);
            }
            return operateStatus;
        }

        /// <summary>
        ///     ��֤�������Ƿ�������ȷ
        /// </summary>
        /// <param name="input">��Ҫ��֤�Ĳ���</param>
        /// <returns></returns>
        public async Task<OperateStatus> CheckOldPassword(CheckSameValueInput input)
        {
            var operateStatus = new OperateStatus();
            input.Param = DEncryptUtil.Encrypt(input.Param, GlobalParams.Get("pwdKey").ToString());
            if (!await _userInfoRepository.CheckOldPassword(input))
            {
                operateStatus.ResultSign = ResultSign.Error;
                operateStatus.Message = string.Format("�����벻��ȷ");
            }
            else
            {
                operateStatus.ResultSign = ResultSign.Successful;
            }
            return operateStatus;
        }

        #endregion
    }
}