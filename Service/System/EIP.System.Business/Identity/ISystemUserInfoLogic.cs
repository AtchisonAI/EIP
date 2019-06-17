using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.Business;
using EIP.Common.Entities;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Dtos.Reports;
using EIP.Common.Entities.Paging;
using EIP.System.Models.Dtos.Identity;
using EIP.System.Models.Entities;

namespace EIP.System.Business.Identity
{
    /// <summary>
    ///     �û�ҵ���߼�
    /// </summary>
    public interface ISystemUserInfoLogic : IAsyncLogic<SystemUserInfo>
    {
        /// <summary>
        ///     ���ݵ�¼����������ѯ�û���Ϣ
        /// </summary>
        /// <param name="input">�û����������</param>
        /// <returns></returns>
        Task<OperateStatus<SystemUserOutput>> CheckUserByCodeAndPwd(UserLoginInput input);

        /// <summary>
        ///     ��ҳ��ѯ
        /// </summary>
        /// <param name="paging">��ҳ����</param>
        /// <returns></returns>
        Task<PagedResults<SystemUserOutput>> PagingUserQuery(SystemUserPagingInput paging);

        /// <summary>
        ///     Excel������ʽ
        /// </summary>
        /// <param name="paging">��ѯ����</param>
        /// <param name="excelReportDto"></param>
        /// <returns></returns>
        Task<OperateStatus> ReportExcelUserQuery(SystemUserPagingInput paging,
            ExcelReportDto excelReportDto);

        /// <summary>
        ///     �������������Ƿ��Ѿ������ظ���
        /// </summary>
        /// <param name="input">��Ҫ��֤�Ĳ���</param>
        /// <returns></returns>
        Task<OperateStatus> CheckUserCode(CheckSameValueInput input);

        /// <summary>
        ///     ������Ա��Ϣ
        /// </summary>
        /// <param name="user">��Ա��Ϣ</param>
        /// <param name="orgId">ҵ���Id������֯����Id</param>
        /// <returns></returns>
        Task<OperateStatus> SaveUser(SystemUserInfo user,
            Guid orgId);

        /// <summary>
        ///     ��ȡ�����û�
        /// </summary>
        /// <param name="input">�Ƿ񶳽�</param>
        /// <returns></returns>
        Task<IEnumerable<SystemChosenUserOutput>> GetChosenUser(FreezeInput input = null);

        /// <summary>
        ///     ɾ���û���Ϣ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperateStatus> DeleteUser(IdInput input);

        /// <summary>
        ///     �����û�Id����ĳ������
        /// </summary>
        /// <param name="input">�û�Id</param>
        /// <returns></returns>
        Task<OperateStatus> ResetPassword(IdInput input);

        /// <summary>
        /// �����޸ĺ�������Ϣ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
       Task< OperateStatus> SaveChangePassword(ChangePasswordInput input);

        /// <summary>
        ///     ��֤�������Ƿ�������ȷ
        /// </summary>
        /// <param name="input">��Ҫ��֤�Ĳ���</param>
        /// <returns></returns>
        Task<OperateStatus> CheckOldPassword(CheckSameValueInput input);

        /// <summary>
        ///     �����û�Id��ȡ���û���Ϣ
        /// </summary>
        /// <param name="input">�û�Id</param>
        /// <returns></returns>
        Task<SystemUserDetailOutput> GetDetailByUserId(IdInput input);
    }
}