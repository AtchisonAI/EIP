using System.Collections.Generic;
using System.Threading.Tasks;
using EIP.Common.DataAccess;
using EIP.Common.Entities.Dtos;
using EIP.System.Models.Dtos.Identity;
using EIP.System.Models.Entities;

namespace EIP.System.DataAccess.Identity
{
    public interface ISystemPostRepository : IAsyncRepository<SystemPost>
    {
        /// <summary>
        ///     ��ѯ����ĳ��֯�µĸ�λ��Ϣ
        /// </summary>
        /// <param name="input">��֯����PostId</param>
        /// <returns>��λ��Ϣ</returns>
        Task<IEnumerable<SystemPostOutput>> GetPostByOrganizationId(NullableIdInput input);

        /// <summary>
        ///     ������:Ψһ�Լ��
        /// </summary>
        /// <param name="input">����</param>
        /// <returns></returns>
        Task<bool> CheckPostCode(CheckSameValueInput input);
    }
}