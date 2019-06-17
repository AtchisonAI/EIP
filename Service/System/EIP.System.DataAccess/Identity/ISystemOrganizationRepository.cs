using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.Common.Entities.Tree;
using EIP.System.Models.Dtos.Identity;
using EIP.System.Models.Entities;

namespace EIP.System.DataAccess.Identity
{
    public interface ISystemOrganizationRepository : IAsyncRepository<SystemOrganization>
    {
        /// <summary>
        ///     ���ݸ�����ѯ�¼�
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IEnumerable<TreeEntity>> GetSystemOrganizationByPid(IdInput input);

        /// <summary>
        ///     ��ȡ������֯������Ϣ
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TreeEntity>> GetSystemOrganization();

        /// <summary>
        ///     ���ݸ�����ѯ�¼�
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IEnumerable<SystemOrganizationOutput>> GetOrganizationResultByTreeId(IdInput input);

        /// <summary>
        ///     ������:Ψһ�Լ��
        /// </summary>
        /// <param name="input">����</param>
        /// <returns></returns>
        Task<bool> CheckOrganizationCode(CheckSameValueInput input);

        /// <summary>
        /// ����Ȩ����֯������
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IEnumerable<TreeEntity>> GetOrganizationResultByDataPermission(IdInput<string> input);
    }
}